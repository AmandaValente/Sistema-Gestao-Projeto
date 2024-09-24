<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="EquipeNovo.aspx.cs" Inherits="GestaoProjetoFront.EquipeNovo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <link href="https://stackpath.bootstrapcdn.com/bootstrap/4.3.1/css/bootstrap.min.css" rel="stylesheet" />

    <div>
        <h1>Cadastrar Nova Equipe</h1>

        <div class="form-group">
            <label for="txtNome">Nome:</label>
            <asp:TextBox ID="txtNome" runat="server" CssClass="form-control" />
        </div>


        <div class="form-group">
            <asp:Button ID="btnSalvar" runat="server" Text="Salvar" CssClass="btn btn-primary" OnClick="btnSalvar_Click" />
        </div>

    </div>

</asp:Content>
