<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<QA_Test_Tracker.Models.Release>" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Release Details
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="headContent" runat="server">
    <link rel="stylesheet" type="text/css" media="screen" href="<%: Url.Content("~/content/themes/ui.jqgrid.css") %>" />
    <link rel="stylesheet" type="text/css" media="screen" href="<%: Url.Content("~/content/themes/smoothness/jquery-ui-1.8.15.custom.css") %>" />
    <style>
        .ui-jqgrid {font-size:0.8em}
    </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
 
    <fieldset>
        <legend>Release</legend>
    
        <div class="display-label">Release Date</div>
        <div class="display-field"><%: String.Format("{0:d}", Model.ReleaseDate) %></div>
    
        <div class="display-label">Release Ticket Number</div>
        <div class="display-field"><%: Model.ReleaseTicketNumber %></div>
        <div class="display-label">Builds:</div>
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
                        <div style="text-align:right"><%: Html.ActionLink("Add Build", "Create", "Build", new { releaseID = Model.ID }, null) %></div>
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
            url: '/Build/List/?releaseID=' + <%: Model.ID %>,
            datatype: "json",
            colModel: [
   		        { name: 'ID', index: 'ID', label: 'ID', align:'center' },
   		        { name: 'Name', index: 'Name', label: 'Product', align:'center' },
   		        { name: 'Count', index: 'Count', label: 'Test Plan Count', align:'center' },
   		        { name: 'ReleaseDate', index: 'Release', label: 'Release', align:'center' },
   		        { name: 'BuildNumber', index: 'BuildNumber', label: 'Build Number', align:'center' },
                { name: 'Edit', index: 'Edit', label: 'Actions', edittype:'select', formatter:EditLinkFormatter, align:'center', formatoptions:{baseLinkUrl: '/Build/Details/' } }
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
            return '<a href=\'/Build/Details/' + rowObject[0] + '\'>Details</a>';
        }
    </script>
</asp:Content>