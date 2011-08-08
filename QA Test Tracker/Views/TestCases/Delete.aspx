<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<QA_Test_Tracker.Models.TestCase>" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Delete Test Case
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
 
    <h3>Are you sure you want to delete this?</h3>
    <fieldset>
        <legend>TestCase</legend>
    
        <div class="display-label">Component</div>
        <div class="display-field"><%: (Model.Component == null ? "None" : Model.Component.Name) %></div>
    
        <div class="display-label">Tests</div>
        <div class="display-field"><%: (Model.Tests == null ? "None" : Model.Tests.Count.ToString()) %></div>
    </fieldset>
    <% using (Html.BeginForm()) { %>
        <p>
            <input type="submit" value="Delete" /> |
            <%: Html.ActionLink("Back to List", "Index") %>
        </p>
    <% } %>
</asp:Content>