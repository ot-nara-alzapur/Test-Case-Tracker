<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Admin
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <ul>
        <li><%: Html.ActionLink("Releases", "Index", "Release")%></li>
        <li><%: Html.ActionLink("Features", "Index", "Feature")%></li>
        <li><%: Html.ActionLink("Products", "Index", "Product")%></li>
        <li><%: Html.ActionLink("Builds", "Index", "Build")%></li>
        <li><%: Html.ActionLink("Test Plans", "Index", "TestPlan")%></li>
        <li><%: Html.ActionLink("Test Cases", "Index", "TestCase")%></li>
        <li><%: Html.ActionLink("Test Steps", "Index", "TestStep")%></li>
        <li><%: Html.ActionLink("Test Components", "Index", "TestComponent")%></li>
    </ul>

</asp:Content>
