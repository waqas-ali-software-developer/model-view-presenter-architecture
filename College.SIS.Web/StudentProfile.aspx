<%@ Page Language="C#" AutoEventWireup="true" UnobtrusiveValidationMode="None" CodeBehind="StudentProfile.aspx.cs" Inherits="College.SIS.Web.StudentProfile" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Student Profile</title>
    <link href="Css/StudentProfile.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="txt-title-message">Student Profie Form</div>
        <div class="txt-compulsary-message">All * fields are compulsary</div>
        <table>
            <tr>
                <td>First Name: <strong class="txt-red">*</strong></td>
                <td>
                    <asp:TextBox ID="txtFirstName" MaxLength="35" runat="server"></asp:TextBox></td>
                <td>
                    <asp:RequiredFieldValidator runat="server" ID="reqTxtFirstName" ValidationGroup="Group1" ControlToValidate="txtFirstName" CssClass="txt-error-message" ErrorMessage="Requried" /></td>
            </tr>
            <tr>
                <td>Second Name: <strong class="txt-red">*</strong></td>
                <td>
                    <asp:TextBox ID="txtLastName" MaxLength="35" runat="server"></asp:TextBox></td>
                <td>
                    <asp:RequiredFieldValidator runat="server" ID="reqTxtLastName" ValidationGroup="Group1" ControlToValidate="txtLastName" CssClass="txt-error-message" ErrorMessage="Requried" /></td>
            </tr>
            <tr>
                <td>Country: <strong class="txt-red">*</strong></td>
                <td>
                    <asp:DropDownList ID="ddlCountry" runat="server"></asp:DropDownList></td>
                <td>
                    <asp:RequiredFieldValidator ID="reqDdlCountry" ValidationGroup="Group1" CssClass="txt-error-message" runat="server" ControlToValidate="ddlCountry"
                        InitialValue="-1" ErrorMessage="Requried" /></td>
            </tr>
            <tr>
                <td>Gender: <strong class="txt-red">*</strong></td>
                <td>
                    <asp:DropDownList ID="ddlGender" runat="server"></asp:DropDownList></td>
                <td>
                    <asp:RequiredFieldValidator ID="reqDdlGender" ValidationGroup="Group1" CssClass="txt-error-message" runat="server" ControlToValidate="ddlGender"
                        InitialValue="-1" ErrorMessage="Requried" /></td>
            </tr>
            <tr>
                <td>
                    <asp:Button ID="btnSaveStudentProfile" OnClick="btnSaveStudentProfile_Click" ValidationGroup="Group1" runat="server" Text="Add Record" /></td>
                <td>
                    <asp:Button ID="btnReset" runat="server" Text="Reset" OnClick="btnReset_Click" /></td>
                <td></td>
            </tr>
        </table>
        <asp:Label ID="lblMessage" CssClass="txt-error-message" runat="server" Text=""></asp:Label>
        <table>
            <tr>
                <td>
                    <asp:GridView ID="gvStudentsList" runat="server" AutoGenerateColumns="False">
                        <AlternatingRowStyle BackColor="White" />
                        <Columns>
                            <asp:TemplateField HeaderText="Sr#" HeaderStyle-VerticalAlign="Top">
                                <ItemStyle Wrap="true" HorizontalAlign="Center" VerticalAlign="Top" />
                                <ItemTemplate>
                                    <div>
                                        <asp:Label ID="lblSr" runat="server" Text="<%# Container.DataItemIndex + 1 %>"></asp:Label>
                                    </div>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="First Name">
                                <ItemStyle Wrap="true" />
                                <ItemTemplate>
                                    <div>
                                        <asp:Label ID="lblFirstName" runat="server" Text='<%#Eval("FirstName") %>'></asp:Label>
                                    </div>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Last Name">
                                <ItemStyle Wrap="true" />
                                <ItemTemplate>
                                    <div>
                                        <asp:Label ID="lblLastName" runat="server" Text='<%#Eval("LastName") %>'></asp:Label>
                                    </div>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Country Name">
                                <ItemStyle Wrap="true" />
                                <ItemTemplate>
                                    <div>
                                        <asp:Label ID="lblCountryName" runat="server" Text='<%#Eval("CountryName") %>'></asp:Label>
                                    </div>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Gender">
                                <ItemStyle Wrap="true" />
                                <ItemTemplate>
                                    <div>
                                        <asp:Label ID="lblGenderName" runat="server" Text='<%#Eval("GenderName") %>'></asp:Label>
                                    </div>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Action<br/>&nbsp;">
                                <ItemStyle Wrap="true" CssClass="row_style_display" />
                                <ItemTemplate>
                                    <div class="row_style_display">
                                        <div class="ractioncol1">
                                            <asp:LinkButton ID="lbtnDelete" OnClientClick='<%# "return ConfirmDelete("+ Eval("Id") + ");" %>' runat="server" OnClick="lbtnDelete_Click">Delete</asp:LinkButton>
                                            <asp:LinkButton ID="lbtnEdit" runat="server" OnClick="lbtnEdit_Click">Edit</asp:LinkButton>
                                            <asp:HiddenField ID="hdnStudent_Id" Value='<%#Eval("Id") %>' runat="server" />
                                        </div>
                                    </div>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                        <EmptyDataTemplate>No Record Found</EmptyDataTemplate>
                        <HeaderStyle BackColor="#b2d8da" />
                    </asp:GridView>
                </td>
            </tr>
        </table>
        <asp:HiddenField ID="hdnStudentId" Value="0" runat="server" />
        <script type="text/javascript">
            function ConfirmDelete(Id) {
                //your logic
                var result = confirm("Are you sure you want to delete record of student Alex!");
                if (result) {
                    return true;
                } else {
                    return false;
                }
            }
        </script>
    </form>
</body>
</html>
