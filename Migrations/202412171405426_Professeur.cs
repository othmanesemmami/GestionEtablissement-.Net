namespace ThinkPad.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Professeur : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Etablissements",
                c => new
                    {
                        EtablissementId = c.Int(nullable: false, identity: true),
                        Nom = c.String(),
                        Location = c.String(),
                    })
                .PrimaryKey(t => t.EtablissementId);
            
            CreateTable(
                "dbo.Etudiants",
                c => new
                    {
                        EtudiantId = c.Int(nullable: false, identity: true),
                        Nom = c.String(),
                        Prenom = c.String(),
                        Niveau = c.String(),
                        Filiere = c.String(),
                        Adress = c.String(),
                        EtablissementId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.EtudiantId)
                .ForeignKey("dbo.Etablissements", t => t.EtablissementId, cascadeDelete: true)
                .Index(t => t.EtablissementId);
            
            CreateTable(
                "dbo.Professeurs",
                c => new
                    {
                        ProfesseurId = c.Int(nullable: false, identity: true),
                        Nom = c.String(),
                        Prenom = c.String(),
                        Specialite = c.String(),
                        EtablissementId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ProfesseurId)
                .ForeignKey("dbo.Etablissements", t => t.EtablissementId, cascadeDelete: true)
                .Index(t => t.EtablissementId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Professeurs", "EtablissementId", "dbo.Etablissements");
            DropForeignKey("dbo.Etudiants", "EtablissementId", "dbo.Etablissements");
            DropIndex("dbo.Professeurs", new[] { "EtablissementId" });
            DropIndex("dbo.Etudiants", new[] { "EtablissementId" });
            DropTable("dbo.Professeurs");
            DropTable("dbo.Etudiants");
            DropTable("dbo.Etablissements");
        }
    }
}
