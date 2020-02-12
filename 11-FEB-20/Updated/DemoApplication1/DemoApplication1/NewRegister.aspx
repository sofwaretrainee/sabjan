<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="NewRegister.aspx.cs" Inherits="DemoApplication1.NewRegister" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style>
        .container-div
        {
            margin-left: 450px;
            padding:50px;
        }
         .addButton
        {
            margin-left: 930px;
            margin-bottom:10px;
            color: white;
        }
         .grid-content
         {
             padding:50px;
             text-align: center;  
         }
         body
         {
             background-image:url(https://www.techunido.com/wp-content/uploads/2018/06/ASP.Net-Development.jpg);
             background-repeat:repeat-y;  
         }
         
    </style>
   
</head>
<body>
    <form id="form1" runat="server">
    <div class="container-div">
          <%-- <asp:Button runat="server" Width="40px" Text="Add" CommandName="AddNew" ToolTip="Edit" CssClass="addButton" PostBackUrl="~/Demo.aspx"/>--%>
                <asp:LinkButton ID="lnkBtnAdd" runat="server" CssClass="addButton"  OnClick="lnkBtnAdd_Click"  >Add</asp:LinkButton>
       
           <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false" AutoGenerateRows="false" ShowFooter="true" DataKeyNames="emp_id" ShowHeaderWhenEmpty="false"
                OnRowEditing="GridView1_RowEditing" OnRowDeleting="GridView1_RowDeleting" CssClass="grid-content"
            BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3" Width="971px">
            <FooterStyle BackColor="White" ForeColor="#000066" />
            <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
            <RowStyle ForeColor="#000066" />
            <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
            <SortedAscendingCellStyle BackColor="#F1F1F1" />
            <SortedAscendingHeaderStyle BackColor="#007DBB" />
            <SortedDescendingCellStyle BackColor="#CAC9C9" />
            <SortedDescendingHeaderStyle BackColor="#00547E"/>

            <Columns>

                <asp:TemplateField HeaderText="First Name">
                    <ItemTemplate>
                        <asp:Label ID="lblEmpId" Text='<%# Eval("emp_id") %>' runat="server" ></asp:Label>
                        <asp:Label Text='<%# Eval("first_name") %>' runat="server"></asp:Label>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox runat="server" ID="txtFirstName" Text='<%# Eval("first_name") %>'></asp:TextBox>
                    </EditItemTemplate>
                    
                </asp:TemplateField>

                 <asp:TemplateField HeaderText="Last Name">
                    <ItemTemplate>
                        <asp:Label Text='<%# Eval("last_name") %>' runat="server"></asp:Label>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox runat="server" ID="txtLastName" Text='<%# Eval("last_name") %>'></asp:TextBox>
                    </EditItemTemplate>
                    
                </asp:TemplateField>

                 <asp:TemplateField HeaderText="Email">
                    <ItemTemplate>
                        <asp:Label Text='<%# Eval("email") %>' runat="server"></asp:Label>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox runat="server" ID="txtEmail" Text='<%# Eval("email") %>'></asp:TextBox>
                    </EditItemTemplate>
                    
                </asp:TemplateField>

                 <asp:TemplateField HeaderText="Password" Visible="false">
                    <ItemTemplate>
                        <asp:Label Text='<%# Eval("password") %>' runat="server"></asp:Label>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox runat="server" ID="txtPassword" Text='<%# Eval("password") %>'></asp:TextBox>
                    </EditItemTemplate>
                    
                </asp:TemplateField>

                 <asp:TemplateField HeaderText="Confirm Password" Visible="false">
                    <ItemTemplate>
                        <asp:Label Text='<%# Eval("cpassword") %>' runat="server"></asp:Label>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox runat="server" ID="txtCpassword" Text='<%# Eval("cpassword") %>'></asp:TextBox>
                    </EditItemTemplate>
                    
                </asp:TemplateField>

                 <asp:TemplateField HeaderText="Gender">
                    <ItemTemplate>
                        <asp:Label Text='<%# Eval("gender") %>' runat="server"></asp:Label>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox runat="server" ID="txtGender" Text='<%# Eval("gender") %>'></asp:TextBox>
                    </EditItemTemplate>
                    
                </asp:TemplateField>

                 <asp:TemplateField HeaderText="Date Of Birth">
                    <ItemTemplate>
                        <asp:Label Text='<%# Eval("dob") %>' runat="server"></asp:Label>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox runat="server" ID="txtDOB" Text='<%# Eval("dob") %>'></asp:TextBox>
                    </EditItemTemplate>
                    
                </asp:TemplateField>

                 <asp:TemplateField HeaderText="Mobile">
                    <ItemTemplate>
                        <asp:Label Text='<%# Eval("mobile") %>' runat="server"></asp:Label>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox runat="server" ID="txtMobileName" Text='<%# Eval("mobile") %>'></asp:TextBox>
                    </EditItemTemplate>
                   
                </asp:TemplateField>

                 <asp:TemplateField HeaderText="Address">
                    <ItemTemplate>
                        <asp:Label Text='<%# Eval("address") %>' runat="server"></asp:Label>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox runat="server" ID="txtAddress" Text='<%# Eval("address") %>'></asp:TextBox>
                    </EditItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Alter">
                    <ItemTemplate>
                        <asp:LinkButton ID="lnkBtnEdit" runat="server" CommandName="Edit" >Edit</asp:LinkButton>
                       <%-- <asp:Button runat="server" Width="50px" ID="btnEdit" Text="Edit"  CommandName="Edit" ToolTip="Edit" OnClick="btnEdit_Click" />--%>
                         <asp:LinkButton ID="lnkBtnDelete" runat="server" CommandName="Delete" >Delete</asp:LinkButton>
                        
                    </ItemTemplate>
                   <%-- <EditItemTemplate>
                        <asp:Button runat="server" Width="50px" Text="Update" CommandName="Update" ToolTip="Edit"/>
                        <asp:Button runat="server" Width="50px" Text="Cancel" CommandName="Cancel" ToolTip="Edit"/>
                    </EditItemTemplate>--%>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>


    </div>
    </form>
</body>
</html>
