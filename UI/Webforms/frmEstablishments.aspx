<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="frmEstablishments.aspx.cs" MasterPageFile="~/Webforms/masterPage.Master" Inherits="UI.Webforms.frmEstablishments" EnableEventValidation="false" Debug="true" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link rel="stylesheet" href="/Styles/style-structs.css">
    <link rel="stylesheet" href="../Styles/style-establishment.css">
    <link rel="stylesheet" href="../Styles/style-animation.css">

    <script type="text/javascript">
        document.addEventListener("DOMContentLoaded", function () {

            let confirmBox = document.querySelector('.confirmation-box');
            let estalbishments = document.querySelector('.container-establishment');
            let detailsEstablishment = document.querySelector('.container-details-establishment');

            confirmBox.style.visibility = "hidden";

            function showElement(e, id) {
                if (id != null) {
                    document.getElementById('<%= HiddenFieldEstablishmentID.ClientID %>').value = id;
                }
                estalbishments.classList.add("disenable-container");
                e.style.visibility = 'visible';
                e.classList.remove("blur-out-contract");
                e.classList.add("blur-in-expand");
            }

            function hideElement(e) {
                estalbishments.classList.remove("disenable-container");
                e.classList.remove("blur-in-expand");
                e.classList.add("blur-out-contract");
                hideElementAfterTimeout(e);
            }

            function hideElementAfterTimeout(e) {
                setTimeout(() => {
                    e.style.visibility = 'hidden';
                }, 300);
            }

            function getDataEst(x) {
                var dataId = x.getAttribute('data-id');
                PageMethods.GetDataEstablishment(dataId, onsuccess, onfailed);
                function onsuccess(result) {
                    console.clear();
                    //console.log(result);
                    var obj = JSON.parse(result);
                    console.log(obj);
                    $("#establishment-name").text(obj.Name);
                    $("#establishment-phone").text(obj.Phone);
                    $("#establishment-email").text(obj.Address);
                    $("#establishment-address").text(obj.Email);
                    $("#establishment-owner").text(/*result.Owner*/" Nombre del Dueño");
                }
                function onfailed(result) {
                    alert("Error");
                }
            }

            window.showElement = showElement;
            window.hideElement = hideElement;

            window.getDataEst = getDataEst;
        });

    </script>

    <form runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true"></asp:ScriptManager>
        <asp:HiddenField runat="server" ID="HiddenFieldEstablishmentID" />

        <section class="container-controls d-flex justify-content-center align-items-center">
            <section class="container-btn">
                <asp:Button ID="ButtonRegisterEstablishment" CssClass="btn btn-light w-auto" runat="server" OnClick="ButtonRegisterEstablishment_Click" Text="Registrar Establecimiento" />
            </section>
        </section>

        <section class="container-content d-flex flex-column justify-content-center align-items-center overflow-auto">
            <div class="container-establishment w-100 h-100 position-relative d-flex flex-column align-items-center">
                <asp:Repeater runat="server" ID="RepeaterEstablishments">
                    <itemtemplate>
                        <article class="item-establishment m-2 d-flex" data-id="<%# Eval("idEstablishment")%>" onclick="showElement(document.querySelector('.container-details-establishment')); getDataEst(this); return false;">
                            <section class="establishment-info card-body p-2 ps-4">
                                <h4><%# Eval("establishmentName") %></h4>
                                <p class="m-0"><strong>Domicilio:</strong>  <%# Eval("address") %></p>
                                <p class="m-0"><strong>Teléfono:</strong> <%# Eval("phone") %></p>
                                <p class="m-0"><strong>Email:</strong> <%# Eval("email") %></p>
                            </section>
                            <section class="d-flex align-items-center me-4">
                                <img src="https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQpudfgo73PdT_gISV6TWn9i5mhcx-26ZXxn_4Oh5Qr03jwKy0_jeBwlgnh50b4IFZoF7M&usqp=CAU"
                                    alt="Imagen del Establecimiento"
                                    class="img-fluid"
                                    style="width: 100px; height: 100px; mix-blend-mode: multiply;" />
                            </section>
                            <section class="btn-group-vertical" role="group">
                                <input type="button" id="ButtonDelete" class="btn btn btn-outline-danger"
                                    onclick="showElement(document.querySelector('.confirmation-box'), '<%# Eval("idEstablishment") %>'); event.stopPropagation();" value="Eliminar" />
                                <asp:Button runat="server" ID="ButtonModificate" Text="Modificar" CssClass="btn btn btn-outline-primary"
                                    CommandName="Modify"
                                    CommandArgument='<%# Eval("idEstablishment") %>'
                                    OnCommand="Button_Command" />
                            </section>
                        </article>
                    </itemtemplate>
                </asp:Repeater>
            </div>
            <div class="confirmation-box w-25 h-25 bg-light position-absolute align-self-center mx-auto rounded-3 d-flex flex-column justify-content-center align-items-center border border-2 border-secundary">
                <p class="text-center">¿Esta seguro que desea eliminar el establecimiento?</p>
                <section>
                    <asp:Button runat="server" Text="Si" CssClass="btn btn-outline-danger" ID="ButtonDeleteConfirm" OnClick="ButtonDeleteConfirm_Click"/>
                    <asp:Button runat="server" Text="Cancelar" CssClass="btn btn-outline-primary" OnClientClick="hideElement(document.querySelector('.confirmation-box')); return false;" />
                </section>
            </div>
            <div class="container-details-establishment container w-75 h-100 bg-light position-absolute border border-2 border-secundary" style="visibility: hidden;">
                <!-- Datos del estableciemitno : canchas dueño tipo empleados-->
                <section class="row">
                    <article class="col-auto">
                        <button class="btn btn-light mt-3" onclick="hideElement(document.querySelector('.container-details-establishment')); return false;">
                            <i class="bi bi-arrow-left fs-3 "></i>
                        </button>

                    </article>
                    <article class="col pt-3">
                        <h4 id="establishment-name"></h4>
                        <p class="m-0" id="establishment-address"></p>
                        <p class="m-0" id="establishment-phone"></p>
                        <p class="m-0" id="establishment-email"></p>
                        <p class="m-0" id="establishment-owner"></p>
                    </article>

                    <article class="col bg-success">
                        <p>Datos del dueño</p>
                    </article>
                </section>
                <section class="row">
                    <article class="col-12 bg-warning">
                        <!-- Contenido de la primera columna -->
                        <p>Canchas</p>
                    </article>
                </section>

                <section class="row">
                    <article class="col-12 bg-danger">
                        <p>Empleados</p>
                    </article>
                </section>
            </div>
        </section>

    </form>
    <script src="../Scripts/jquery-3.7.1.min.js"></script>
</asp:Content>
