<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="MembroAtualiza.aspx.cs" Inherits="GestaoProjetoFront.MembroAtualiza" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <link href="https://stackpath.bootstrapcdn.com/bootstrap/4.3.1/css/bootstrap.min.css" rel="stylesheet" />



    <h1>Atualizar Membro da Equipe</h1>

    <asp:HiddenField ID="MembroId" runat="server" />

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

</asp:Content>
