using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlogProject.Models;

namespace BlogProject
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = CreateWebHostBuilder(args).Build();
            Dbinitializer();
            host.Run();
        }

        private static void Dbinitializer()
        {
            var myContext = new Context();
            if (!myContext.Posts.Any())
                myContext.Posts.Add(new Post
                {
                    Title = "Pair Programing",
                    Category = new Category()
                {
                        Title = "Programing"
                },
                    Comments = new List<Comment>()
                {
                    new Comment()
                    {
                       Body  = "Has been done!"
                    }
                }
                }
               );
            myContext.SaveChanges();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args)
        {
            return WebHost.CreateDefaultBuilder(args)
            .UseIISIntegration()
            .UseStartup<Startup>()
            .ConfigureLogging((hostingContext, logging) =>
            {
                logging.ClearProviders();
                logging.AddConfiguration(hostingContext.Configuration.GetSection("Logging"));
                logging.AddConsole();
                logging.AddDebug();
                logging.AddEventSourceLogger();
            });
        }


    }
}
