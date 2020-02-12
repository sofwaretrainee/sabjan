<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Demo.aspx.cs" Inherits="DemoApplication1.Demo" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .div-content
        {
            padding-top:30px;
            margin:60px 0 0 690px;
            border:1px solid black;
            width:600px;
            height:600px;
            text-align:center;
            background-color:antiquewhite;
            
        }
        #TextArea1 {
            width: 183px;
            margin-left: 8px;
        }
        .lblstyle
        {
            margin-left:-40px;
            margin-top:40px;
            padding: 5px;
        }
        .pwdlblstyle
        {
            margin-left:-15px;
        }
        .cpwdlblstyle
        {
            margin-left:-75px;
        }
        .genderbtn
        {
            margin-left:250px;
        }
        .doblbl
        {
            margin-left:-45px;
        }
        body
        {
            background-image:url(https://www.indianappdevelopers.com/assets/Images/ASPNET/Image2.svg);
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">

        <div >
            <h1 style="text-align:center;">Welcome User !!!!!!!!!!!!!!!</h1>
        </div>
    <div class="div-content">

         

        <%--<asp:Label ID="Label1" runat="server" Text="EmpId  :"></asp:Label>
        <asp:TextBox ID="TextBox1" runat="server" style="margin-left: 8px" Width="161px"></asp:TextBox>
        <br />
        <br />--%>
        <asp:Label ID="Label2" runat="server" Text="First Name :" class="lblstyle"></asp:Label>
        <asp:TextBox ID="txtFirstName" runat="server" style="margin-left: 6px; margin-right: 1px" Width="161px"></asp:TextBox>
        <br />
        <br />
        <asp:Label ID="Label3" runat="server" Text="Last Name :" class="lblstyle"></asp:Label>
        <asp:TextBox ID="TextBox3" runat="server" style="margin-left: 8px" Width="161px"></asp:TextBox>
        <br />
        <br />
        <asp:Label ID="Label4" runat="server" Text="E-Mail :"></asp:Label>
        <asp:TextBox ID="TextBox4" runat="server" style="margin-left: 8px" Width="161px"></asp:TextBox>
        <br />
        <br />
        <asp:Label ID="Label5" runat="server" Text="Password :"  class="pwdlblstyle"></asp:Label>
        <asp:TextBox ID="TextBox5" runat="server" style="margin-left: 8px" Width="161px"></asp:TextBox>
        <br />
         <br />
        <asp:Label ID="Label6" runat="server" Text="Confirm-Password :" class="cpwdlblstyle"></asp:Label>
        <asp:TextBox ID="TextBox6" runat="server" style="margin-left: 8px" Width="161px"></asp:TextBox>
        <br />
        <br />
        <asp:Label ID="Label7" runat="server" Text="Gender :" style="margin-left:-150px;"></asp:Label>
        <asp:RadioButtonList ID="RadioButtonList1" runat="server"  class="genderbtn">
            <asp:ListItem Value="male"  >Male</asp:ListItem>
            <asp:ListItem Value="female">Female</asp:ListItem>
        </asp:RadioButtonList>
        <br />
        <br />
        <asp:Label ID="Label8" runat="server" Text="Date-Of-Birth :" class="doblbl"></asp:Label>
        <asp:TextBox ID="TextBox7" runat="server" style="margin-left: 8px" Width="161px" TextMode="Date"></asp:TextBox>
        <br />
        <br />
        <asp:Label ID="Label9" runat="server" Text="Mobile :"></asp:Label>
        <asp:TextBox ID="TextBox8" runat="server" style="margin-left: 8px" Width="161px"></asp:TextBox>
        <br />
        <br />
        <asp:Label ID="Label10" runat="server" Text="Address :"></asp:Label>
        <asp:TextBox ID="txtAddress" TextMode="MultiLine" runat="server"></asp:TextBox>
        <br />
        <br />
        <asp:Button ID="Button1" runat="server" Text="Register" Width="73px" OnClick="Button1_Click"/>

        <asp:Button ID="Button2" runat="server" Text="Clear" Width="72px" OnClick="Button2_Click" style="margin-left:20px;" />
         <br />
         
         <br />
        <asp:Button ID="btnUpdate" runat="server" Width="73px" Text="Update" CommandName="Update" ToolTip="Edit" style="margin-left:-90px;" onclick="btnupdate_Click"/>
         <br />
         <br />
        <br />
        <br />
        </div>
    </form>
</body>
</html>
