using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Mako.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;
using Mako.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;

namespace Mako
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddDbContext<MakoContext>(options => 
             options.UseSqlServer(Configuration.GetConnectionString("ConexaoPrincipal")));
            //conexao Principal definida na connectionstring do projeto em appsettings.json


            //criacao do servico para cada vez que ele for requisitado no caso ele cria a interface para poder
            //usar os contextos com baixo acomplamento para nao depender do framework e usa-lo apenas como um servico
            // :)

            //                          interface                 implementacao
            services.AddTransient<ICategoriaProdutoRepository, CategoriaProdutoRepository>();
          
            services.AddTransient<IProdutoRepository, ProdutoRepository>();

            services.AddTransient<IPedidoRepository, PedidoRepository>();

            // vai ser criado e fornecido para todas as requisicoes
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            // vai criar um carrinho para cada requisicao (para solicitacoes simultaneas multiplos carrinhos)
            services.AddScoped(cp => CarrinhoCompra.GetCarrinho(cp));

            services.AddMemoryCache();
            services.AddSession();



            //adiocna o controle de identificacao dos usuarios    
            //configuracao do contexto
            //inclui os tokens para troca de senha e envio de emal
            services.AddIdentity<IdentityUser, IdentityRole>()
                .AddEntityFrameworkStores<MakoContext>()
                .AddDefaultTokenProviders();

            //primeira tentativa falha de contextualizacao do banco quando eu estava tentando usar o inmemory do aspnetcore
            //mas realmente o banco em memoria nao eh uma boa para teste e nem para praticar migrations

            //services.AddScoped<MakoContext, MakoContext>(); //gestao de dependencias sempre que for usado sera criado uma versao em memoria e depois disso ele usa o que ja ta em memoria, sem ter que criar novos bancos

            services.AddControllersWithViews();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseSession();
            app.UseAuthentication();

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();
            app.UseCookiePolicy();


            app.UseAuthorization();


            //mapeamento das paginas
            app.UseEndpoints(endpoints =>
            {

                //endpoints.MapControllerRoute(
                  //  name: "AdminArea",
                  //  pattern: "{area:exists}/{controller=Admin}/{action=Index}/{id?}");


                endpoints.MapControllerRoute(
                    name: "categoriafiltro",
                    pattern: "Produto/{acation}/{categoria?}",
                    defaults: new { Controller = "Produto", action = "List" });

                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
