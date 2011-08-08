<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<QA_Test_Tracker.Models.Build>" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Build Details
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
     <fieldset>
        <legend>Build</legend>
    
        <div class="display-label">Product</div>
        <div class="display-field"><%: (Model.Product == null ? "None" : Model.Product.Name) %></div>
    
        <div class="display-label">BuildNumber</div>
        <div class="display-field"><%: Model.BuildNumber %></div>
    </fieldset>
    <p>
    
        <%: Html.ActionLink("Edit", "Edit", new { id=Model.ID }) %> |
        <%: Html.ActionLink("Back to List", "Index") %>
    </p>
</asp:Content>