﻿using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mako.Data
{
    public static class SeedData
    {

        public static async Task CreateRoles(IServiceProvider serviceProvider, IConfiguration Configuration)
        {
            //incluir perfis customizados
            var RoleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            var UserManager = serviceProvider.GetRequiredService<UserManager<IdentityUser>>();

            //define os perfis em um array de strings
            string[] roleNames = { "Admin", "Member" };
            IdentityResult roleResult;

                    //percorre o array de strings 
                    //verifica se o perfil já existe
                    foreach (var roleName in roleNames)
                    {
                        // cria perfis e os inclui no banco de dados
                        var roleExist = await RoleManager.RoleExistsAsync(roleName);
                        if (!roleExist)
                        {
                            roleResult = await RoleManager.CreateAsync(new IdentityRole(roleName));
                        }
                    }

                    // cria um super usuário que pode manter a aplicação web configurado na appsettings
                    var poweruser = new IdentityUser
                    {
                        //obtem o nome e o email do arquivo de configuração
                        UserName = Configuration.GetSection("UserSettings")["UserName"],
                        Email = Configuration.GetSection("UserSettings")["UserEmail"]
                    };

                        //obtem a senha do arquivo de configuração
                        string userPassword = Configuration.GetSection("UserSettings")["UserPassword"];

            //verifica se existe um usuário com o email informado
            var user = await UserManager.FindByEmailAsync(Configuration.GetSection("UserSettings")["UserEmail"]);

            if (user == null)
            {
                //cria o super usuário com os dados informados
                var createPowerUser = await UserManager.CreateAsync(poweruser, userPassword);
                if (createPowerUser.Succeeded)
                {
                    // atribui o usuário ao perfil Admin
                    await UserManager.AddToRoleAsync(poweruser, "Admin");
                }
            }
        }

        public static IHost CreateAdminRole(this IHost host)
        {
            // Create a scope to get scoped services.
            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                try
                {
                    var serviceProvider = services.GetRequiredService<IServiceProvider>();
                    var configuration = services.GetRequiredService<IConfiguration>();
                    //chama o método para criar os perfis 
                    //e atribuir o perfil admin ao superusuario
                    SeedData.CreateRoles(serviceProvider, configuration).Wait();
                }
                catch (Exception exception)
                {
                    var logger = services.GetRequiredService<ILogger<Program>>();
                    logger.LogError(exception, "Ocorreu um erro na criação dos perfis dos usuários");
                }
            }
            return host;
        }



    }
}
