<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<QA_Test_Tracker.Models.Product>" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Delete Product
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
     <h3>Are you sure you want to delete this?</h3>
    <fieldset>
        <legend>Product</legend>
    
        <div class="display-label">Name</div>
        <div class="display-field"><%: Model.Name %></div>
    
        <div class="display-label">Description</div>
        <div class="display-field"><%: Model.Description %></div>
    </fieldset>
    <% using (Html.BeginForm()) { %>
        <p>
            <input type="submit" value="Delete" /> |
            <%: Html.ActionLink("Back to List", "Index") %>
        </p>
    <% } %>
    
</asp:Content>


