using System;
using System.Linq;
using System.Web.UI.WebControls;
using ThinkPad.Models; // Importer les entités et le contexte

namespace ThinkPad
{
    public partial class GestionEtablissementEtudiant : System.Web.UI.Page
    {
        // Contextes Entity Framework pour les bases de données
        private DbEtudiantContext dbEtudiant = new DbEtudiantContext();
        private DbProfesseurContext dbProfesseur = new DbProfesseurContext();

        // Méthode exécutée au chargement de la page
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Charger les données au démarrage
                LoadEtudiants();
                LoadEtablissementDropdowns();
            }
        }

        // Charger les étudiants dans le GridView
        private void LoadEtudiants()
        {
            GvEtudiant.DataSource = dbEtudiant.Etudiant.ToList();
            GvEtudiant.DataBind();
        }

        // Charger les établissements dans les DropdownLists (liés aux étudiants/professeurs)
        private void LoadEtablissementDropdowns()
        {
            var etablissements = dbEtudiant.Etablissement.Select(e => new { e.EtablissementId, e.Nom }).ToList();

            // Dropdown pour les étudiants
            DdlEtablissement.DataSource = etablissements;
            DdlEtablissement.DataTextField = "Nom";
            DdlEtablissement.DataValueField = "EtablissementId";
            DdlEtablissement.DataBind();
            DdlEtablissement.Items.Insert(0, new ListItem("-- Sélectionner --", "0"));
        }

        // Vérification de l'ID de l'étudiant
        private bool IsIdValid()
        {
            if (string.IsNullOrWhiteSpace(TbEtudId.Text))
            {
                LblMessage.Text = "L'ID de l'étudiant est requis.";
                LblMessage.Visible = true;
                return false;
            }
            return true;
        }

        // Vérification de l'ID de l'établissement
        private bool IsEtablissementIdValid()
        {
            if (string.IsNullOrWhiteSpace(DdlEtablissement.SelectedValue) || DdlEtablissement.SelectedValue == "0")
            {
                LblMessage.Text = "L'ID de l'établissement est requis.";
                LblMessage.Visible = true;
                return false;
            }
            return true;
        }

        // Ajouter un étudiant
        protected void BtAddEtudiant_Click(object sender, EventArgs e)
        {
            if (IsEtablissementIdValid()) // Vérifier si l'ID de l'établissement est valide
            {
                try
                {
                    var etudiant = new Etudiant
                    {
                        Nom = TbNom.Text,
                        Prenom = TbPrenom.Text,
                        Niveau = RblNiveau.SelectedValue,
                        Filiere = DdlFiliere.SelectedValue,
                        Adress = TbAdress.Text,
                        EtablissementId = int.Parse(DdlEtablissement.SelectedValue)
                    };

                    dbEtudiant.Etudiant.Add(etudiant);
                    dbEtudiant.SaveChanges();

                    LoadEtudiants();
                    ClearEtudForm();
                    LblMessage.Visible = false; // Masquer le message après l'ajout
                }
                catch (Exception ex)
                {
                    LblMessage.Text = "Erreur lors de l'ajout : " + ex.Message;
                    LblMessage.Visible = true;
                }
            }
        }

        // Modifier un étudiant
        protected void BtUpdateEtudiant_Click(object sender, EventArgs e)
        {
            if (IsIdValid() && IsEtablissementIdValid()) // Vérifier si l'ID est valide et l'ID établissement est valide
            {
                try
                {
                    int id = int.Parse(TbEtudId.Text);
                    var etudiant = dbEtudiant.Etudiant.Find(id);

                    if (etudiant != null)
                    {
                        etudiant.Nom = TbNom.Text;
                        etudiant.Prenom = TbPrenom.Text;
                        etudiant.Niveau = RblNiveau.SelectedValue;
                        etudiant.Filiere = DdlFiliere.SelectedValue;
                        etudiant.Adress = TbAdress.Text;
                        etudiant.EtablissementId = int.Parse(DdlEtablissement.SelectedValue);

                        dbEtudiant.SaveChanges();

                        LoadEtudiants();
                        ClearEtudForm();
                        LblMessage.Visible = false; // Masquer le message après la mise à jour
                    }
                    else
                    {
                        LblMessage.Text = "Étudiant non trouvé.";
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

        // Supprimer un étudiant
        protected void BtDeleteEtudiant_Click(object sender, EventArgs e)
        {
            if (IsIdValid()) // Vérifier si l'ID de l'étudiant est valide
            {
                try
                {
                    int id = int.Parse(TbEtudId.Text);
                    var etudiant = dbEtudiant.Etudiant.Find(id);

                    if (etudiant != null)
                    {
                        dbEtudiant.Etudiant.Remove(etudiant);
                        dbEtudiant.SaveChanges();

                        LoadEtudiants();
                        ClearEtudForm();
                        LblMessage.Visible = false; // Masquer le message après la suppression
                    }
                    else
                    {
                        LblMessage.Text = "Étudiant non trouvé.";
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

        // Sélectionner un étudiant depuis le GridView
        protected void GvEtudiant_SelectedIndexChanged(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(GvEtudiant.SelectedDataKey.Value);
            var etudiant = dbEtudiant.Etudiant.Find(id);

            if (etudiant != null)
            {
                TbEtudId.Text = etudiant.EtudiantId.ToString();
                TbNom.Text = etudiant.Nom;
                TbPrenom.Text = etudiant.Prenom;
                RblNiveau.SelectedValue = etudiant.Niveau;
                DdlFiliere.SelectedValue = etudiant.Filiere;
                TbAdress.Text = etudiant.Adress;
                DdlEtablissement.SelectedValue = etudiant.EtablissementId.ToString();
            }
        }

        private void ClearEtudForm()
        {
            TbEtudId.Text = "";
            TbNom.Text = "";
            TbPrenom.Text = "";
            RblNiveau.SelectedValue = "";
            DdlFiliere.SelectedValue = "";
            TbAdress.Text = "";
            DdlEtablissement.SelectedIndex = 0;
        }
    }
}
