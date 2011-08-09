<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="QA_Test_Tracker.Views.RepositoryViewPage<QA_Test_Tracker.Models.TestPlan, QA_Test_Tracker.Configuration.TestTrackerDatabase>" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Add Test Plan
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <% using (Html.BeginForm()) { %>
        <%: Html.ValidationSummary(true) %>
        <fieldset>
            <legend>TestPlan</legend>

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