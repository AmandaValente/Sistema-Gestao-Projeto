<%@ Page Language="C#"  MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EquipesInicio.aspx.cs" Inherits="GestaoProjetoFront.EquipesInicio" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <script type="text/javascript">
        function confirmarExclusao() {
            return confirm('Você realmente deseja excluir esta Equipe?');
        }
    </script>
  
        <div class="container">
            <div>
                <h1>Gerenciar Equipe</h1>
            </div>
            <div class="form-group">
                <label for="txtId">ID Equipe:</label>
                <asp:TextBox ID="txtId" runat="server" MaxLength="10" CssClass="form-control"></asp:TextBox>
                <label for="txtNome">Nome da equipe:</label>
                <asp:TextBox ID="txtNome" runat="server" MaxLength="50" CssClass="form-control"></asp:TextBox>
            </div>
            <br />
            <br />
            <div class="form-group">
                <asp:Button ID="btnPesquisar" runat="server" CssClass="btn btn-primary" OnClick="BtnPesquisar_Click" Text="Pesquisar" />
                <asp:Button ID="btnNovo" runat="server" CssClass="btn btn-secondary" OnClick="BtnNovo_Click" Text="Nova equipe" />
            </div><br /><br />
            <asp:GridView ID="gvEquipe" runat="server" AutoGenerateColumns="False" Width="100%" 
                          CssClass="table table-bordered table-striped table-hover" GridLines="None">
                <Columns>
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:Button ID="btnAtualizar" runat="server" ToolTip="Atualizar" Text="Atualizar" CssClass="btn btn-primary"
                                CausesValidation="false" CommandName="atualizar" OnClick="BtnAtualizar_Click"
                                CommandArgument='<%# Eval("EquipeId") %>'/>
                            <asp:Button ID="btnExcluir" runat="server" ToolTip="Excluir" Text="Excluir" CssClass="btn btn-danger"
                                CausesValidation="false" CommandName="excluir" OnClick="BtnExcluir_Click"
                               CommandArgument='<%# Eval("EquipeId") %>' OnClientClick="return confirmarExclusao();" />

                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="EquipeId" HeaderText="ID Equipe" />
                    <asp:BoundField DataField="Nome" HeaderText="Nome" />
                    
                </Columns>
            </asp:GridView>
        </div>

</asp:Content>