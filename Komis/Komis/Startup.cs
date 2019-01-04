using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Komis.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace Komis
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)//dodajemy usługi do kontenera wstrzykiwania zależności, IServiceCollection pozwala na rejestrowanie usług w ASP.NET Core
        {
            services.AddTransient<ISamochodRepository, MockSamochodRepository>(); // rejestrowanie usługi za każdym razem, gdy ktoś poprosi ISamochodRepository zostanie zwrócone MockSamochodRepository
            // services.AddSingleton-- oznacza jedno wystąpienie pojedynczego typu, które będzie zawsze zwracane
            // services.AddScoped-- na żadanie zwróci to samo wystąpienie, gdy żądanie wykracza poza zakres istancja zostanie usunięta, przy nowym żądaniu zwrócona zostaje nowa instancja
            services.AddMvc();// rejestrowanie usług frameworku, aplikacja wie o mvc
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)// konfigurowanie potoku żądań aplikacji, ważna kolejność!
        {
            // sekwencja komponentów, które działają na żądanie przychodzące, możliwość: sprawdzenia, zmiany (obsługa) i przekazania żądania do następnego komponentu (odesłanie do klienta)
            app.UseDeveloperExceptionPage(); // obsługa strony błędu, użycie tylko podczas pisania aplikacja
            app.UseStatusCodePages(); // wyświetla informację o statusie żądania
            app.UseStaticFiles(); // obsługa plików statycznych
            app.UseMvcWithDefaultRoute(); //oprogramowanie pośrednie mvc, z domyslnym routingiem
        }
    }
}
