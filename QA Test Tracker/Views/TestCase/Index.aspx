<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<QA_Test_Tracker.Models.TestCase>>" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Test Cases
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <p>
        <%: Html.ActionLink("Create New", "Create") %>
    </p>
    <table>
        <tr>
            <th></th>

            <th>
                Name
            </th>

            <th>
                Component
            </th>

            <th>
                Tests
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
			    <%: item.Name %>
            </td>

            <td>
			    <%: (item.Component == null ? "None" : item.Component.Name) %>
            </td>

            <td>
			    <%: (item.Tests == null ? "None" : item.Tests.Count.ToString()) %>
            </td>

        </tr>  
    <% } %>

    </table>
</asp:Content>