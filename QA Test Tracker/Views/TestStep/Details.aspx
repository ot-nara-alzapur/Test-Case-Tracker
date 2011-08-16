<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<QA_Test_Tracker.Models.TestStep>" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Test Step Details
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <fieldset>
        <legend>TestStep</legend>
    
        <div class="display-label">Name</div>
        <div class="display-field"><%: Model.Name %></div>
    
        <div class="display-label">Description</div>
        <div class="display-field"><%: Model.Description %></div>
    </fieldset>
    <p>
    
        <%: Html.ActionLink("Edit", "Edit", new { id=Model.ID }) %> |
        <%: Html.ActionLink("Back to Test Case", "Details", "TestCase", new { id=Model.TestCase.ID }, null) %> |
        <%: Html.ActionLink("Back to Test Plan", "Details", "TestPlan", new { id=Model.TestCase.TestPlan.ID }, null) %>
    </p>
</asp:Content>