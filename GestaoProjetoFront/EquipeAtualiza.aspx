<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="EquipeAtualiza.aspx.cs" Inherits="GestaoProjetoFront.EquipeAtualiza" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <link href="https://stackpath.bootstrapcdn.com/bootstrap/4.3.1/css/bootstrap.min.css" rel="stylesheet" />

    <div class="container">
        <div>
            <h2>Atualizar Equipe</h2>
        </div>

        <asp:HiddenField ID="idequipe" runat="server" Value="" />

        <div class="form-group">

            <label for="txtNome">Nome da Equipe:</label>
            <asp:TextBox ID="txtNome" runat="server" CssClass="form-control" />
        </div>

        <div class="form-group">
            <asp:Button ID="btnSalvar" runat="server" CssClass="btn btn-primary" Text="Salvar" OnClick="btnSalvar_Click" />
        </div>

        <div>
            
            <!-- GridView para exibir os membros da equipe selecionada -->
            <h4>Membros Cadastrados:</h4>
            <asp:GridView ID="gvMembros" runat="server" AutoGenerateColumns="False" Width="100%"
                CssClass="table table-bordered table-striped table-hover" GridLines="None">
                <Columns>
                    <asp:BoundField DataField="MembroId" HeaderText="ID Membro" />
                    <asp:BoundField DataField="Nome" HeaderText="Nome" />
                    <asp:BoundField DataField="Email" HeaderText="Email" />

                    <asp:TemplateField HeaderText="Ações">
                        <ItemTemplate>
                            <asp:Button ID="btnAtualizar" runat="server" Text="Atualizar"
                                CssClass="btn btn-warning" OnClick="btnAtualizar_Click"
                                CommandArgument='<%# Eval("MembroId") %>' PostBackUrl='<%# "MembroAtualiza.aspx?MembroId=" + Eval("MembroId") %>' />

                            <asp:Button ID="btnExcluir" runat="server" Text="Excluir"
                                CssClass="btn btn-danger" OnClick="btnExcluir_Click"
                                CommandArgument='<%# Eval("MembroId") %>'
                                OnClientClick="return confirmarExclusao();" />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>

            <div class="form-group">
                <asp:Button ID="btnNovoMembro" runat="server" CssClass="btn btn-secondary" Text="Adicionar Novo Membro" OnClick="btnNovoMembro_Click"/>
            </div>
        </div>

    </div>
    <script src="https://stackpath.bootstrapcdn.com/bootstrap/4.3.1/js/bootstrap.min.js"></script>

</asp:Content>
