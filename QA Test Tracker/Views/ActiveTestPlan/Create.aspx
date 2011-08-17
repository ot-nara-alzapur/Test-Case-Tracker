<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="QA_Test_Tracker.Views.RepositoryViewPage<QA_Test_Tracker.Models.Build, QA_Test_Tracker.Configuration.TestTrackerDatabase>" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Add Test Plan
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
    <% using (Html.BeginForm()) { %>
        <%: Html.ValidationSummary(true) %>
        <fieldset>
            <legend>Add a Test Plan</legend>

            <div class="editor-label">
                <%: Html.LabelFor(model => model.Release.ReleaseDate) %>
            </div>
            <div class="editor-field">
                <%: Model.Release.ReleaseDate.ToShortDateString() %>
            </div>            
		    <div class="editor-label">
                <%: Html.LabelFor(model => model.BuildNumber) %>
            </div>
            <div class="editor-field">
                <%: Model.BuildNumber %>
            </div> 
            <div class="display-label">Available Test Plans:</div>
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
                            <div style="text-align:right"><%: Html.ActionLink("Add Test Plan", "Create", "TestPlan") %></div>
                        </td>
                    </tr>
                </table>
            </div>           
            <p>
                <a id="submit" href="">Add Selected Test Plans</a>
            </p>
        </fieldset>
    <% } %>

    <div>
        <%: Html.ActionLink("Back to List", "Index") %>
    </div>
    <script language="javascript" type="text/javascript">
        jQuery("#list2").jqGrid({
            url: '/TestPlan/List/?buildID=' + <%: Model.ID %>,
            datatype: "json",
            colModel: [
   		        { name: 'ID', index: 'ID', label: 'ID', align:'center' },
   		        { name: 'Name', index: 'Name', label: 'Product', align:'center' },
   		        { name: 'Count', index: 'Count', label: 'Test Case Count', align:'center' },
   		        { name: 'Feature', index: 'Feature', label: 'Feature Name', align:'center' },
                { name: 'Details', index: 'Details', label: 'Actions', edittype:'select', formatter:EditLinkFormatter, align:'center', formatoptions:{baseLinkUrl: '/Build/Details/' } }
   	        ],
            rowNum: 10,
            rowList: [10, 20, 30],
            pager: '#pager2',
            sortname: 'ID',
            viewrecords: true,
            sortorder: "asc",
            autowidth:true,
            multiselect: true,
            multiboxonly:true 
            });
        jQuery("#list2").jqGrid('navGrid', '#pager2', { edit: false, add: false, del: false });

        function EditLinkFormatter(cellvalue, options, rowObject)
        {
            return '<a href=\'/TestPlan/Details/' + rowObject[0] + '\'>Details</a>';
        }

        $('#submit').click(function () {

        var multiplerowdata = jQuery("#list2").getGridParam('selarrrow');  

        $.ajax({ type: 'POST',
            url: '/ActiveTestPlan/Add/?buildID=<%: Model.ID %>',
            data: JSON.stringify(multiplerowdata),
            traditional: true, 
            dataType: "json",
            contentType: "application/json; charset=utf-8",
            success: function () { alert("row submited"); }
        });}) 
    </script>
</asp:Content>