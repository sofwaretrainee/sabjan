<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Retrive.aspx.cs" Inherits="Sptask.Register" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body style="width: 751px; margin-left: 198px">
    <form id="form1" runat="server">
    <div style="margin-top: 117px">
        <asp:LinkButton runat="server"  ID="lnkbtnReg" Text="Register" style="margin-left:692px;" OnClick="lnkbtnReg_Click"></asp:LinkButton>
        <asp:GridView ID="gvEmp" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3"  Width="746px" DataKeyNames="student_id" style="text-align:center;"
            OnRowCommand="gvEmp_RowCommand" OnRowEditing="gvEmp_RowEditing">
            <Columns>
                <asp:TemplateField HeaderText="Name">
                    <ItemTemplate>
                        <asp:Label ID="lblStudId" Text='<%# Eval("student_id") %>' runat="server" Visible="false"></asp:Label>
                        <asp:Label ID="lblStudName" Text='<%# Eval("student_name") %>' runat="server"></asp:Label>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox runat="server" ID="txtStudName" Text='<%# Eval("student_name") %>'></asp:TextBox>
                    </EditItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Gender">
                    <ItemTemplate>
                        <asp:Label ID="lblStudGender" Text='<%# Eval("student_gender") %>' runat="server"></asp:Label>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox runat="server" ID="txtStudGender" Text='<%# Eval("student_gender") %>'></asp:TextBox>
                    </EditItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText=" Marks">
                    <ItemTemplate>
                        <asp:Label ID="lblStudMarks" Text='<%# Eval("student_marks") %>' runat="server"></asp:Label>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox runat="server" ID="txtStudMarks" Text='<%# Eval("student_marks") %>'></asp:TextBox>
                    </EditItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Phone">
                    <ItemTemplate>
                        <asp:Label ID="lblStudPhone" Text='<%# Eval("student_phone") %>' runat="server"></asp:Label>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox runat="server" ID="txtStudPhone" Text='<%# Eval("student_phone") %>'></asp:TextBox>
                    </EditItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Address">
                    <ItemTemplate>
                        <asp:Label ID="lblStudAddress" Text='<%# Eval("student_address") %>' runat="server"></asp:Label>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox runat="server" ID="txtStudAddress" Text='<%# Eval("student_address") %>'></asp:TextBox>
                    </EditItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Alter">
                    <ItemTemplate>
                        <asp:LinkButton runat="server" CommandName="Edit" ID="btnEdit" Text="Edit"></asp:LinkButton>
                        <asp:LinkButton runat="server" CommandName="Delete" ID="btnDelete" Text="Delete" OnClick="lnkbtnReg_Click"></asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>

            </Columns>
            <FooterStyle BackColor="White" ForeColor="#000066" />
            <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
            <RowStyle ForeColor="#000066" />
            <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
            <SortedAscendingCellStyle BackColor="#F1F1F1" />
            <SortedAscendingHeaderStyle BackColor="#007DBB" />
            <SortedDescendingCellStyle BackColor="#CAC9C9" />
            <SortedDescendingHeaderStyle BackColor="#00547E" />
        </asp:GridView>
    </div>
    </form>
</body>
</html>
