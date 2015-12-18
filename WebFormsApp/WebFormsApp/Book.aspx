<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Book.aspx.cs" Inherits="WebFormsApp.Book1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <p>
            Insertar Libro:</p>
        <p>
            Nombre:
            <asp:TextBox ID="txbBookName" runat="server"></asp:TextBox>
        </p>
        <p>
            Precio:&nbsp;&nbsp;
            <asp:TextBox ID="txbBookPrice" runat="server"></asp:TextBox>
        </p>
        <p>
            Autor:&nbsp;&nbsp;&nbsp;
            <asp:DropDownList ID="ddlBookAuthor" runat="server" AutoPostBack="True">
            </asp:DropDownList>
        </p>
        <p>
            Publicadores:
        </p>
        <p>
            <asp:ListBox ID="lbxPublishersList" runat="server" AutoPostBack="True" SelectionMode="Multiple"></asp:ListBox>
&nbsp;&nbsp;&nbsp;
            <asp:Button ID="btnSendPublisherToList" runat="server" OnClick="btnSendPublisherToList_Click" Text="--&gt;" />
&nbsp;&nbsp;&nbsp;
            <asp:ListBox ID="lbxSelectedPublisherList" runat="server" AutoPostBack="True" SelectionMode="Multiple"></asp:ListBox>
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT * FROM [tbl_publisher]"></asp:SqlDataSource>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        </p>
        <asp:Button ID="btnAddPublisher" runat="server" OnClick="btnAddPublisher_Click" Text="Insertar" />
    </form>
</body>
</html>
