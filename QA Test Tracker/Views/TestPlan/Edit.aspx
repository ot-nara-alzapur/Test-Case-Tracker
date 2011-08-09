<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="QA_Test_Tracker.Views.RepositoryViewPage<QA_Test_Tracker.Models.TestPlan, QA_Test_Tracker.Configuration.TestTrackerDatabase>" %>
<%@ Import Namespace="QA_Test_Tracker.Models" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Edit Test Plan
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <% using (Html.BeginForm()) { %>
        <%: Html.ValidationSummary(true) %>
        <fieldset>
            <legend>Test Plan</legend>


            <%: Html.HiddenFor(model => model.ID) %>
            <div class="editor-label">
                <%: Html.LabelFor(model => model.Name) %>
            </div>
            <div class="editor-field">
                <%: Html.EditorFor(model => model.Name) %>
                <%: Html.ValidationMessageFor(model => model.Name) %>
            </div>
            
            <div class="editor-label">
                <%: Html.LabelFor(model => model.Feature) %>
            </div>
            <div class="editor-field">
                <%: Html.DropDownListFor(model => model.Feature.ID, new SelectList(GetAll<Feature>(), "ID", "Name")) %>
                <%: Html.ValidationMessageFor(model => model.Feature) %>
            </div>
            <p>
                <input type="submit" value="Save" />
            </p>
        </fieldset>
    <% } %>

    <div>
        <%: Html.ActionLink("Back to List", "Index") %>
    </div>
</asp:Content>



