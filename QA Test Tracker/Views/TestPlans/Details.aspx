<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<QA_Test_Tracker.Models.TestPlan>" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Test Plan Details
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
 
        <fieldset>
        <legend>TestPlan</legend>
    
        <div class="display-label">Feature</div>
        <div class="display-field"><%: (Model.Feature == null ? "None" : Model.Feature.Name) %></div>
    
        <div class="display-label">TestCases</div>
        <div class="display-field"><%: (Model.TestCases == null ? "None" : Model.TestCases.Count.ToString()) %></div>
    </fieldset>
    <p>
    
        <%: Html.ActionLink("Edit", "Edit", new { id=Model.ID }) %> |
        <%: Html.ActionLink("Back to List", "Index") %>
    </p>
</asp:Content>