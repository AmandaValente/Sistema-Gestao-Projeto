<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ProjetoInicio.aspx.cs" Inherits="GestaoProjetoFront.Views.Projetos.ProjetoInicio" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <script type="text/javascript">
        function confirmarExclusao() {
            return confirm('Você realmente deseja excluir este projeto?');
        }
    </script>
  
        <div class="container">
            <div>
                <h1>Pesquisar Projeto</h1>
            </div>
            <div class="form-group">
                <label for="txtId">ID:</label>
                <asp:TextBox ID="txtId" runat="server" MaxLength="10" CssClass="form-control"></asp:TextBox>
                <label for="txtNome">Nome:</label>
                <asp:TextBox ID="txtNome" runat="server" MaxLength="50" CssClass="form-control"></asp:TextBox>
            </div>
            <br />
            <br />
            <div class="form-group">
                <asp:Button ID="btnPesquisar" runat="server" CssClass="btn btn-primary" OnClick="BtnPesquisar_Click" Text="Pesquisar" />
                <asp:Button ID="btnNovo" runat="server" CssClass="btn btn-secondary" OnClick="BtnNovo_Click" Text="Novo Projeto" />
            </div><br /><br />
            <asp:GridView ID="gvProjeto" runat="server" AutoGenerateColumns="False" Width="100%" 
                          CssClass="table table-bordered table-striped table-hover" GridLines="None">
                <Columns>
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:Button ID="btnAtualizar" runat="server" ToolTip="Atualizar" Text="Atualizar" CssClass="btn btn-primary"
                                CausesValidation="false" CommandName="atualizar" OnClick="BtnAtualizar_Click"
                                CommandArgument='<%# Eval("ProjetoId") %>' />
                            <asp:Button ID="btnExcluir" runat="server" ToolTip="Excluir" Text="Excluir" CssClass="btn btn-danger"
                                CausesValidation="false" CommandName="excluir" OnClick="BtnExcluir_Click"
                               CommandArgument='<%# Eval("ProjetoId") %>' OnClientClick="return confirmarExclusao();" />

                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="ProjetoId" HeaderText="ID" />
                    <asp:BoundField DataField="Nome" HeaderText="Nome" />
                    <asp:BoundField DataField="Descricao" HeaderText="Descrição" />
                    <asp:BoundField DataField="DataInicio" HeaderText="Data Início" DataFormatString="{0:d}" />
                    <asp:BoundField DataField="DataFim" HeaderText="Data Fim" DataFormatString="{0:d}" />
                    <asp:BoundField DataField="StatusProjeto" HeaderText="Status" />
                    <asp:BoundField DataField="EquipeId" HeaderText="Equipe ID" />
                </Columns>
            </asp:GridView>
        </div>

</asp:Content>