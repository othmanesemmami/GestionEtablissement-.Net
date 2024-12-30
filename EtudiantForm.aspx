<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Gestion.master" CodeBehind="GestionEtablissementEtudiant.aspx.cs" Inherits="ThinkPad.GestionEtablissementEtudiant" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Gestion des Étudiants</title>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container mt-4">
        <h2 class="text-center text-primary mb-4">Gestion des Étudiants</h2>

        <!-- Tableau des Étudiants -->
        <div class="card shadow-sm mb-5">
            <div class="card-header bg-dark text-white">
                <h5 class="mb-0">Liste des Étudiants</h5>
            </div>
            <div class="card-body">
                <asp:GridView ID="GvEtudiant" runat="server" AutoGenerateColumns="False" CssClass="table table-striped table-hover" DataKeyNames="EtudiantId" OnSelectedIndexChanged="GvEtudiant_SelectedIndexChanged">
                    <Columns>
                        <asp:CommandField ShowSelectButton="True" SelectText="Sélectionner" />
                        <asp:BoundField DataField="EtudiantId" HeaderText="ID Étudiant" ReadOnly="True" />
                        <asp:BoundField DataField="Nom" HeaderText="Nom" />
                        <asp:BoundField DataField="Prenom" HeaderText="Prénom" />
                        <asp:BoundField DataField="Niveau" HeaderText="Niveau" />
                        <asp:BoundField DataField="Adress" HeaderText="Adresse" />
                        <asp:BoundField DataField="Filiere" HeaderText="Filière" />
                        <asp:BoundField DataField="EtablissementId" HeaderText="ID Établissement" />
                    </Columns>
                </asp:GridView>
            </div>
        </div>

        <!-- Formulaire de Gestion -->
        <div class="card shadow-sm">
            <div class="card-header bg-primary text-white">
                <h5 class="mb-0">Formulaire de Gestion</h5>
            </div>
            <div class="card-body">
                <!-- Message d'erreur ou de succès -->
                <asp:Label ID="LblMessage" runat="server" ForeColor="Red" CssClass="text-danger d-block mb-3" Visible="false"></asp:Label>

                <!-- Champs du formulaire -->
                <div class="mb-3">
                    <label for="TbEtudId" class="form-label">ID Étudiant :</label>
                    <asp:TextBox ID="TbEtudId" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
                </div>
                <div class="mb-3">
                    <label for="TbNom" class="form-label">Nom :</label>
                    <asp:TextBox ID="TbNom" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
                <div class="mb-3">
                    <label for="TbPrenom" class="form-label">Prénom :</label>
                    <asp:TextBox ID="TbPrenom" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
  
<div class="mb-3 d-flex align-items-center">
    <label for="RblNiveau" class="form-label me-3 mb-0">Niveau :</label>
    <asp:RadioButtonList ID="RblNiveau" runat="server" RepeatDirection="Horizontal" CssClass="form-check-inline">
        <asp:ListItem Text="1AP&nbsp;&nbsp;" Value="1AP" />
        <asp:ListItem Text="2AP&nbsp;&nbsp;" Value="2AP" />
        <asp:ListItem Text="3AI&nbsp;&nbsp;" Value="3AI" />
        <asp:ListItem Text="4AI&nbsp;&nbsp;" Value="4AI" />
        <asp:ListItem Text="5AI" Value="5AI" />
    </asp:RadioButtonList>
</div>



                <div class="mb-3">
                    <label for="DdlFiliere" class="form-label">Filière :</label>
                    <asp:DropDownList ID="DdlFiliere" runat="server" CssClass="form-select">
                        <asp:ListItem Text="Informatique" Value="Informatique" />
                        <asp:ListItem Text="Civile" Value="Civile" />
                        <asp:ListItem Text="Électrique" Value="Électrique" />
                        <asp:ListItem Text="Mécanique" Value="Mécanique" />
                        <asp:ListItem Text="Finance" Value="Finance" />
                        <asp:ListItem Text="Industriel" Value="Industriel" />
                    </asp:DropDownList>
                </div>
                <div class="mb-3">
                    <label for="TbAdress" class="form-label">Adresse :</label>
                    <asp:TextBox ID="TbAdress" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
                <div class="mb-3">
                    <label for="DdlEtablissement" class="form-label">ID Établissement :</label>
                    <asp:DropDownList ID="DdlEtablissement" runat="server" CssClass="form-select"></asp:DropDownList>
                </div>

                <!-- Boutons d'actions -->
                <div class="d-flex justify-content-between">
                    <asp:Button ID="BtAddEtudiant" runat="server" Text="Ajouter" CssClass="btn btn-success" OnClick="BtAddEtudiant_Click" />
                    <asp:Button ID="BtUpdateEtudiant" runat="server" Text="Modifier" CssClass="btn btn-warning" OnClick="BtUpdateEtudiant_Click" />
                    <asp:Button ID="BtDeleteEtudiant" runat="server" Text="Supprimer" CssClass="btn btn-danger" OnClick="BtDeleteEtudiant_Click" />
                </div>
            </div>
        </div>
    </div>
</asp:Content>
