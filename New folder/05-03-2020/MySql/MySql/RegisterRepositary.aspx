<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RegisterRepositary.aspx.cs" Inherits="MySql.RegisterRepositary" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style>
        .container {
            margin-left: 650px;
            margin-right: 650px;
            margin-top: 200px;
            border: 1px solid black;
            height: 100%;
            width: 400px;
            max-height:100%;
            max-width:100%;
            background-color:aliceblue;
        }

        .container-content {
            margin-top: 10px;
            margin-left: 31px;
            padding: 10px;
            width: 336px;
        }

        .lbladd {
            margin-left: 18px;
            padding: 10px;
        }

        .lblgen {
            margin-left: 22px;
            padding: 10px;
        }
        .lblCountry
        {
             margin-left: -2px;
             padding: 10px;
        }
    </style>
</head>
<body style="background-image:url(https://previews.123rf.com/images/mazirama/mazirama1501/mazirama150100409/35800246-registration-concept-on-blue-background-with-world-map-and-social-icons-.jpg)">
    <form id="form1" runat="server">
        <div class="container">
            <div class="container-content">
                <asp:Label ID="lblStudName" runat="server" Text="Name :"></asp:Label>
                <asp:TextBox ID="txtStudName" runat="server" Style="margin-left: 8px"></asp:TextBox>
            </div>
            <div class="lblgen">
                <asp:Label ID="lblGender" runat="server" Text="Gender :"></asp:Label>
                <asp:RadioButtonList ID="radGender" runat="server" Style="margin-left: 68px; margin-top: 0px; margin-bottom: 0px;" Width="119px" RepeatLayout="Table" Height="28px">
                    <asp:ListItem Value="male" Selected>Male</asp:ListItem>
                    <asp:ListItem Value="female">Female</asp:ListItem>
                </asp:RadioButtonList>
            </div>
            <div class="container-content">
                <asp:Label ID="lblMarks" runat="server" Text="Marks :"></asp:Label>
                <asp:TextBox ID="txtMarks" runat="server" Style="margin-left: 8px"></asp:TextBox>
            </div>
            <div class="container-content">
                <asp:Label ID="lblPhone" runat="server" Text="Phone :"></asp:Label>
                <asp:TextBox ID="txtPhone" runat="server" Style="margin-left: 8px"></asp:TextBox>
            </div>
            <div class="lblCountry">
                <asp:Label runat="server" ID="lblCountry" Text="Nationality :" ></asp:Label>
                <asp:DropDownList ID="CountryDropdown" runat="server" Height="35px" style="margin-left: 8px; margin-bottom: 0px" Width="176px">
                    <asp:ListItem Value="Select">Select</asp:ListItem>
                    <asp:ListItem Value="India">India</asp:ListItem>
                    <asp:ListItem Value="USA">USA</asp:ListItem>
                    <asp:ListItem Value="China">China</asp:ListItem>
                    <asp:ListItem Value="Dubai">Dubai</asp:ListItem>
                    <asp:ListItem Value="Germany">Germany</asp:ListItem>
                </asp:DropDownList>
            </div>
            <div class="lbladd">
                <asp:Label ID="lblAddress" runat="server" Text="Address :"></asp:Label>
                <asp:TextBox ID="txtAddress1" runat="server" Style="margin-left: 8px"  Width="171px"></asp:TextBox> 
                <br />
                <asp:TextBox ID="txtAddress2" runat="server" Style="margin-left: 74px; margin-top: 11px;" Width="170px"></asp:TextBox> 
                <br />
                <asp:TextBox ID="txtAddress3" runat="server" Style="margin-left: 74px; margin-top: 11px;" Width="169px"></asp:TextBox> 
            </div>
            <div class="container-content">
                <asp:Button runat="server" Text="Register" Style="margin-left: 53px" ID="btnReg" OnClick="btnReg_Click" />
                <asp:Button runat="server" Text="Clear" Style="margin-left: 8px" Width="54px" ID="btnClear" />
                <asp:Button runat="server" Text="Update" Style="margin-left: 8px" ID="btnUpdate" OnClick="btnUpdate_Click" />
            </div>
        </div>
    </form>
</body>
</html>
