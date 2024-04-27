using Core.Entites.Identity;
using Core.Interfaces;
using Infrastructure.Authentication;
using Infrastructure.Configuration;
using Infrastructure.Data;
using Infrastructure.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Setup_Master.API.Services;
using System.Text;

namespace API
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            builder.Services.AddDbContext<SetupMasterDbContext>(options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
            builder.Services.AddDbContext<AppIdentityDbContext>(opt =>
            {
                opt.UseSqlServer(builder.Configuration.GetConnectionString("IdentityConnection"));
            }
            );
            builder.Services.AddDbContext<BenchmarkDbContext>(options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString("BenchmarkConnection")));
            builder.Services.AddIdentity<User,IdentityRole>().AddEntityFrameworkStores<AppIdentityDbContext>()
                .AddDefaultTokenProviders()
                .AddSignInManager<SignInManager<User>>();
            builder.Services.AddScoped<IAuthService, AuthService>();
            builder.Services.AddScoped<IProcessorService,ProcessorService>();
            builder.Services.AddScoped<IGPUService, GPUService>();
            builder.Services.AddScoped<IMotherboardService, MotherboardService>();
            builder.Services.AddScoped<IHDDService, HDDService>();
            builder.Services.AddScoped<IRAMService, RAMService>();
            builder.Services.AddScoped<ISSDService, SSDService>();
            builder.Services.AddScoped<IPowerSupplieservice, PowerSupplieservice>();
            builder.Services.AddScoped<ICPUCoolerService, CPUCoolerService>();
            builder.Services.AddScoped<ICaseService, CaseService>();
            builder.Services.AddScoped<EmailService>();

            builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            builder.Services.Configure<Jwt>(builder.Configuration.GetSection("Jwt"));
            
            builder.Services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(jwt =>
            {
                var key = Encoding.ASCII.GetBytes(builder.Configuration.GetSection("Jwt:Key").Value);
                jwt.SaveToken = false;
                jwt.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    RequireExpirationTime = true, // for dev -- needs to be updated when refresh token is added
                    ValidateLifetime = true
                };
            });
            builder.Services.AddCors(options =>
            {
                options.AddPolicy("AllowAll",
                 b => b.AllowAnyMethod()
                .AllowAnyHeader()
                .AllowAnyOrigin());
            });

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();


            var app = builder.Build();
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            // Configure the HTTP request pipeline.

            app.UseHttpsRedirection();

            
            app.UseCors("AllowAll");

            app.UseAuthentication();

            app.UseAuthorization();

            app.MapControllers();



            
            using var scope = app.Services.CreateScope();
            var services = scope.ServiceProvider;
            var context = services.GetRequiredService<SetupMasterDbContext>();
            var IdentityContext = services.GetRequiredService<AppIdentityDbContext>();
            var BenchmarkContext = services.GetService<BenchmarkDbContext>();
            var userManager = services.GetRequiredService<UserManager<User>>();
            var logger = services.GetRequiredService<ILogger<Program>>();
            try
            {
                await context.Database.MigrateAsync();
                await IdentityContext.Database.MigrateAsync();
                await BenchmarkContext.Database.MigrateAsync();
                //adding seed contents json file to the darabse 
                await SetupMasterContentSeed.SeedAsync(context);
                await AppIdentityContentSeed.SeedusersAsync(userManager);
                await BenchmarkContentSeed.SeedAsync(BenchmarkContext);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error occured during migration");
            }

            app.Run();
        }
    }
}
