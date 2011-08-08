<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<QA_Test_Tracker.Models.Release>" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Release Details
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
 
    <fieldset>
        <legend>Release</legend>
    
        <div class="display-label">ReleaseDate</div>
        <div class="display-field"><%: String.Format("{0:g}", Model.ReleaseDate) %></div>
    
        <div class="display-label">ReleaseTicketNumber</div>
        <div class="display-field"><%: Model.ReleaseTicketNumber %></div>
    </fieldset>
    <p>
    
        <%: Html.ActionLink("Edit", "Edit", new { id=Model.ID }) %> |
        <%: Html.ActionLink("Back to List", "Index") %>
    </p>
</asp:Content>