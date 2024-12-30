using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ThinkPad.Models
{
    public class DbEtudiantContext : DbContext
    {
        public DbEtudiantContext(): base("name=Gestion"){ }
        public DbSet<Etudiant> Etudiant { get; set; }
        public DbSet<Etablissement> Etablissement { get; set; }
    }
}