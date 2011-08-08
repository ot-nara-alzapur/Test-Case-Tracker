<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<QA_Test_Tracker.Models.Build>" %>

<div class="editor-label">
    <%: Html.LabelFor(model => model.BuildNumber) %>
</div>
<div class="editor-field">
    <%: Html.EditorFor(model => model.BuildNumber) %>
    <%: Html.ValidationMessageFor(model => model.BuildNumber) %>
</div>

