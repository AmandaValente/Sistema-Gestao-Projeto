<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="TarefaNovo.aspx.cs" Inherits="GestaoProjetoFront.TarefaNovo" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <link href="https://stackpath.bootstrapcdn.com/bootstrap/4.3.1/css/bootstrap.min.css" rel="stylesheet" />

    <div>
        <h1>Cadastrar Nova Tarefa</h1>

        <div class="form-group">
            <label for="txtNome">Nome da Tarefa:</label>
            <asp:TextBox ID="txtNome" runat="server" CssClass="form-control" />
        </div>

        <div class="form-group">
            <label for="txtDescricao">Descrição da tarefa:</label>
            <asp:TextBox ID="txtDescricao" runat="server" CssClass="form-control" />
        </div>

        <div class="form-group">
            <label for="txtProjetoId">ID do Projeto:</label>
            <asp:TextBox ID="txtProjetoId" runat="server" CssClass="form-control" />
        </div>
        <div class="form-group">
            <label for="txtResponsavelId">ID do Responsáve:</label>
            <asp:TextBox ID="txtResponsavelId" runat="server" CssClass="form-control" />
        </div>

        <div class="form-group">
            <div class="row">
                <div class="col-md-6">
                    <label for="txtDataInicio">Data de Início:</label>
                    <asp:TextBox ID="txtDataInicio" runat="server" TextMode="Date" CssClass="form-control" />
                    <ajaxToolkit:CalendarExtender ID="calDataInicioExtender" runat="server" TargetControlID="txtDataInicio" Format="yyyy-MM-dd" />
                </div>
                <div class="col-md-6">
                    <label for="txtDataFim">Data de Conclusão:</label>
                    <asp:TextBox ID="txtDataFim" runat="server" TextMode="Date" CssClass="form-control" />
                    <ajaxToolkit:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtDataFim" Format="yyyy-MM-dd" />
                </div>
            </div>
        </div>

        <div class="form-group">
            <div class="row">
                <div class="col-md-6">
                    <label for="ddlStatus">Status:</label>
                    <asp:DropDownList ID="ddlStatus" runat="server" CssClass="form-control">
                        <asp:ListItem Value="Em Andamento">Em Andamento</asp:ListItem>
                        <asp:ListItem Value="Concluído">Concluído</asp:ListItem>
                    </asp:DropDownList>
                </div>

                <div class="col-md-6">
                    <label for="ddlStatus">Prioridade:</label>
                    <asp:DropDownList ID="Prioridade" runat="server" CssClass="form-control">
                        <asp:ListItem Value="Alta">Alta Prioridade</asp:ListItem>
                        <asp:ListItem Value="Baixa">Baixa Prioridade</asp:ListItem>
                    </asp:DropDownList>
                </div>
                </div>
            </div>

                <div class="form-group">
                    <asp:Button ID="btnSalvar" runat="server" Text="Salvar" CssClass="btn btn-primary" OnClick="btnSalvar_Click" />
                </div>
            </div>
</asp:Content>
