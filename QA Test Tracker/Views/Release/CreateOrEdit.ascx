<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<QA_Test_Tracker.Models.Release>" %>

<div class="editor-label">
    <%: Html.LabelFor(model => model.ReleaseDate) %>
</div>
<div class="editor-field">
    <%: Html.EditorFor(model => model.ReleaseDate) %>
    <%: Html.ValidationMessageFor(model => model.ReleaseDate) %>
</div>

<div class="editor-label">
    <%: Html.LabelFor(model => model.ReleaseTicketNumber) %>
</div>
<div class="editor-field">
    <%: Html.EditorFor(model => model.ReleaseTicketNumber) %>
    <%: Html.ValidationMessageFor(model => model.ReleaseTicketNumber) %>
</div>

