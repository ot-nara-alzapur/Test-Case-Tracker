<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<QA_Test_Tracker.Models.Build>" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Delete Build
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
 
    <h3>Are you sure you want to delete this?</h3>
    <fieldset>
        <legend>Build</legend>
    
        <div class="display-label">Product</div>
        <div class="display-field"><%: (Model.Product == null ? "None" : Model.Product.Name) %></div>
    
        <div class="display-label">BuildNumber</div>
        <div class="display-field"><%: Model.BuildNumber %></div>
    </fieldset>
    <% using (Html.BeginForm()) { %>
        <p>
            <input type="submit" value="Delete" /> |
            <%: Html.ActionLink("Back to List", "Index") %>
        </p>
    <% } %>
</asp:Content>