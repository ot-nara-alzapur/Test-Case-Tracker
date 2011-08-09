<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<QA_Test_Tracker.Models.TestPlan>>" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Test Plans
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <p>
        <%: Html.ActionLink("Create New", "Create") %>
    </p>
    <table>
        <tr>
            <th></th>

            <th>
                Feature
            </th>

            <th>
                TestCases
            </th>

            <th>
                Name
            </th>

        </tr>

    <% foreach (var item in Model) { %>
        <tr>

            <td>
                <%: Html.ActionLink("Edit", "Edit", new { id=item.ID }) %> |
                <%: Html.ActionLink("Details", "Details", new { id=item.ID }) %> |
                <%: Html.ActionLink("Delete", "Delete", new { id=item.ID }) %>
            </td>

            <td>
			    <%: (item.Feature == null ? "None" : item.Feature.Name) %>
            </td>

            <td>
			    <%: (item.TestCases == null ? "None" : item.TestCases.Count.ToString()) %>
            </td>

            <td>
			    <%: item.Name %>
            </td>

        </tr>  
    <% } %>

    </table>
</asp:Content>