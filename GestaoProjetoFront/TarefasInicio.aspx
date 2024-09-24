<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="TarefasInicio.aspx.cs" Inherits="GestaoProjetoFront.TarefasInicio" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <script type="text/javascript">
        function confirmarExclusao() {
            return confirm('Você realmente deseja excluir esta tarefa?');
        }
    </script>

    <div class="container">
        <div>
            <h1>Gerenciar Tarefa</h1>
        </div>
        <div class="form-group">
            <label for="txtId">ID da Tarefa:</label>
            <asp:TextBox ID="txtId" runat="server" MaxLength="10" CssClass="form-control"></asp:TextBox>
        </div>
        <br />
        <br />
        <div class="form-group">
            <asp:Button ID="btnPesquisar" runat="server" CssClass="btn btn-primary" OnClick="BtnPesquisar_Click" Text="Pesquisar" />
            <asp:Button ID="btnNovo" runat="server" CssClass="btn btn-secondary" OnClick="BtnNovo_Click" Text="Nova Tarefa" />
        </div>
        <br />
        <br />
        <asp:GridView ID="gvTarefas" runat="server" AutoGenerateColumns="False" Width="100%"
            CssClass="table table-bordered table-striped table-hover" GridLines="None">
            <Columns>
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:Button ID="btnAtualizar" runat="server" ToolTip="Atualizar" Text="Atualizar" CssClass="btn btn-primary"
                            CausesValidation="false" CommandName="atualizar" OnClick="BtnAtualizar_Click"
                            CommandArgument='<%# Eval("TarefaId") %>' PostBackUrl='<%# "TarefaAtualiza.aspx?TarefaId=" + Eval("TarefaId") %>' />
                        <asp:Button ID="btnExcluir" runat="server" ToolTip="Excluir" Text="Excluir" CssClass="btn btn-danger"
                            CausesValidation="false" CommandName="excluir" OnClick="BtnExcluir_Click"
                            CommandArgument='<%# Eval("TarefaId") %>' OnClientClick="return confirmarExclusao();" />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="TarefaId" HeaderText="ID" />
                <asp:BoundField DataField="Nome" HeaderText="Nome" />
                <asp:BoundField DataField="Descricao" HeaderText="Descrição" />
                <asp:BoundField DataField="DataCriacao" HeaderText="Data de Criação" DataFormatString="{0:d}" />
                <asp:BoundField DataField="DataConclusao" HeaderText="Data de Conclusão" DataFormatString="{0:d}" />
                <asp:BoundField DataField="Prioridade" HeaderText="Prioridade" />
                <asp:BoundField DataField="StatusTarefa" HeaderText="Status" />
                <asp:BoundField DataField="ProjetoId" HeaderText="Projeto ID" />
            </Columns>
        </asp:GridView>
    </div>
</asp:Content>
