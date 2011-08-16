<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="QA_Test_Tracker.Views.RepositoryViewPage<QA_Test_Tracker.Models.TestCase, QA_Test_Tracker.Configuration.TestTrackerDatabase>" %>
<%@ Import Namespace="QA_Test_Tracker.Models" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Add Test Case
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <% using (Html.BeginForm()) { %>
        <%: Html.ValidationSummary(true) %>
        <fieldset>
            <legend>Test Case</legend>
                <div class="editor-label">
                    <%: Html.LabelFor(model => model.Name) %>
                </div>
                <div class="editor-field">
                    <%: Html.EditorFor(model => model.Name) %>
                    <%: Html.ValidationMessageFor(model => model.Name) %>
                </div>
                <div class="editor-label">
                <%: Html.LabelFor(model => model.TestComponent) %> (<%: Html.ActionLink("Add", "Create", "TestComponent") %>)
                </div>
                <div class="editor-field">
                    <%: Html.DropDownListFor(model => model.TestComponent.ID, new SelectList(GetAll<TestComponent>(), "ID", "Name"))%>
                    <%: Html.ValidationMessageFor(model => model.TestComponent)%>
                </div>
            <p>
                <input type="submit" value="Create" />
            </p>
        </fieldset>
    <% } %>

    <div>
        <%: Html.ActionLink("Back to Test Plan", "Details", "TestPlan", new { id=Request.QueryString["testPlanID"] }, null) %>
    </div>
</asp:Content>

