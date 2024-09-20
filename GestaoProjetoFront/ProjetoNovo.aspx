<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ProjetoNovo.aspx.cs" Inherits="GestaoProjetoFront.ProjetoNovo" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Cadastrar Novo Projeto</title>
    <link href="https://stackpath.bootstrapcdn.com/bootstrap/4.3.1/css/bootstrap.min.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server" />

        <div class="container">
            <div>
                <h2>Cadastrar Novo Projeto</h2>
            </div>

            <div class="form-group">
                <label for="txtNome">Nome:</label>
                <asp:TextBox ID="txtNome" runat="server" CssClass="form-control" />
            </div>

            <div class="form-group">
                <label for="txtDescricao">Descrição:</label>
                <asp:TextBox ID="txtDescricao" runat="server" TextMode="MultiLine" CssClass="form-control" />
            </div>

            <div class="form-group">
                <div class="row">
                    <div class="col-md-6">
                        <label for="txtEquipeId">Equipe ID:</label>
                        <asp:TextBox ID="txtEquipeId" runat="server" CssClass="form-control" />
                    </div>
                    <div class="col-md-6">
                        <label for="ddlStatus">Status:</label>
                        <asp:DropDownList ID="ddlStatus" runat="server" CssClass="form-control">
                            <asp:ListItem Value="Em Andamento">Em Andamento</asp:ListItem>
                            <asp:ListItem Value="Concluído">Concluído</asp:ListItem>
                        </asp:DropDownList>
                    </div>
                </div>
            </div>

            <div class="form-group">
                <div class="row">
                    <div class="col-md-6">
                        <label for="txtDataInicio">Data de Início:</label>
                        <asp:TextBox ID="txtDataInicio" runat="server" TextMode="Date" CssClass="form-control" />
                        <ajaxToolkit:CalendarExtender ID="calDataInicioExtender" runat="server" TargetControlID="txtDataInicio" Format="yyyy-MM-dd" />
                    </div>
                    <div class="col-md-6">
                        <label for="txtDataFim">Data de Fim:</label>
                        <asp:TextBox ID="txtDataFim" runat="server" TextMode="Date" CssClass="form-control" />
                        <ajaxToolkit:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtDataFim" Format="yyyy-MM-dd" />
                    </div>
                </div>
            </div>

            <div class="form-group">
                <asp:Button ID="btnSalvar" runat="server" CssClass="btn btn-primary" Text="Cadastrar" OnClick="btnSalvar_Click" />
            </div>
        </div>
    </form>

    <script src="https://stackpath.bootstrapcdn.com/bootstrap/4.3.1/js/bootstrap.min.js"></script>
</body>
</html>
