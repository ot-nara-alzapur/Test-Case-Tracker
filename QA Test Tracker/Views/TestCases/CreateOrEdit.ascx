<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<QA_Test_Tracker.Models.TestCase>" %>


<div class="editor-label">
    <%: Html.LabelFor(model => model.Name) %>
</div>
<div class="editor-field">
    <%: Html.EditorFor(model => model.Name) %>
    <%: Html.ValidationMessageFor(model => model.Name) %>
</div>



