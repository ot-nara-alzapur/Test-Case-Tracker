<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="QA_Test_Tracker.Views.RepositoryViewPage<QA_Test_Tracker.Models.TestComponent, QA_Test_Tracker.Configuration.TestTrackerDatabase>" %>
<%@ Import Namespace="QA_Test_Tracker.Models" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Edit Test Component
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
 
    <% using (Html.BeginForm()) { %>
        <%: Html.ValidationSummary(true) %>
        <fieldset>
            <legend>TestComponent</legend>
    
            <%: Html.HiddenFor(model => model.ID) %><
            <div class="editor-label">
                <%: Html.LabelFor(model => model.Name) %>
            </div>
            <div class="editor-field">
                <%: Html.EditorFor(model => model.Name) %>
                <%: Html.ValidationMessageFor(model => model.Name) %>
            </div>

            <div class="editor-label">
                <%: Html.LabelFor(model => model.Description) %>
            </div>
            <div class="editor-field">
                <%: Html.EditorFor(model => model.Description) %>
                <%: Html.ValidationMessageFor(model => model.Description) %>
            </div>
            <div class="editor-label">
            <%: Html.LabelFor(model => model.Product)%>
            </div>
            <div class="editor-field">
                <%: Html.DropDownListFor(model => model.Product.ID, new SelectList(GetAll<Product>(), "ID", "Name"))%>
                <%: Html.ValidationMessageFor(model => model.Product)%>
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