using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Esport.Models;

namespace Esport.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        //public DbSet<Competition> Competition { get; set; }

        public DbSet<CompoEquipe> CompoEquipe { get; set; }

        public DbSet<Equipe> Equipe { get; set; }

        public DbSet<Licencie> Licencie { get; set; }

        public DbSet<Personnel> Personnel { get; set; }

        public DbSet<Esport.Models.Jeu> Jeu { get; set; }

        public DbSet<Esport.Models.Competition> Competition { get; set; }

    }
}
