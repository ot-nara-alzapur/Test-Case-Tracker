<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<QA_Test_Tracker.Models.TestCase>" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Edit Test Case
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
 
    <% using (Html.BeginForm()) { %>
        <%: Html.ValidationSummary(true) %>
        <fieldset>
            <legend>TestCase</legend>
    
            <%: Html.HiddenFor(model => model.ID) %>
    		<%: Html.Partial("CreateOrEdit", Model) %>
            <p>
                <input type="submit" value="Save" />
            </p>
        </fieldset>
    <% } %>
    
    <div>
        <%: Html.ActionLink("Back to List", "Index") %>
    </div>
</asp:Content>