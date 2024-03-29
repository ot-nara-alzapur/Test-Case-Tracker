<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<QA_Test_Tracker.Models.TestCase>" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Test Case Details
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="headContent" runat="server">
    <link rel="stylesheet" type="text/css" media="screen" href="<%: Url.Content("~/content/themes/ui.jqgrid.css") %>" />
    <link rel="stylesheet" type="text/css" media="screen" href="<%: Url.Content("~/content/themes/smoothness/jquery-ui-1.8.15.custom.css") %>" />
    <style>
        .ui-jqgrid {font-size:0.8em}
        .ui-jqgrid tr.jqgrow td { white-space:normal; }
    </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <fieldset>
        <legend>Test Case</legend>


        <div class="display-label">Name</div>
        <div class="display-field"><%: Model.Name %></div>

        <div class="display-label">Component</div>
        <div class="display-field"><%: (Model.TestComponent == null ? "None" : Model.TestComponent.Name)%></div>

        <div class="display-label">Steps</div>
        <div class="display-field"><%: (Model.Tests == null ? "None" : Model.Tests.Count.ToString()) %></div>
        <div class="display-label">Test Steps:</div>
        <div class="display-field">
            <table width="100%">
                <tr>
                    <td>
                        <table id="list2"></table>
                        <div id="pager2"></div>
                    </td>
                </tr>
                <tr>
                    <td>
                        <div style="text-align:right"><%: Html.ActionLink("Add Test Step", "Create", "TestStep", new { testCaseID = Model.ID }, null) %></div>
                    </td>
                </tr>
            </table>
        </div>
    </fieldset>
    <p>


        <%: Html.ActionLink("Edit", "Edit", new { id=Model.ID }) %> |
        <%: Html.ActionLink("Back to Test Plan", "Details", "TestPlan", new { id=Model.TestPlan.ID }, null) %>

    </p>
    <script language="javascript" type="text/javascript">
        jQuery("#list2").jqGrid({
            url: '/TestStep/List/?testCaseID=' + <%: Model.ID %>,
            datatype: "json",
            colModel: [
   		        { name: 'ID', index: 'ID', label: 'ID', align:'center' },
   		        { name: 'Name', index: 'Name', label: 'Name', align:'center' },
                { name: 'Edit', index: 'Edit', label: 'Actions', edittype:'select', formatter:EditLinkFormatter, align:'center', formatoptions:{baseLinkUrl: '/TestCase/Details/' } }
   	        ],
            rowNum: 10,
            rowList: [10, 20, 30],
            pager: '#pager2',
            sortname: 'ID',
            viewrecords: true,
            sortorder: "asc",
            autowidth:true
            });
        jQuery("#list2").jqGrid('navGrid', '#pager2', { edit: false, add: false, del: false });

        function EditLinkFormatter(cellvalue, options, rowObject)
        {
            return '<a href=\'/TestStep/Details/' + rowObject[0] + '\'>Details</a>';
        }
    </script>
</asp:Content>