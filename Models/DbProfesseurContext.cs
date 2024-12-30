using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ThinkPad.Models
{
    public class DbProfesseurContext : DbContext
    {
        public DbProfesseurContext(): base("name=Gestion") { }

         public DbSet<Professeur> Professeur { get; set; }
        public DbSet<Etablissement> Etablissement { get; set; }
    }
}