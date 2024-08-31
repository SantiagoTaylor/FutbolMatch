<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Webforms/masterPage.Master" CodeBehind="frmMyEstablishment.aspx.cs" Inherits="UI.Webforms.frmMyEstablishment" %>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link rel="stylesheet" href="../Styles/style-structs.css">
    <script type="text/javascript">

        function getDataEst() {

            PageMethods.GetDataMyEstablishment(onsuccess, onfailed);

            function onsuccess(result) {
                console.clear();
                dataEsts = JSON.parse(result);
                console.log(dataEsts);
                $(".items-ests").empty();
                $.each(dataEsts, function (index, e) {
                    var op = $("<option></option>").val(e.Id).text(e.Name);
                    $(".items-ests").append(op);
                });
            }
            function onfailed(result) {
                alert("Error");
            }
        }

        window.onload = function () {
            getDataEst();
        };
    </script>
    <form runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true"></asp:ScriptManager>
        <section class="container-controls">
            <select class="items-ests form-select">
            </select>
        </section>
        <section class="container-content">
        </section>
    </form>
</asp:Content>
