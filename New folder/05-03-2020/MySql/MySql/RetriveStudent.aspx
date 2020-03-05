<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RetriveStudent.aspx.cs" Inherits="MySql.RetriveStudent" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style>
         .lnkreg {
            margin-left: 220px;
            color: black;
        }

        .grid-style {
            margin-left: 50px;
            margin-top: 90px;
            padding:2px;
            margin-right: 50px;    
        }
    </style>
</head>
<body style="background-image:url(https://static1.squarespace.com/static/5820b7b22994ca6b3aee3b1b/5840847c9656cad4125db466/5c3d0bad0e2e721f9b8413e4/1559329588903/keyboard.jpeg?format=1500w)">
    <form id="form1" runat="server">
        
        <div class="grid-style">
            <asp:DropDownList ID="DropDownList1" runat="server" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged" AutoPostBack="true">
                <asp:ListItem Value="select">select</asp:ListItem>
                <asp:ListItem Value="mysql">MySql</asp:ListItem>
                <asp:ListItem Value="mssql">MSSql</asp:ListItem>
            </asp:DropDownList>
            <asp:LinkButton runat="server" Text="Register" ID="lnkbtnRegister" Onclick="lnkbtnRegister_Click" CssClass="lnkreg"></asp:LinkButton>
            <br />
            <br />
            <asp:GridView ID="gvStudent" runat="server" CellPadding="4" ForeColor="Black" AutoGenerateColumns="False" Width="100%" OnRowCommand="gvStudent_RowCommand" OnRowDeleting="gvStudent_RowDeleting" Height="100%" BackColor="#CCCCCC" BorderColor="#999999" BorderStyle="Solid" BorderWidth="3px" CellSpacing="2">
                <Columns>

                    <asp:TemplateField HeaderText="Student Name" HeaderStyle-HorizontalAlign="Left">
                        <ItemTemplate >
                            <asp:Label ID="lblStudentId" runat="server" Text='<%# Eval("student_id") %>' Visible="false"></asp:Label>
                            <asp:Label ID="lblStudentName" runat="server" Text='<%# Eval("student_name") %>'></asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox runat="server" ID="txtStudentName" Text='<%# Eval("student_name") %>'></asp:TextBox>
                        </EditItemTemplate>

<HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Gender" HeaderStyle-HorizontalAlign="Left">
                        <ItemTemplate>
                            <asp:Label ID="lblStudGender" runat="server" Text='<%# Eval("student_gender")%>'></asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="txtStudGender" runat="server" Text='<%# Eval("student_gender")%>'></asp:TextBox>
                        </EditItemTemplate>

<HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Marks" HeaderStyle-HorizontalAlign="Left">
                        <ItemTemplate>
                            <asp:Label ID="lblStudentMarks" runat="server" Text='<%# Eval("student_marks") %>'></asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox runat="server" ID="txtStudentMarks" Text='<%# Eval("student_marks") %>'></asp:TextBox>
                        </EditItemTemplate>

<HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Phone" HeaderStyle-HorizontalAlign="Left">
                        <ItemTemplate>
                            <asp:Label ID="lblStudentPhone" runat="server" Text='<%# Eval("student_phone") %>'></asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox runat="server" ID="txtStudentPhone" Text='<%# Eval("student_phone") %>'></asp:TextBox>
                        </EditItemTemplate>

<HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Nationality" HeaderStyle-HorizontalAlign="Left">
                        <ItemTemplate>
                            <asp:Label ID="lblStudNationality" runat="server" Text='<%# Eval("student_nationality")%>'></asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="txtStudNationality" runat="server" Text='<%# Eval("student_nationality")%>'></asp:TextBox>
                        </EditItemTemplate>

<HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Address" HeaderStyle-HorizontalAlign="Left">
                        <ItemTemplate>
                            <asp:Label ID="lblStudentAddress" runat="server" Text='<%# Eval("student_address") %>'></asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox runat="server" ID="txtStudentAddress" Text='<%# Eval("student_address") %>'></asp:TextBox>
                        </EditItemTemplate>

<HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Alter" HeaderStyle-HorizontalAlign="Left">
                        <ItemTemplate>
                            <asp:LinkButton runat="server" Text="Update" ID="lnkbtnUpdate" CommandName="Update"></asp:LinkButton>
                            <asp:LinkButton runat="server" Text="Delete" ID="lnkbtnDelete" CommandName="Delete"></asp:LinkButton>
                        </ItemTemplate>

<HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                    </asp:TemplateField>

                </Columns>
                <FooterStyle BackColor="#CCCCCC" />
                <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#CCCCCC" ForeColor="Black" HorizontalAlign="Left" />
                <RowStyle BackColor="White" />
                <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
                <SortedAscendingCellStyle BackColor="#F1F1F1" />
                <SortedAscendingHeaderStyle BackColor="#808080" />
                <SortedDescendingCellStyle BackColor="#CAC9C9" />
                <SortedDescendingHeaderStyle BackColor="#383838" />
            </asp:GridView>
        </div>
    </form>
</body>
</html>
