<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Registration.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <h2>Enter your details</h2>
        <asp:Label runat="server" Text="First Name" />
        <asp:TextBox ID="FirstName" runat="server"/>    
        <br />
        <asp:Label runat="server" Text="Last Name" />
        <asp:TextBox ID="LastName" runat="server"/>    
        <br />
        <asp:Label runat="server" Text="Faculty Number" />
        <asp:TextBox ID="FacultyNumber" runat="server"/>    
        <br />
        <asp:Label runat="server" Text="University" />
        <asp:DropDownList ID="University" runat="server" SelectMethod="GetUniversities"/>
        <br />
        <asp:Label runat="server" Text="Speciality" />
        <asp:DropDownList ID="Speciality" runat="server" SelectMethod="GetSpecialities"/>
        <br />
        <asp:Label runat="server" Text="Speciality" />
        <asp:CheckBoxList ID="Courses" runat="server" SelectMethod="GetCourses"/>
        <br />
        <asp:Button ID="Submit" runat="server" OnClick="Submit_Click" Text="Submit form"/>
        <h2>Result</h2>
        <asp:Literal Mode="Encode" ID="Name" runat="server" />
        <br />
        <asp:Literal Mode="Encode" ID="Number" runat="server" />
        <br />
        <asp:Literal Mode="Encode" ID="UniSpec" runat="server" />
        <br />
        <asp:Literal Mode="Encode" ID="SelectedCourses" runat="server" />
    </div>
    </form>
</body>
</html>
