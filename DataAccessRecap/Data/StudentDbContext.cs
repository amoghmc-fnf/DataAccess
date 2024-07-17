using DataAccessRecap.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessRecap.Data
{
    public class StudentDbContext : DbContext
    {
        public DbSet<Student> Students { get; set; }
        public IConfiguration Configuration { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            ConfigurationServices();

            var connectionString = Configuration["connectionString"];
            if (connectionString == null)
                throw new ApplicationException("Could not read from the configuration file");
            optionsBuilder.UseSqlServer(connectionString);

        }

        private void ConfigurationServices()
        {
            var config = new ConfigurationBuilder()
                            .SetBasePath("C:\\Users\\6147952\\source\\repos\\DataAccessRecap\\DataAccessRecap")
                            .AddJsonFile("appsettings.json", false)
                            .Build();
            if (Configuration == null)
                Configuration = config;
        }
    }
}
