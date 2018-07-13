using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using bsa2018_ProjectStructure.Shared.DTO;
using bsa2018_ProjectStructure.BLL.Interfaces;
using bsa2018_ProjectStructure.BLL.Services;
using bsa2018_ProjectStructure.DataAccess.Interfaces;
using bsa2018_ProjectStructure.DataAccess.Repository;
using bsa2018_ProjectStructure.DataAccess.Model;

namespace bsa2018_ProjectStructure
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
            services.AddMvc();
            services.AddSingleton<DataContext>();

            services.AddSingleton<IUnitOfWork, UnitOfWork>();

            services.AddTransient<IAircraftService, AircraftService>();
            services.AddTransient<IAircraftTypesService, AircraftTypesService>();
            services.AddTransient<ICrewService, CrewService>();
            services.AddTransient<IDepartureService, DepartureService>();
            services.AddTransient<IFlightService,FlightService>();
            services.AddTransient<IPilotService, PilotService>();
            services.AddTransient<IStewardessService, StewardessService>();
            services.AddTransient<ITicketService, TicketService>();

            MapperConfiguration mapper = new MapperConfiguration();
            services.AddSingleton(_ => mapper.Configure().CreateMapper());
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();
        }
    }
}
