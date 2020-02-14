<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="Sptask.Register1" %>

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
        }

        .container-content {
            margin-top: 10px;
            margin-left: 30px;
            padding: 10px;
        }

        .lbladd {
            margin-left: 18px;
            padding: 10px;
        }

        .lblgen {
            margin-left: 22px;
            padding: 10px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <div class="container-content">
                <asp:Label ID="lblStudName" runat="server" Text="Name :"></asp:Label>
                <asp:TextBox ID="txtStudName" runat="server" Style="margin-left: 8px"></asp:TextBox>
            </div>
            <div class="lblgen">
                <asp:Label ID="lblGender" runat="server" Text="Gender :"></asp:Label>
                <asp:RadioButtonList ID="radGender" runat="server" Style="margin-left: 61px" Width="119px">
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
            <div class="lbladd">
                <asp:Label ID="lblAddress" runat="server" Text="Address :"></asp:Label>
                <asp:TextBox ID="txtAddress" runat="server" Style="margin-left: 8px" TextMode="MultiLine" Width="167px"></asp:TextBox>
            </div>
            <div class="container-content">
                <asp:Button runat="server" Text="Register" Style="margin-left: 53px" ID="btnReg" OnClick="btnReg_Click"/>
                <asp:Button runat="server" Text="Clear" Style="margin-left: 8px" Width="54px" ID="btnClear" OnClick="btnClear_Click"/>
                <asp:Button runat="server" Text="Update" Style="margin-left: 8px" ID="btnUpdate" OnClick="btnUpdate_Click"/>
            </div>
        </div>
    </form>
</body>
</html>
