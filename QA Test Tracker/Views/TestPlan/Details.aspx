<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<QA_Test_Tracker.Models.TestPlan>" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Test Plan Details
</asp:Content>

<asp:Content ContentPlaceHolderID="headContent" runat="server">
<link rel="stylesheet" type="text/css" media="screen" href="<%: Url.Content("~/content/themes/ui.jqgrid.css") %>" />
<link rel="stylesheet" type="text/css" media="screen" href="<%: Url.Content("~/content/themes/smoothness/jquery-ui-1.8.15.custom.css") %>" />
<style>
    .ui-jqgrid {font-size:0.8em}
</style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <fieldset>
        <legend>Test Plan</legend>


        <div class="display-label">Feature:</div>
        <div class="display-field"><%: (Model.Feature == null ? "None" : Model.Feature.Name) %></div>


        <div class="display-label">Name:</div>
        <div class="display-field"><%: Model.Name %></div>


        <div class="display-label">Test Cases:</div>
        <div class="display-field">
            <table>
                <tr>
                    <td>
                        <table id="list2"></table>
                        <div id="pager2"></div>
                    </td>
                </tr>
                <tr>
                    <td>
                        <div align=right><%: Html.ActionLink("Add Test Cases", "Create", "TestCase", new { testPlanID = Model.ID }, null) %></div>
                    </td>
                </tr>
            </table>
        </div>
    </fieldset>
    <p>

        <%: Html.ActionLink("Edit", "Edit", new { id=Model.ID }) %> |
        <%: Html.ActionLink("Back to List", "Index") %>

    </p>
    <script language="javascript" type="text/javascript">
        jQuery("#list2").jqGrid({
            url: '/TestCase/List/?testPlanID=' + <%: Model.ID %>,
            datatype: "json",
            colModel: [
   		        { name: 'ID', index: 'ID', label: 'ID', align:'center' },
   		        { name: 'Name', index: 'Name', label: 'Name', align:'center' },
   		        { name: 'Count', index: 'Count', label: 'Count', align:'center' }
   	        ],
            rowNum: 10,
            rowList: [10, 20, 30],
            pager: '#pager2',
            sortname: 'ID',
            viewrecords: true,
            sortorder: "asc",
            width: "700"
            });
        jQuery("#list2").jqGrid('navGrid', '#pager2', { edit: false, add: false, del: false });
    </script>
</asp:Content>



