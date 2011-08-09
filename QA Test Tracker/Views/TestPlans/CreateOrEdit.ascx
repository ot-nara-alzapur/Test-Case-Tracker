<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<QA_Test_Tracker.Models.TestPlan>" %>
<%@ Import Namespace="QA_Test_Tracker.Models" %>
<%@ Import Namespace="QA_Test_Tracker.Views" %>

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
    <%: Html.DropDownListFor(model => model.Feature, new SelectList(((IRepositoryViewPage)this.Page).GetAll<Feature>())) %>
    <%: Html.ValidationMessageFor(model => model.Feature) %>
</div>
