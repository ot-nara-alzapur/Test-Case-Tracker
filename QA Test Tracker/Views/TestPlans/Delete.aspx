<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<QA_Test_Tracker.Models.TestPlan>" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Delete Test Plan
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h3>Are you sure you want to delete this?</h3>
    <fieldset>
        <legend>TestPlan</legend>


        <div class="display-label">Feature</div>
        <div class="display-field"><%: (Model.Feature == null ? "None" : Model.Feature.Name) %></div>


        <div class="display-label">TestCases</div>
        <div class="display-field"><%: (Model.TestCases == null ? "None" : Model.TestCases.Count.ToString()) %></div>


        <div class="display-label">Name</div>
        <div class="display-field"><%: Model.Name %></div>

    </fieldset>
    <% using (Html.BeginForm()) { %>
        <p>
            <input type="submit" value="Delete" /> |
            <%: Html.ActionLink("Back to List", "Index") %>
        </p>
    <% } %>
</asp:Content>


