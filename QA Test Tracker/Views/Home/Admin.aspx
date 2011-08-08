<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Admin
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <ul>
        <li><%: Html.ActionLink("Releases", "Index", "Releases")%></li>
        <li><%: Html.ActionLink("Features", "Index", "Features")%></li>
        <li><%: Html.ActionLink("Products", "Index", "Products")%></li>
        <li><%: Html.ActionLink("Builds", "Index", "Builds")%></li>
        <li><%: Html.ActionLink("Test Plans", "Index", "TestPlans")%></li>
        <li><%: Html.ActionLink("Test Cases", "Index", "TestCases")%></li>
        <li><%: Html.ActionLink("Test Steps", "Index", "TestSteps")%></li>
        <li><%: Html.ActionLink("Test Components", "Index", "TestComponents")%></li>
    </ul>

</asp:Content>
