using System;
using System.Linq;
using System.Web.UI.WebControls;
using ThinkPad.Models; // Importer les entités et le contexte

namespace ThinkPad
{
    public partial class GestionProfesseur : System.Web.UI.Page
    {
        // Contexte Entity Framework pour la base de données des professeurs
        private DbProfesseurContext dbProfesseur = new DbProfesseurContext();
        private DbEtudiantContext dbEtudiant = new DbEtudiantContext(); // Utilisé pour charger les établissements

        // Méthode exécutée lors du chargement de la page
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadProfesseurs();
                LoadEtablissements();
            }
        }

        // Charger les professeurs dans le GridView
        private void LoadProfesseurs()
        {
            GvProfesseur.DataSource = dbProfesseur.Professeur.ToList();
            GvProfesseur.DataBind();
        }

        // Charger les établissements dans le DropDownList
        private void LoadEtablissements()
        {
            var etablissements = dbEtudiant.Etablissement.Select(e => new { e.EtablissementId, e.Nom }).ToList();

            DdlEtablissementProf.DataSource = etablissements;
            DdlEtablissementProf.DataTextField = "Nom";
            DdlEtablissementProf.DataValueField = "EtablissementId";
            DdlEtablissementProf.DataBind();

            DdlEtablissementProf.Items.Insert(0, new ListItem("-- Sélectionner --", "0"));
        }

        // Fonctionnalité de recherche par nom
        protected void BtSearchProf_Click(object sender, EventArgs e)
        {
            string searchNom = TbSearchNom.Text.Trim();

            var professeurs = dbProfesseur.Professeur
                                          .Where(p => p.Nom.Contains(searchNom))
                                          .ToList();

            GvProfesseur.DataSource = professeurs;
            GvProfesseur.DataBind();
        }

        // Ajouter un professeur
        protected void BtAddProf_Click(object sender, EventArgs e)
        {
            if (IsEtablissementIdValid())
            {
                try
                {
                    var professeur = new Professeur
                    {
                        Nom = TbNomProf.Text,
                        Prenom = TbPrenomProf.Text,
                        Specialite = TbSpecialite.Text,
                        EtablissementId = int.Parse(DdlEtablissementProf.SelectedValue)
                    };

                    dbProfesseur.Professeur.Add(professeur);
                    dbProfesseur.SaveChanges();

                    LoadProfesseurs();
                    ClearForm();
                    LblMessage.Visible = false;
                }
                catch (Exception ex)
                {
                    LblMessage.Text = "Erreur lors de l'ajout : " + ex.Message;
                    LblMessage.Visible = true;
                }
            }
        }

        // Modifier un professeur
        protected void BtUpdateProf_Click(object sender, EventArgs e)
        {
            if (IsProfIdValid() && IsEtablissementIdValid())
            {
                try
                {
                    int id = int.Parse(TbProfId.Text);
                    var professeur = dbProfesseur.Professeur.Find(id);

                    if (professeur != null)
                    {
                        professeur.Nom = TbNomProf.Text;
                        professeur.Prenom = TbPrenomProf.Text;
                        professeur.Specialite = TbSpecialite.Text;
                        professeur.EtablissementId = int.Parse(DdlEtablissementProf.SelectedValue);

                        dbProfesseur.SaveChanges();

                        LoadProfesseurs();
                        ClearForm();
                        LblMessage.Visible = false;
                    }
                    else
                    {
                        LblMessage.Text = "Professeur non trouvé.";
                        LblMessage.Visible = true;
                    }
                }
                catch (Exception ex)
                {
                    LblMessage.Text = "Erreur lors de la modification : " + ex.Message;
                    LblMessage.Visible = true;
                }
            }
        }

        // Supprimer un professeur
        protected void BtDeleteProf_Click(object sender, EventArgs e)
        {
            if (IsProfIdValid())
            {
                try
                {
                    int id = int.Parse(TbProfId.Text);
                    var professeur = dbProfesseur.Professeur.Find(id);

                    if (professeur != null)
                    {
                        dbProfesseur.Professeur.Remove(professeur);
                        dbProfesseur.SaveChanges();

                        LoadProfesseurs();
                        ClearForm();
                        LblMessage.Visible = false;
                    }
                    else
                    {
                        LblMessage.Text = "Professeur non trouvé.";
                        LblMessage.Visible = true;
                    }
                }
                catch (Exception ex)
                {
                    LblMessage.Text = "Erreur lors de la suppression : " + ex.Message;
                    LblMessage.Visible = true;
                }
            }
        }

        // Vérification de l'ID Professeur
        private bool IsProfIdValid()
        {
            if (string.IsNullOrWhiteSpace(TbProfId.Text))
            {
                LblMessage.Text = "L'ID du professeur est requis.";
                LblMessage.Visible = true;
                return false;
            }
            return true;
        }

        // Vérification de l'ID Établissement
        private bool IsEtablissementIdValid()
        {
            if (string.IsNullOrWhiteSpace(DdlEtablissementProf.SelectedValue) || DdlEtablissementProf.SelectedValue == "0")
            {
                LblMessage.Text = "L'ID de l'établissement est requis.";
                LblMessage.Visible = true;
                return false;
            }
            return true;
        }

        // Sélectionner un professeur depuis le GridView
        protected void GvProfesseur_SelectedIndexChanged(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(GvProfesseur.SelectedDataKey.Value);
            var professeur = dbProfesseur.Professeur.Find(id);

            if (professeur != null)
            {
                TbProfId.Text = professeur.ProfesseurId.ToString();
                TbNomProf.Text = professeur.Nom;
                TbPrenomProf.Text = professeur.Prenom;
                TbSpecialite.Text = professeur.Specialite;
                DdlEtablissementProf.SelectedValue = professeur.EtablissementId.ToString();
            }
        }

        // Réinitialiser le formulaire
        private void ClearForm()
        {
            TbProfId.Text = "";
            TbNomProf.Text = "";
            TbPrenomProf.Text = "";
            TbSpecialite.Text = "";
            DdlEtablissementProf.SelectedIndex = 0;
        }
    }
}
