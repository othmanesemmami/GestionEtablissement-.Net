using System;
using System.Linq;
using System.Web.UI.WebControls;
using ThinkPad.Models; // Importer les modèles du projet

namespace ThinkPad
{
    public partial class GestionEtablissement : System.Web.UI.Page
    {
        private DbEtudiantContext dbEtudiant = new DbEtudiantContext(); // Context EF pour la gestion des établissements

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Charger les données lors du chargement initial de la page
                LoadEtablissements();
            }
        }

        // Charger les établissements dans le GridView
        private void LoadEtablissements()
        {
            GvEtablissement.DataSource = dbEtudiant.Etablissement.ToList();
            GvEtablissement.DataBind();
        }

        // Vérification du champ ID
        private bool IsIdValid()
        {
            if (string.IsNullOrWhiteSpace(TbEtabId.Text))
            {
                LblMessage.Text = "L'ID de l'établissement est requis.";
                LblMessage.Visible = true;
                return false;
            }

            return true;
        }

        // Ajouter un nouvel établissement
        protected void BtAddEtab_Click(object sender, EventArgs e)
        {
            // Cette action ne nécessite pas de vérification de l'ID
            try
            {
                var etablissement = new Etablissement
                {
                    Nom = TbNomEtab.Text.Trim(),
                    Location = TbLocation.Text.Trim()
                };

                dbEtudiant.Etablissement.Add(etablissement);
                dbEtudiant.SaveChanges();

                // Recharger les données et nettoyer le formulaire
                LoadEtablissements();
                ClearEtabForm();
                LblMessage.Visible = false; // Masquer le message après l'ajout
            }
            catch (Exception ex)
            {
                LblMessage.Text = "Erreur lors de l'ajout : " + ex.Message;
                LblMessage.Visible = true;
            }
        }

        // Modifier un établissement existant
        protected void BtUpdateEtab_Click(object sender, EventArgs e)
        {
            if (IsIdValid()) // Vérifier si l'ID est valide
            {
                try
                {
                    int id = int.Parse(TbEtabId.Text); // Récupérer l'identifiant à modifier
                    var etablissement = dbEtudiant.Etablissement.Find(id);

                    if (etablissement != null)
                    {
                        etablissement.Nom = TbNomEtab.Text.Trim();
                        etablissement.Location = TbLocation.Text.Trim();
                        dbEtudiant.SaveChanges();

                        // Recharger les données et nettoyer le formulaire
                        LoadEtablissements();
                        ClearEtabForm();
                        LblMessage.Visible = false; // Masquer le message après la mise à jour
                    }
                    else
                    {
                        LblMessage.Text = "Établissement non trouvé.";
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

        // Supprimer un établissement
        protected void BtDeleteEtab_Click(object sender, EventArgs e)
        {
            if (IsIdValid()) // Vérifier si l'ID est valide
            {
                try
                {
                    int id = int.Parse(TbEtabId.Text);
                    var etablissement = dbEtudiant.Etablissement.Find(id);

                    if (etablissement != null)
                    {
                        dbEtudiant.Etablissement.Remove(etablissement);
                        dbEtudiant.SaveChanges();

                        // Recharger les données et nettoyer le formulaire
                        LoadEtablissements();
                        ClearEtabForm();
                        LblMessage.Visible = false; // Masquer le message après la suppression
                    }
                    else
                    {
                        LblMessage.Text = "Établissement non trouvé.";
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

        // Sélectionner un établissement dans le GridView
        protected void GvEtablissement_SelectedIndexChanged(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(GvEtablissement.SelectedDataKey.Value); // Récupérer l'ID sélectionné
            var etablissement = dbEtudiant.Etablissement.Find(id);

            if (etablissement != null)
            {
                TbEtabId.Text = etablissement.EtablissementId.ToString();
                TbNomEtab.Text = etablissement.Nom;
                TbLocation.Text = etablissement.Location;
            }
        }

        // Nettoyer les champs du formulaire d'établissement
        private void ClearEtabForm()
        {
            TbEtabId.Text = "";
            TbNomEtab.Text = "";
            TbLocation.Text = "";
        }
    }
}
