<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<QA_Test_Tracker.Models.Release>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Add Release
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
 
    <% using (Html.BeginForm()) { %>
        <%: Html.ValidationSummary(true) %>
        <fieldset>
            <legend>Release</legend>
    
    		<%: Html.Partial("CreateOrEdit", Model) %>
            <p>
                <input type="submit" value="Create" />
            </p>
        </fieldset>
    <% } %>
    
    <div>
        <%: Html.ActionLink("Back to List", "Index") %>
    </div>
</asp:Content>

