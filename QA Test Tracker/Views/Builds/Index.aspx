<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<QA_Test_Tracker.Models.Build>>" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Builds
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
 
    <p>
        <%: Html.ActionLink("Create New", "Create") %>
    </p>
    <table>
        <tr>
            <th></th>
            <th>
                Product
            </th>
            <th>
                BuildNumber
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
    			<%: (item.Product == null ? "None" : item.Product.Name) %>
            </td>
            <td>
    			<%: item.BuildNumber %>
            </td>
        </tr>  
    <% } %>
    
    </table>
</asp:Content>