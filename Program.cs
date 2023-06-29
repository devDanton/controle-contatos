using ControleContatos.Data;
using ControleContatos.Repositorio;
using Microsoft.EntityFrameworkCore;

namespace ControleContatos
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();


            /*var connectionString = "Server=./; Database=DB_SistemaContatos; User Id=sa; password=123456";*/


            var connectionString = "Data Source=P6075\\SQLSERVER2022;Initial Catalog=DB_SistemaContatos;User ID=sa;Password=Serbele@2023; TrustServerCertificate=true;";
            builder.Services.AddDbContext<BancoContext>(options => options.UseSqlServer(connectionString));
            builder.Services.AddScoped<IContatoRepositorio, ContatoRepositorio>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}