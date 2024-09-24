<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="MembroNovo.aspx.cs" Inherits="GestaoProjetoFront.MembroNovo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <link href="https://stackpath.bootstrapcdn.com/bootstrap/4.3.1/css/bootstrap.min.css" rel="stylesheet" />

    <div>
        <h1>Cadastrar Novo Membro da Equipe</h1>

        <div class="form-group">
            <label for="txtNome">Nome:</label>
            <asp:TextBox ID="txtNome" runat="server" CssClass="form-control" />
        </div>

        <div class="form-group">
            <label for="txtEmail">Email:</label>
            <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control" />
        </div>

        <div class="form-group">
            <label for="txtEquipeId">ID da Equipe:</label>
            <asp:TextBox ID="txtEquipeId" runat="server" CssClass="form-control" />
        </div>

        <div class="form-group">
            <asp:Button ID="btnSalvar" runat="server" Text="Salvar" CssClass="btn btn-primary" OnClick="btnSalvar_Click" />
        </div>

    </div>

</asp:Content>
