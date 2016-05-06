using DNXTest.Models;
using DNXTest.Services;
using Microsoft.AspNet.Hosting;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Mvc.Formatters;
using Microsoft.AspNet.Mvc.Formatters.Json;
using Microsoft.AspNet.Builder;
using Microsoft.Data.Entity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Microsoft.AspNet.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DNXTest
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            // Set up configuration sources.
            var builder = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true);

            if (env.IsDevelopment())
            {
                // For more details on using the user secret store see http://go.microsoft.com/fwlink/?LinkID=532709
                builder.AddUserSecrets();
            }

            builder.AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; set; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // Add framework services.
            services.AddEntityFramework()
                //.AddSqlServer()
                .AddNpgsql()
                .AddDbContext<ApplicationDbContext>((options =>
                    options.UseNpgsql(Configuration["Data:DefaultConnection:ConnectionString"])/*options =>
                    options.UseSqlServer(Configuration["Data:DefaultConnection:ConnectionString"])*/));

            JsonOutputFormatter jsonOutputFormatter = new JsonOutputFormatter
            {
                SerializerSettings = new JsonSerializerSettings
                {
                    ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                }
            };


            //services.AddMvc();
            services.AddMvc(
                options =>
                {
                    options.OutputFormatters.Clear();
                    options.OutputFormatters.Insert(0, jsonOutputFormatter);
                }
            );

            //services.AddMvcDnx();

            services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();

            // Use a PostgreSQL database
            // services.AddScoped<IDataAccessProvider, DataAccessPostgreSqlProvider>();

            // Add application services.
            services.AddTransient<IEmailSender, AuthMessageSender>();
            services.AddTransient<ISmsSender, AuthMessageSender>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            if (env.IsDevelopment())
            {
                app.UseBrowserLink();
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");

                // For more details on creating database during deployment see http://go.microsoft.com/fwlink/?LinkID=615859
                try
                {
                    using (var serviceScope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>()
                        .CreateScope())
                    {
                        serviceScope.ServiceProvider.GetService<ApplicationDbContext>()
                             .Database.Migrate();
                    }
                }
                catch { }
            }

            app.UseIISPlatformHandler(options => options.AuthenticationDescriptions.Clear());

            app.UseStaticFiles();

            app.UseIdentity();

            // To configure external authentication please see http://go.microsoft.com/fwlink/?LinkID=532715

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });


            //  Seeding database if just deployed
            using (ApplicationDbContext context = app.ApplicationServices.GetRequiredService<ApplicationDbContext>())
            {
                    if (context.ContactBloodType.Count() == 0)
                    {
                        context.ContactBloodType.Add(new ContactBloodType() { Id = 1, Description = "O− " });
                        context.ContactBloodType.Add(new ContactBloodType() { Id = 2, Description = "O+ " });
                        context.ContactBloodType.Add(new ContactBloodType() { Id = 3, Description = "A− " });
                        context.ContactBloodType.Add(new ContactBloodType() { Id = 4, Description = "A+ " });
                        context.ContactBloodType.Add(new ContactBloodType() { Id = 5, Description = "B− " });
                        context.ContactBloodType.Add(new ContactBloodType() { Id = 6, Description = "B+ " });
                        context.ContactBloodType.Add(new ContactBloodType() { Id = 7, Description = "AB−" });
                        context.ContactBloodType.Add(new ContactBloodType() { Id = 8, Description = "AB+" });
                    }

                    if (context.DonorType.Count() == 0)
                    {
                        context.DonorType.Add(new DonorType() { Id = 1, Description = "Small" });
                        context.DonorType.Add(new DonorType() { Id = 2, Description = "Big" });
                        context.DonorType.Add(new DonorType() { Id = 3, Description = "Grand Sponsor" });
                        context.DonorType.Add(new DonorType() { Id = 4, Description = "Friends of Nalanda" });
                    }

                    if (context.DonorReligiousSituation.Count() == 0)
                    {
                        context.DonorReligiousSituation.Add(new DonorReligiousSituation() { Id = 1, Description = "Laymen" });
                        context.DonorReligiousSituation.Add(new DonorReligiousSituation() { Id = 2, Description = "Ordained" });
                        context.DonorReligiousSituation.Add(new DonorReligiousSituation() { Id = 3, Description = "Full Ordination" });
                        context.DonorReligiousSituation.Add(new DonorReligiousSituation() { Id = 4, Description = "Disrobed" });
                    }

                    if (context.DonorInterest.Count() == 0)
                    {
                        context.DonorInterest.Add(new DonorInterest() { Id = 1, Description = "Studies" });
                        context.DonorInterest.Add(new DonorInterest() { Id = 2, Description = "Vipassana retreats" });
                        context.DonorInterest.Add(new DonorInterest() { Id = 3, Description = "Lam Rim retreats" });
                        context.DonorInterest.Add(new DonorInterest() { Id = 4, Description = "Shamatha retreats" });
                        context.DonorInterest.Add(new DonorInterest() { Id = 5, Description = "Tara Puja" });
                        context.DonorInterest.Add(new DonorInterest() { Id = 6, Description = "Medicine Buddha Puja" });
                        context.DonorInterest.Add(new DonorInterest() { Id = 7, Description = "Vajrasattva Puja" });
                        context.DonorInterest.Add(new DonorInterest() { Id = 8, Description = "Guru Yoga" });
                        context.DonorInterest.Add(new DonorInterest() { Id = 9, Description = "35 Buddhas Confession" });
                    }


                    if (context.DonorContext.Count() == 0)
                    {
                        context.DonorContext.Add(new DonorContext() { Id = 1, Description = "Is a BP student" });
                        context.DonorContext.Add(new DonorContext() { Id = 2, Description = "Was a BP student" });
                        context.DonorContext.Add(new DonorContext() { Id = 3, Description = "Is a MP student" });
                        context.DonorContext.Add(new DonorContext() { Id = 4, Description = "Was a MP student" });
                        context.DonorContext.Add(new DonorContext() { Id = 5, Description = "Is a volunteer" });
                        context.DonorContext.Add(new DonorContext() { Id = 6, Description = "Was a volunteer" });
                    }

                    if (context.ContactRelationship.Count() == 0)
                    {

                        context.ContactRelationship.Add(new ContactRelationship() { Id = 1, Description = "Spouse" });
                        context.ContactRelationship.Add(new ContactRelationship() { Id = 2, Description = "Child" });
                        context.ContactRelationship.Add(new ContactRelationship() { Id = 3, Description = "Mother" });
                        context.ContactRelationship.Add(new ContactRelationship() { Id = 4, Description = "Father" });
                        context.ContactRelationship.Add(new ContactRelationship() { Id = 5, Description = "Parent" });
                        context.ContactRelationship.Add(new ContactRelationship() { Id = 6, Description = "Brother" });
                        context.ContactRelationship.Add(new ContactRelationship() { Id = 7, Description = "Sister" });
                        context.ContactRelationship.Add(new ContactRelationship() { Id = 8, Description = "Friend" });
                        context.ContactRelationship.Add(new ContactRelationship() { Id = 9, Description = "Relative" });
                        context.ContactRelationship.Add(new ContactRelationship() { Id = 10, Description = "Manager" });
                        context.ContactRelationship.Add(new ContactRelationship() { Id = 11, Description = "Assistant" });
                        context.ContactRelationship.Add(new ContactRelationship() { Id = 12, Description = "Referred by" });
                        context.ContactRelationship.Add(new ContactRelationship() { Id = 13, Description = "Partner" });
                        context.ContactRelationship.Add(new ContactRelationship() { Id = 14, Description = "Domestic partner" });
                    }

                    if (context.SpokenLanguage.Count() == 0)
                    {
                        context.SpokenLanguage.Add(new SpokenLanguage() { Id = 1, Description = "French" });
                        context.SpokenLanguage.Add(new SpokenLanguage() { Id = 2, Description = "English" });
                        context.SpokenLanguage.Add(new SpokenLanguage() { Id = 3, Description = "Spanish" });
                        context.SpokenLanguage.Add(new SpokenLanguage() { Id = 4, Description = "Tibetan" });
                        context.SpokenLanguage.Add(new SpokenLanguage() { Id = 5, Description = "German" });
                    }

                    if (context.Country.Count() == 0)
                    {   
                        // 237 countries 
                        int idcountry = 0;

                        context.Country.Add(new Country() { Id = ++idcountry, Description = "Afghanistan" });
                        context.Country.Add(new Country() { Id = ++idcountry, Description = "Albania" });
                        context.Country.Add(new Country() { Id = ++idcountry, Description = "Algeria" });
                        context.Country.Add(new Country() { Id = ++idcountry, Description = "American Samoa" });
                        context.Country.Add(new Country() { Id = ++idcountry, Description = "Andorra" });
                        context.Country.Add(new Country() { Id = ++idcountry, Description = "Angola" });
                        context.Country.Add(new Country() { Id = ++idcountry, Description = "Anguilla" });
                        context.Country.Add(new Country() { Id = ++idcountry, Description = "Antarctica" });
                        context.Country.Add(new Country() { Id = ++idcountry, Description = "Antigua and Barbuda" });
                        context.Country.Add(new Country() { Id = ++idcountry, Description = "Argentina" });
                        context.Country.Add(new Country() { Id = ++idcountry, Description = "Armenia" });
                        context.Country.Add(new Country() { Id = ++idcountry, Description = "Aruba" });
                        context.Country.Add(new Country() { Id = ++idcountry, Description = "Australia" });
                        context.Country.Add(new Country() { Id = ++idcountry, Description = "Austria" });
                        context.Country.Add(new Country() { Id = ++idcountry, Description = "Azerbaijan" });
                        context.Country.Add(new Country() { Id = ++idcountry, Description = "Bahamas" });
                        context.Country.Add(new Country() { Id = ++idcountry, Description = "Bahrain" });
                        context.Country.Add(new Country() { Id = ++idcountry, Description = "Bangladesh" });
                        context.Country.Add(new Country() { Id = ++idcountry, Description = "Barbados" });
                        context.Country.Add(new Country() { Id = ++idcountry, Description = "Belarus" });
                        context.Country.Add(new Country() { Id = ++idcountry, Description = "Belgium " });
                        context.Country.Add(new Country() { Id = ++idcountry, Description = "Belize" });
                        context.Country.Add(new Country() { Id = ++idcountry, Description = "Benin" });
                        context.Country.Add(new Country() { Id = ++idcountry, Description = "Bermuda" });
                        context.Country.Add(new Country() { Id = ++idcountry, Description = "Bhutan" });
                        context.Country.Add(new Country() { Id = ++idcountry, Description = "Bolivia" });
                        context.Country.Add(new Country() { Id = ++idcountry, Description = "Bosnia and Herzegovina" });
                        context.Country.Add(new Country() { Id = ++idcountry, Description = "Botswana" });
                        context.Country.Add(new Country() { Id = ++idcountry, Description = "Brazil" });
                        context.Country.Add(new Country() { Id = ++idcountry, Description = "Brunei Darussalam" });
                        context.Country.Add(new Country() { Id = ++idcountry, Description = "Bulgaria" });
                        context.Country.Add(new Country() { Id = ++idcountry, Description = "Burkina Faso" });
                        context.Country.Add(new Country() { Id = ++idcountry, Description = "Burundi" });
                        context.Country.Add(new Country() { Id = ++idcountry, Description = "Cambodia" });
                        context.Country.Add(new Country() { Id = ++idcountry, Description = "Cameroon" });
                        context.Country.Add(new Country() { Id = ++idcountry, Description = "Canada" });
                        context.Country.Add(new Country() { Id = ++idcountry, Description = "Cape Verde" });
                        context.Country.Add(new Country() { Id = ++idcountry, Description = "Cayman Islands" });
                        context.Country.Add(new Country() { Id = ++idcountry, Description = "Central African Republic" });
                        context.Country.Add(new Country() { Id = ++idcountry, Description = "Chad" });
                        context.Country.Add(new Country() { Id = ++idcountry, Description = "Chile" });
                        context.Country.Add(new Country() { Id = ++idcountry, Description = "China" });
                        context.Country.Add(new Country() { Id = ++idcountry, Description = "Christmas Island" });
                        context.Country.Add(new Country() { Id = ++idcountry, Description = "Cocos (Keeling) Islands" });
                        context.Country.Add(new Country() { Id = ++idcountry, Description = "Colombia" });
                        context.Country.Add(new Country() { Id = ++idcountry, Description = "Comoros" });
                        context.Country.Add(new Country() { Id = ++idcountry, Description = "Democratic Republic of the Congo" });
                        context.Country.Add(new Country() { Id = ++idcountry, Description = "Cook Islands" });
                        context.Country.Add(new Country() { Id = ++idcountry, Description = "Costa Rica" });
                        context.Country.Add(new Country() { Id = ++idcountry, Description = "Ivory Coast" });
                        context.Country.Add(new Country() { Id = ++idcountry, Description = "Croatia" });
                        context.Country.Add(new Country() { Id = ++idcountry, Description = "Cuba" });
                        context.Country.Add(new Country() { Id = ++idcountry, Description = "Cyprus" });
                        context.Country.Add(new Country() { Id = ++idcountry, Description = "Czech Republic" });
                        context.Country.Add(new Country() { Id = ++idcountry, Description = "Denmark" });
                        context.Country.Add(new Country() { Id = ++idcountry, Description = "Djibouti" });
                        context.Country.Add(new Country() { Id = ++idcountry, Description = "Dominica" });
                        context.Country.Add(new Country() { Id = ++idcountry, Description = "Dominican Republic" });
                        context.Country.Add(new Country() { Id = ++idcountry, Description = "East Timor" });
                        context.Country.Add(new Country() { Id = ++idcountry, Description = "Ecuador" });
                        context.Country.Add(new Country() { Id = ++idcountry, Description = "Egypt" });
                        context.Country.Add(new Country() { Id = ++idcountry, Description = "El Salvador" });
                        context.Country.Add(new Country() { Id = ++idcountry, Description = "Equatorial Guinea" });
                        context.Country.Add(new Country() { Id = ++idcountry, Description = "Eritrea" });
                        context.Country.Add(new Country() { Id = ++idcountry, Description = "Estonia" });
                        context.Country.Add(new Country() { Id = ++idcountry, Description = "Ethiopia" });
                        context.Country.Add(new Country() { Id = ++idcountry, Description = "Falkland Islands" });
                        context.Country.Add(new Country() { Id = ++idcountry, Description = "Faroe Islands" });
                        context.Country.Add(new Country() { Id = ++idcountry, Description = "Fiji" });
                        context.Country.Add(new Country() { Id = ++idcountry, Description = "Finland" });
                        context.Country.Add(new Country() { Id = ++idcountry, Description = "France" });
                        context.Country.Add(new Country() { Id = ++idcountry, Description = "French Guiana" });
                        context.Country.Add(new Country() { Id = ++idcountry, Description = "French Polynesia" });
                        context.Country.Add(new Country() { Id = ++idcountry, Description = "French Southern Territories" });
                        context.Country.Add(new Country() { Id = ++idcountry, Description = "Gabon" });
                        context.Country.Add(new Country() { Id = ++idcountry, Description = "Gambia" });
                        context.Country.Add(new Country() { Id = ++idcountry, Description = "Georgia" });
                        context.Country.Add(new Country() { Id = ++idcountry, Description = "Germany" });
                        context.Country.Add(new Country() { Id = ++idcountry, Description = "Ghana" });
                        context.Country.Add(new Country() { Id = ++idcountry, Description = "Gibraltar" });
                        context.Country.Add(new Country() { Id = ++idcountry, Description = "Great" });
                        context.Country.Add(new Country() { Id = ++idcountry, Description = "Greece" });
                        context.Country.Add(new Country() { Id = ++idcountry, Description = "Greenland" });
                        context.Country.Add(new Country() { Id = ++idcountry, Description = "Grenada" });
                        context.Country.Add(new Country() { Id = ++idcountry, Description = "Guadeloupe" });
                        context.Country.Add(new Country() { Id = ++idcountry, Description = "Guam" });
                        context.Country.Add(new Country() { Id = ++idcountry, Description = "Guatemala" });
                        context.Country.Add(new Country() { Id = ++idcountry, Description = "Guinea" });
                        context.Country.Add(new Country() { Id = ++idcountry, Description = "Guinea-Bissau" });
                        context.Country.Add(new Country() { Id = ++idcountry, Description = "Guyana" });
                        context.Country.Add(new Country() { Id = ++idcountry, Description = "Haiti" });
                        context.Country.Add(new Country() { Id = ++idcountry, Description = "Holy See" });
                        context.Country.Add(new Country() { Id = ++idcountry, Description = "Honduras" });
                        context.Country.Add(new Country() { Id = ++idcountry, Description = "Hong Kong" });
                        context.Country.Add(new Country() { Id = ++idcountry, Description = "Hungary" });
                        context.Country.Add(new Country() { Id = ++idcountry, Description = "Iceland" });
                        context.Country.Add(new Country() { Id = ++idcountry, Description = "India" });
                        context.Country.Add(new Country() { Id = ++idcountry, Description = "Indonesia" });
                        context.Country.Add(new Country() { Id = ++idcountry, Description = "Iran" });
                        context.Country.Add(new Country() { Id = ++idcountry, Description = "Iraq" });
                        context.Country.Add(new Country() { Id = ++idcountry, Description = "Ireland" });
                        context.Country.Add(new Country() { Id = ++idcountry, Description = "Israel" });
                        context.Country.Add(new Country() { Id = ++idcountry, Description = "Italy" });
                        context.Country.Add(new Country() { Id = ++idcountry, Description = "Jamaica" });
                        context.Country.Add(new Country() { Id = ++idcountry, Description = "Japan" });
                        context.Country.Add(new Country() { Id = ++idcountry, Description = "Jordan" });
                        context.Country.Add(new Country() { Id = ++idcountry, Description = "Kazakhstan" });
                        context.Country.Add(new Country() { Id = ++idcountry, Description = "Kenya" });
                        context.Country.Add(new Country() { Id = ++idcountry, Description = "Kiribati" });
                        context.Country.Add(new Country() { Id = ++idcountry, Description = "Korea" });
                        context.Country.Add(new Country() { Id = ++idcountry, Description = "Korea" });
                        context.Country.Add(new Country() { Id = ++idcountry, Description = "Kosovo" });
                        context.Country.Add(new Country() { Id = ++idcountry, Description = "Kosovo" });
                        context.Country.Add(new Country() { Id = ++idcountry, Description = "Kuwait" });
                        context.Country.Add(new Country() { Id = ++idcountry, Description = "Kyrgyzstan" });
                        context.Country.Add(new Country() { Id = ++idcountry, Description = "Lao" });
                        context.Country.Add(new Country() { Id = ++idcountry, Description = "Latvia" });
                        context.Country.Add(new Country() { Id = ++idcountry, Description = "Lebanon" });
                        context.Country.Add(new Country() { Id = ++idcountry, Description = "Lesotho" });
                        context.Country.Add(new Country() { Id = ++idcountry, Description = "Liberia" });
                        context.Country.Add(new Country() { Id = ++idcountry, Description = "Libya" });
                        context.Country.Add(new Country() { Id = ++idcountry, Description = "Liechtenstein" });
                        context.Country.Add(new Country() { Id = ++idcountry, Description = "Lithuania" });
                        context.Country.Add(new Country() { Id = ++idcountry, Description = "Luxembourg" });
                        context.Country.Add(new Country() { Id = ++idcountry, Description = "Macau" });
                        context.Country.Add(new Country() { Id = ++idcountry, Description = "Macedonia" });
                        context.Country.Add(new Country() { Id = ++idcountry, Description = "Madagascar" });
                        context.Country.Add(new Country() { Id = ++idcountry, Description = "Malawi" });
                        context.Country.Add(new Country() { Id = ++idcountry, Description = "Malaysia" });
                        context.Country.Add(new Country() { Id = ++idcountry, Description = "Maldives" });
                        context.Country.Add(new Country() { Id = ++idcountry, Description = "Mali" });
                        context.Country.Add(new Country() { Id = ++idcountry, Description = "Malta" });
                        context.Country.Add(new Country() { Id = ++idcountry, Description = "Marshall Islands" });
                        context.Country.Add(new Country() { Id = ++idcountry, Description = "Martinique" });
                        context.Country.Add(new Country() { Id = ++idcountry, Description = "Mauritania" });
                        context.Country.Add(new Country() { Id = ++idcountry, Description = "Mauritius" });
                        context.Country.Add(new Country() { Id = ++idcountry, Description = "Mayotte" });
                        context.Country.Add(new Country() { Id = ++idcountry, Description = "Mexico" });
                        context.Country.Add(new Country() { Id = ++idcountry, Description = "Micronesia" });
                        context.Country.Add(new Country() { Id = ++idcountry, Description = "Moldova" });
                        context.Country.Add(new Country() { Id = ++idcountry, Description = "Monaco" });
                        context.Country.Add(new Country() { Id = ++idcountry, Description = "Mongolia" });
                        context.Country.Add(new Country() { Id = ++idcountry, Description = "Montenegro" });
                        context.Country.Add(new Country() { Id = ++idcountry, Description = "Montserrat" });
                        context.Country.Add(new Country() { Id = ++idcountry, Description = "Morocco" });
                        context.Country.Add(new Country() { Id = ++idcountry, Description = "Mozambique" });
                        context.Country.Add(new Country() { Id = ++idcountry, Description = "Myanmar" });
                        context.Country.Add(new Country() { Id = ++idcountry, Description = "Namibia" });
                        context.Country.Add(new Country() { Id = ++idcountry, Description = "Nauru" });
                        context.Country.Add(new Country() { Id = ++idcountry, Description = "Nepal" });
                        context.Country.Add(new Country() { Id = ++idcountry, Description = "Netherlands" });
                        context.Country.Add(new Country() { Id = ++idcountry, Description = "Netherlands Antilles" });
                        context.Country.Add(new Country() { Id = ++idcountry, Description = "New Caledonia" });
                        context.Country.Add(new Country() { Id = ++idcountry, Description = "New Zealand" });
                        context.Country.Add(new Country() { Id = ++idcountry, Description = "Nicaragua" });
                        context.Country.Add(new Country() { Id = ++idcountry, Description = "Niger" });
                        context.Country.Add(new Country() { Id = ++idcountry, Description = "Nigeria" });
                        context.Country.Add(new Country() { Id = ++idcountry, Description = "Niue" });
                        context.Country.Add(new Country() { Id = ++idcountry, Description = "Northern Mariana Islands" });
                        context.Country.Add(new Country() { Id = ++idcountry, Description = "Norway" });
                        context.Country.Add(new Country() { Id = ++idcountry, Description = "Oman" });
                        context.Country.Add(new Country() { Id = ++idcountry, Description = "Pakistan" });
                        context.Country.Add(new Country() { Id = ++idcountry, Description = "Palau" });
                        context.Country.Add(new Country() { Id = ++idcountry, Description = "Palestinian territories" });
                        context.Country.Add(new Country() { Id = ++idcountry, Description = "Panama" });
                        context.Country.Add(new Country() { Id = ++idcountry, Description = "Papua New Guinea" });
                        context.Country.Add(new Country() { Id = ++idcountry, Description = "Paraguay" });
                        context.Country.Add(new Country() { Id = ++idcountry, Description = "Peru" });
                        context.Country.Add(new Country() { Id = ++idcountry, Description = "Philippines" });
                        context.Country.Add(new Country() { Id = ++idcountry, Description = "Pitcairn Island" });
                        context.Country.Add(new Country() { Id = ++idcountry, Description = "Poland" });
                        context.Country.Add(new Country() { Id = ++idcountry, Description = "Portugal" });
                        context.Country.Add(new Country() { Id = ++idcountry, Description = "Puerto Rico" });
                        context.Country.Add(new Country() { Id = ++idcountry, Description = "Qatar" });
                        context.Country.Add(new Country() { Id = ++idcountry, Description = "Reunion Island" });
                        context.Country.Add(new Country() { Id = ++idcountry, Description = "Romania" });
                        context.Country.Add(new Country() { Id = ++idcountry, Description = "Russian Federation" });
                        context.Country.Add(new Country() { Id = ++idcountry, Description = "Rwanda" });
                        context.Country.Add(new Country() { Id = ++idcountry, Description = "Saint Kitts and Nevis" });
                        context.Country.Add(new Country() { Id = ++idcountry, Description = "Saint Lucia" });
                        context.Country.Add(new Country() { Id = ++idcountry, Description = "Saint Vincent and the Grenadines" });
                        context.Country.Add(new Country() { Id = ++idcountry, Description = "Samoa" });
                        context.Country.Add(new Country() { Id = ++idcountry, Description = "San Marino" });
                        context.Country.Add(new Country() { Id = ++idcountry, Description = "Sao Tome and Principe" });
                        context.Country.Add(new Country() { Id = ++idcountry, Description = "Saudi Arabia" });
                        context.Country.Add(new Country() { Id = ++idcountry, Description = "Senegal" });
                        context.Country.Add(new Country() { Id = ++idcountry, Description = "Serbia" });
                        context.Country.Add(new Country() { Id = ++idcountry, Description = "Seychelles" });
                        context.Country.Add(new Country() { Id = ++idcountry, Description = "Sierra Leone" });
                        context.Country.Add(new Country() { Id = ++idcountry, Description = "Singapore" });
                        context.Country.Add(new Country() { Id = ++idcountry, Description = "Slovakia" });
                        context.Country.Add(new Country() { Id = ++idcountry, Description = "Slovenia" });
                        context.Country.Add(new Country() { Id = ++idcountry, Description = "Solomon Islands" });
                        context.Country.Add(new Country() { Id = ++idcountry, Description = "Somalia" });
                        context.Country.Add(new Country() { Id = ++idcountry, Description = "South Africa" });
                        context.Country.Add(new Country() { Id = ++idcountry, Description = "South Sudan" });
                        context.Country.Add(new Country() { Id = ++idcountry, Description = "Spain" });
                        context.Country.Add(new Country() { Id = ++idcountry, Description = "Sri Lanka" });
                        context.Country.Add(new Country() { Id = ++idcountry, Description = "Sudan" });
                        context.Country.Add(new Country() { Id = ++idcountry, Description = "Suriname" });
                        context.Country.Add(new Country() { Id = ++idcountry, Description = "Swaziland" });
                        context.Country.Add(new Country() { Id = ++idcountry, Description = "Sweden" });
                        context.Country.Add(new Country() { Id = ++idcountry, Description = "Switzerland" });
                        context.Country.Add(new Country() { Id = ++idcountry, Description = "Syria" });
                        context.Country.Add(new Country() { Id = ++idcountry, Description = "Taiwan" });
                        context.Country.Add(new Country() { Id = ++idcountry, Description = "Tajikistan" });
                        context.Country.Add(new Country() { Id = ++idcountry, Description = "Tanzania" });
                        context.Country.Add(new Country() { Id = ++idcountry, Description = "Thailand" });
                        context.Country.Add(new Country() { Id = ++idcountry, Description = "Tibet" });
                        context.Country.Add(new Country() { Id = ++idcountry, Description = "Timor-Leste" });
                        context.Country.Add(new Country() { Id = ++idcountry, Description = "Togo" });
                        context.Country.Add(new Country() { Id = ++idcountry, Description = "Tokelau" });
                        context.Country.Add(new Country() { Id = ++idcountry, Description = "Tonga" });
                        context.Country.Add(new Country() { Id = ++idcountry, Description = "Trinidad and Tobago" });
                        context.Country.Add(new Country() { Id = ++idcountry, Description = "Tunisia" });
                        context.Country.Add(new Country() { Id = ++idcountry, Description = "Turkey" });
                        context.Country.Add(new Country() { Id = ++idcountry, Description = "Turkmenistan" });
                        context.Country.Add(new Country() { Id = ++idcountry, Description = "Turks and Caicos Islands" });
                        context.Country.Add(new Country() { Id = ++idcountry, Description = "Tuvalu" });
                        context.Country.Add(new Country() { Id = ++idcountry, Description = "Ugandax" });
                        context.Country.Add(new Country() { Id = ++idcountry, Description = "Ukraine" });
                        context.Country.Add(new Country() { Id = ++idcountry, Description = "United Arab Emirates" });
                        context.Country.Add(new Country() { Id = ++idcountry, Description = "United Kingdom" });
                        context.Country.Add(new Country() { Id = ++idcountry, Description = "United States" });
                        context.Country.Add(new Country() { Id = ++idcountry, Description = "Uruguay" });
                        context.Country.Add(new Country() { Id = ++idcountry, Description = "Uzbekistan" });
                        context.Country.Add(new Country() { Id = ++idcountry, Description = "Vanuatu" });
                        context.Country.Add(new Country() { Id = ++idcountry, Description = "Vatican City State" });
                        context.Country.Add(new Country() { Id = ++idcountry, Description = "Venezuela" });
                        context.Country.Add(new Country() { Id = ++idcountry, Description = "Vietnam" });
                        context.Country.Add(new Country() { Id = ++idcountry, Description = "Virgin Islands (British)" });
                        context.Country.Add(new Country() { Id = ++idcountry, Description = "Virgin Islands (U.S.)" });
                        context.Country.Add(new Country() { Id = ++idcountry, Description = "Wallis and Futuna Islands" });
                        context.Country.Add(new Country() { Id = ++idcountry, Description = "Western Sahara" });
                        context.Country.Add(new Country() { Id = ++idcountry, Description = "Yemen" });
                        context.Country.Add(new Country() { Id = ++idcountry, Description = "Zambia" });
                        context.Country.Add(new Country() { Id = ++idcountry, Description = "Zimbabwe" });

                    }

                    context.SaveChanges();
            }
        }

        // Entry point for the application.
        public static void Main(string[] args) => WebApplication.Run<Startup>(args);
    }
}
