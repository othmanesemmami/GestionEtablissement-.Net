<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Gestion.master" CodeBehind="GestionEtablissement.aspx.cs" Inherits="ThinkPad.GestionEtablissement" %>

<asp:Content ID="ContentPlaceHolder1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container mt-4">
        <h2 class="text-center text-primary mb-4">Gestion des Établissements</h2>

        <!-- Tableau des Établissements -->
        <div class="card shadow-sm mb-5">
            <div class="card-header bg-dark text-white">
                <h5 class="mb-0">Liste des Établissements</h5>
            </div>
            <div class="card-body">
                <asp:GridView ID="GvEtablissement" runat="server" AutoGenerateColumns="False" CssClass="table table-striped table-hover" DataKeyNames="EtablissementId" OnSelectedIndexChanged="GvEtablissement_SelectedIndexChanged">
                    <Columns>
                        <asp:CommandField ShowSelectButton="True" SelectText="Sélectionner" />
                        <asp:BoundField DataField="EtablissementId" HeaderText="ID Établissement" ReadOnly="True" />
                        <asp:BoundField DataField="Nom" HeaderText="Nom de l'Établissement" />
                        <asp:BoundField DataField="Location" HeaderText="Localisation" />
                    </Columns>
                </asp:GridView>
            </div>
        </div>

        <!-- Formulaire de Gestion -->
        <div class="card shadow-sm">
            <div class="card-header bg-primary text-white">
                <h5 class="mb-0">Formulaire d'Établissement</h5>
            </div>
            <div class="card-body">
                <!-- Label pour les messages -->
                <asp:Label ID="LblMessage" runat="server" CssClass="text-danger mb-3 d-block" Visible="false"></asp:Label>

                <!-- Champs du Formulaire -->
                <div class="mb-3">
                    <label for="TbEtabId" class="form-label">ID Établissement :</label>
                    <asp:TextBox ID="TbEtabId" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
                </div>
                <div class="mb-3">
                    <label for="TbNomEtab" class="form-label">Nom :</label>
                    <asp:TextBox ID="TbNomEtab" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
                <div class="mb-3">
                    <label for="TbLocation" class="form-label">Localisation :</label>
                    <asp:TextBox ID="TbLocation" runat="server" CssClass="form-control"></asp:TextBox>
                </div>

                <!-- Boutons d'Actions -->
                <div class="d-flex justify-content-between">
                    <asp:Button ID="BtAddEtab" runat="server" Text="Ajouter" CssClass="btn btn-success" OnClick="BtAddEtab_Click" />
                    <asp:Button ID="BtUpdateEtab" runat="server" Text="Modifier" CssClass="btn btn-warning" OnClick="BtUpdateEtab_Click" />
                    <asp:Button ID="BtDeleteEtab" runat="server" Text="Supprimer" CssClass="btn btn-danger" OnClick="BtDeleteEtab_Click" />
                </div>
            </div>
        </div>
    </div>
</asp:Content>
