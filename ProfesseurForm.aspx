<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Gestion.master" CodeBehind="GestionProfesseur.aspx.cs" Inherits="ThinkPad.GestionProfesseur" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Gestion des Professeurs</title>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container mt-4">
        <h2 class="text-center text-primary mb-4">Gestion des Professeurs</h2>

        <!-- Section de Recherche -->
        <div class="card shadow-sm mb-5">
            <div class="card-header bg-dark text-white">
                <h5 class="mb-0">Recherche</h5>
            </div>
            <div class="card-body">
                <div class="d-flex align-items-center">
                    <label for="TbSearchNom" class="form-label me-3 mb-0">Recherche par Nom :</label>
                    <asp:TextBox ID="TbSearchNom" runat="server" CssClass="form-control me-3" Style="max-width: 300px;"></asp:TextBox>
                    <asp:Button ID="BtSearchProf" runat="server" Text="Rechercher" CssClass="btn btn-primary" OnClick="BtSearchProf_Click" />
                </div>
            </div>
        </div>

        <!-- Tableau des Professeurs -->
        <div class="card shadow-sm mb-5">
            <div class="card-header bg-primary text-white">
                <h5 class="mb-0">Liste des Professeurs</h5>
            </div>
            <div class="card-body">
                <asp:GridView ID="GvProfesseur" runat="server" AutoGenerateColumns="False" CssClass="table table-striped table-hover" DataKeyNames="ProfesseurId" OnSelectedIndexChanged="GvProfesseur_SelectedIndexChanged">
                    <Columns>
                        <asp:CommandField ShowSelectButton="True" SelectText="Sélectionner" />
                        <asp:BoundField DataField="ProfesseurId" HeaderText="ID Professeur" ReadOnly="True" />
                        <asp:BoundField DataField="Nom" HeaderText="Nom" />
                        <asp:BoundField DataField="Prenom" HeaderText="Prénom" />
                        <asp:BoundField DataField="Specialite" HeaderText="Spécialité" />
                        <asp:BoundField DataField="EtablissementId" HeaderText="ID Établissement" />
                    </Columns>
                </asp:GridView>
            </div>
        </div>

        <!-- Formulaire de Gestion -->
        <div class="card shadow-sm">
            <div class="card-header bg-secondary text-white">
                <h5 class="mb-0">Formulaire de Gestion</h5>
            </div>
            <div class="card-body">
                <!-- Label pour les messages -->
                <asp:Label ID="LblMessage" runat="server" ForeColor="Red" CssClass="text-danger d-block mb-3" Visible="false"></asp:Label>

                <!-- Champs du formulaire -->
                <div class="mb-3">
                    <label for="TbProfId" class="form-label">ID Professeur :</label>
                    <asp:TextBox ID="TbProfId" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
                </div>
                <div class="mb-3">
                    <label for="TbNomProf" class="form-label">Nom :</label>
                    <asp:TextBox ID="TbNomProf" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
                <div class="mb-3">
                    <label for="TbPrenomProf" class="form-label">Prénom :</label>
                    <asp:TextBox ID="TbPrenomProf" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
                <div class="mb-3">
                    <label for="TbSpecialite" class="form-label">Spécialité :</label>
                    <asp:TextBox ID="TbSpecialite" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
                <div class="mb-3">
                    <label for="DdlEtablissementProf" class="form-label">ID Établissement :</label>
                    <asp:DropDownList ID="DdlEtablissementProf" runat="server" CssClass="form-select"></asp:DropDownList>
                </div>

                <!-- Boutons d'actions -->
                <div class="d-flex justify-content-between">
                    <asp:Button ID="BtAddProf" runat="server" Text="Ajouter" CssClass="btn btn-success" OnClick="BtAddProf_Click" />
                    <asp:Button ID="BtUpdateProf" runat="server" Text="Modifier" CssClass="btn btn-warning" OnClick="BtUpdateProf_Click" />
                    <asp:Button ID="BtDeleteProf" runat="server" Text="Supprimer" CssClass="btn btn-danger" OnClick="BtDeleteProf_Click" />
                </div>
            </div>
        </div>
    </div>
</asp:Content>
