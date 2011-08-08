<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<QA_Test_Tracker.Models.Release>" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Remove Release
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
 
    <h3>Are you sure you want to delete this?</h3>
    <fieldset>
        <legend>Release</legend>
    
        <div class="display-label">ReleaseDate</div>
        <div class="display-field"><%: String.Format("{0:g}", Model.ReleaseDate) %></div>
    
        <div class="display-label">ReleaseTicketNumber</div>
        <div class="display-field"><%: Model.ReleaseTicketNumber %></div>
    </fieldset>
    <% using (Html.BeginForm()) { %>
        <p>
            <input type="submit" value="Delete" /> |
            <%: Html.ActionLink("Back to List", "Index") %>
        </p>
    <% } %>
</asp:Content>    


