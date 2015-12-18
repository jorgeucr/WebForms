<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Author.aspx.cs" Inherits="WebFormsApp.Book" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        Insertar Autor.<br />
        <br />
        Nombre:&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="txbAuthorName" runat="server"></asp:TextBox>
        <br />
        Apellido:&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="txAuthorLastname" runat="server"></asp:TextBox>
        <br />
        <br />
        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Insertar" />
        <br />
        <br />
        <br />
        <br />
        Borrar autores:<br />
        <br />
        <asp:DropDownList ID="ddlAuthors" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlAuthors_SelectedIndexChanged">
        </asp:DropDownList>
&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="txbBorrar" runat="server"></asp:TextBox>
&nbsp;&nbsp;&nbsp;
        <asp:Button ID="btnBorrar" runat="server" OnClick="btnBorrar_Click" Text="Borrar" />
        <br />
        <br />
        <br />
        ListView<br />
        <br />
        <asp:ListBox ID="ListBox1" runat="server" DataSourceID="SqlDataSource1" DataTextField="author_name" DataValueField="author_name"></asp:ListBox>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:BD_WebFormsCodeConnectionString %>" SelectCommand="SELECT [author_name] FROM [tbl_author] ORDER BY [id]"></asp:SqlDataSource>
        <br />
        <br />
        GridView<br />
        <br />
        SQLDATASOURCE<asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CellPadding="4" DataKeyNames="id" DataSourceID="SqlDataSource2" ForeColor="#333333" GridLines="None" OnSelectedIndexChanged="GridView1_SelectedIndexChanged">
            <AlternatingRowStyle BackColor="White" />
            <Columns>
                <asp:CommandField ShowDeleteButton="True" ShowEditButton="True" ShowSelectButton="True" />
                <asp:BoundField DataField="id" HeaderText="id" InsertVisible="False" ReadOnly="True" SortExpression="id" />
                <asp:BoundField DataField="author_name" HeaderText="author_name" SortExpression="author_name" />
                <asp:BoundField DataField="author_lastname" HeaderText="author_lastname" SortExpression="author_lastname" />
            </Columns>
            <EditRowStyle BackColor="#7C6F57" />
            <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center" />
            <RowStyle BackColor="#E3EAEB" />
            <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />
            <SortedAscendingCellStyle BackColor="#F8FAFA" />
            <SortedAscendingHeaderStyle BackColor="#246B61" />
            <SortedDescendingCellStyle BackColor="#D4DFE1" />
            <SortedDescendingHeaderStyle BackColor="#15524A" />
        </asp:GridView>
        <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:BD_WebFormsCodeConnectionString2 %>" DeleteCommand="DELETE FROM [tbl_author] WHERE [id] = @id" InsertCommand="INSERT INTO [tbl_author] ([author_name], [author_lastname]) VALUES (@author_name, @author_lastname)" SelectCommand="SELECT * FROM [tbl_author]" UpdateCommand="UPDATE [tbl_author] SET [author_name] = @author_name, [author_lastname] = @author_lastname WHERE [id] = @id">
            <DeleteParameters>
                <asp:Parameter Name="id" Type="Int32" />
            </DeleteParameters>
            <InsertParameters>
                <asp:Parameter Name="author_name" Type="String" />
                <asp:Parameter Name="author_lastname" Type="String" />
            </InsertParameters>
            <UpdateParameters>
                <asp:Parameter Name="author_name" Type="String" />
                <asp:Parameter Name="author_lastname" Type="String" />
                <asp:Parameter Name="id" Type="Int32" />
            </UpdateParameters>
        </asp:SqlDataSource>
        <br />
        <br />
        NORMAL<br />
        <br />
        <asp:GridView ID="gdvAuthors" runat="server">
        </asp:GridView>
    
    </div>
    </form>
</body>
</html>
