<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Webforms/masterPage.Master" CodeBehind="frmMyEstablishment.aspx.cs" Inherits="UI.Webforms.frmMyEstablishment" %>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link rel="stylesheet" href="../Styles/style-structs.css">
    <link rel="stylesheet" href="../Styles/style-animation.css">
    <link rel="stylesheet" href="../Styles/style-establishment.css">
    <script type="text/javascript">

        var estData = null;

        function getDataEst() {

            PageMethods.GetDataMyEstablishment(onsuccess, onfailed);

            function onsuccess(result) {
                $(".container-controls, .container-content").css({
                    "transition": "filter 0.5s ease",
                    "filter": "none"
                });

                var iconLoad = $(".icon-load");
                iconLoad.addClass("blur-out-contract");

                //Oculta la carga desdpues que termine la animacion
                iconLoad.on('animationend', function () {
                    hideElement(iconLoad);
                });

                console.clear();
                estData = JSON.parse(result);

                console.log(estData);
                $(".items-ests").empty();
                $.each(estData, function (index, e) {
                    var op = $("<option></option>").val(e.Id).text(e.Name);
                    $(".items-ests").append(op);
                });
                getSltDataEst($(".items-ests")[0]);
            }
            function onfailed(result) {
                alert("Error");
            }
        }

        function hideElement(e) {
            e.css("visibility", "hidden");
        }

        function getSltDataEst(x) {
            console.log(x);
            $.each(estData, function (index, e) {
                if ($(x).val() == e.Id) {
                    console.log(e);
                    $(".establishment-name").text(e.Name);
                    $(".establishment-address").text(e.Address);
                    $(".establishment-email").text(e.Email);
                    $(".establishment-phone").text(e.Phone);
                    showData(document.getElementById('droplist'), e);
                }
            });
            
        }

        window.onload = function () {
            getDataEst();
        };
    </script>
    <form runat="server">
        <section class="icon-load position-absolute d-flex flex-column justify-content-center align-items-center z-3 w-100 h-100">
            <div class="lds-ellipsis">
                <div></div>
                <div></div>
                <div></div>
                <div></div>
            </div>
        </section>
        <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true"></asp:ScriptManager>
        <section class="container-controls" style="filter: blur(5px);">
            <select class="items-ests form-select" onchange='getSltDataEst(this);'>
            </select>
        </section>
        <section class="container-content" style="filter: blur(5px);">
            <header class="row w-100 h-25 ms-1">
                <article class="col-12 p-3">
                    <h4 class="establishment-name"></h4>
                    <p class="m-0 establishment-address"></p>
                    <p class="m-0 establishment-phone"></p>
                    <p class="m-0 establishment-email"></p>
                    <p class="m-0 establishment-owner"></p>
                </article>
            </header>

            <main class="w-100 p-3 d-flex justify-content-start">
                <section class="w-100 mb-2">
                    <div class="p-3">
                        <select id="droplist" class="form-select" style="width: 15%" onchange="showData(this)">
                            <option value="users">Usuarios</option>
                            <option value="fields">Canchas</option>
                        </select>
                    </div>
                </section>

                <section class="w-100 ps-3">
                    <div class="container-data row">
                        <!-- Tarjetas -->
                    </div>
                </section>
            </main>


        </section>
    </form>
    <script src="../Scripts/scripts-forms/data-establishment.js"></script>
</asp:Content>
