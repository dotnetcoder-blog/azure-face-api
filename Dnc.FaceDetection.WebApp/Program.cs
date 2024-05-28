using Dnc.FaceDetection.WebApp.Components;
using Dnc.Services.FaceDetection;
using Dnc.Services.FaceDetection.Clients;
using Microsoft.Extensions.Configuration;

namespace Dnc.FaceDetection.WebApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddRazorComponents()
                .AddInteractiveServerComponents();

            builder.Services.AddHttpClient<IAzureFaceDetectionClient, AzureFaceDetectionClient>(httpClient =>
            {
                httpClient.BaseAddress = new Uri(builder.Configuration.GetValue<string>("Endpoint"));
                httpClient.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", builder.Configuration.GetValue<string>("SubscriptionKey"));
            });

            builder.Services.AddScoped<IAzureFaceDetectionService, AzureFaceDetectionService>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();

            app.UseStaticFiles();
            app.UseAntiforgery();

            app.MapRazorComponents<App>()
                .AddInteractiveServerRenderMode();

            app.Run();
        }
    }
}
