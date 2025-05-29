<%@ Page Title="Home Page" Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="MyWebApp._Default" %>

<html>
    <body>
        <form runat="server" id="form"> 
            <asp:Label ID="lblHelloWorld" runat="server" Text="" Font-Bold="True" Font-Size="Large"></asp:Label>
            <asp:Button ID="btnClickMe" runat="server" Text="Send Email" OnClick="btnClickMe_Click" />
        </form>
    </body>
</html>
