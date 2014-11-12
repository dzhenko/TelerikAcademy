<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebFormsApp._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron">
        <h1>Files Purpose</h1>
        <p class="lead">I will try to explain each of the generated file's purposes</p>
        <p><a href="http://www.asp.net" class="btn btn-primary btn-lg">Learn more &raquo;</a></p>
    </div>
    <div class="well">
        <p>
            App data holds any db's that we may use (local db in most cases).
        </p>
        <p>
            App start configurates our app. It adds all the content (css/js) into single files, minifies and uglifies them. Route config holds the settings for what action to be executed when a page is accessed as a url. It can limit access if a user is not authorised.
        </p>
        <p>
            Content holds our css files that are going to be bundled up.
        </p>
        <p>
            Fonts holds our font files that are going to be bundled up.
        </p>
        <p>
            Scripts holds our js files that are going to be bundled up.
        </p>
        <p>
            There are 3 default aspx pages - About, Default and Contact. They are used to form the sample app. In most cases they are deleted.
        </p>
        <p>
            Site master is a master page, from which all other pages inherit and re-use its layout.
        </p>
        <p>
            Global.asax is the code that executes on startup - it calls all the classes in App_Start and configurates them.
        </p>
        <p>
            Web config (deriving from machine config) is used to configurate our app (both in debug and release mode). In most cases holds info about connection strings, access rights to different routs, route maps etc.
        </p>
    </div>
    <hr />
    <div class="well">
        <h3>Code behind</h3>
        <p>
            Many languages use the concept of mixing code and html - for easier and dynamic html content generation. In most of them the code becomes very hard to read and maintain. This is where the concept for codebehind comes - every single page has its own codebehind that is used to hold the busines logic. This way the html remains code free and the code remains html - free.
        </p>
    </div>
    <div class="well">
        <h3>Hello from aspx : <asp:Label ID="LabelAspx" runat="server" Text="Hello ASP.NET !" ForeColor="Green"></asp:Label></h3>
        <h3>Hello from codebehind : <asp:Label ID="LabelCode" runat="server" Text="Hello ASP.NET" ForeColor="Green"></asp:Label></h3>
    </div>
    <div class="well">
        <h3>Current Assembly Location:<asp:Label ID="LabelAssembly" runat="server"></asp:Label></h3>
    </div>


</asp:Content>
