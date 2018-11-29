using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using CodeAFriend.Core;
using CodeAFriend.Facade;
using CodeAFriend.Languages.Core;
using CodeAFriend.Repository;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Swagger;

namespace CodeAFriend.ApiService
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
			services.Configure<CookiePolicyOptions>(options =>
			{
				// This lambda determines whether user consent for non-essential cookies is needed for a given request.
				options.CheckConsentNeeded = context => true;
				options.MinimumSameSitePolicy = SameSiteMode.None;
			});

			services.AddDbContext<CodeAFriendContext>();
			services.AddScoped<ICodeAFriendFacade, CodeAFriend.Facade.CodeAFriendFacade>();
			services.AddScoped<IInterpreterFactory, InterpreterFactory>();


			services.AddSwaggerGen(c =>
			{
				c.SwaggerDoc("v1", new Info { Title = "CodeAFriend API", Version = "v1", Description = "REST API to Manage CodeAFriend data" });


				c.CustomSchemaIds(x => x.FullName);

				c.DescribeAllEnumsAsStrings();

				try
				{
					c.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, $"{typeof(Program).Assembly.FullName.UpToFirst(',')}.xml"));
					c.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, $"{typeof(DataModel.User).Assembly.FullName.UpToFirst(',')}.xml"));
				}
				catch (FileNotFoundException)
				{
					// not finding xml files sucks but is not a critical problem.
				}
			});

			services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IHostingEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}
			else
			{
			}


			app.UseMvc(routes =>
			{
	
			});

			app.UseSwagger();
			app.UseSwaggerUI(c =>
			{
				c.SwaggerEndpoint("v1/swagger.json", "CodeAFriend API v1");
				//c.DocExpansion("none");
			});
		}
	}
}
