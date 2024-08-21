<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="frmEstablishments.aspx.cs" MasterPageFile="~/Webforms/masterPage.Master" Inherits="UI.Webforms.frmEstablishments" EnableEventValidation="false" Debug="true" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link rel="stylesheet" href="/Styles/style-structs.css">
    <link rel="stylesheet" href="../Styles/style-establishment.css">
    <link rel="stylesheet" href="../Styles/style-animation.css">

    <script type="text/javascript">
        document.addEventListener("DOMContentLoaded", function () {
            let estalbishments = document.querySelector('.container-establishment');
            $(".container-details-establishment").css("visibility", "hidden");
            $(".lds-ellipsis").css("visibility", "hidden");
            var dataCurrentEst;

            function showElement(e, id) {
                if (id != null) {
                    document.getElementById('<%= HiddenFieldEstablishmentID.ClientID %>').value = id;
                }
                else if (id == null) {
                    document.querySelector('.container-data').innerHTML = "";
                    document.getElementById('droplist').value = "users";
                    showData(document.getElementById('droplist'));
                    
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

            function getDataEst(x, eDetailsEstablishment) {
                estalbishments.classList.add("disenable-container");
                $(".lds-ellipsis").css("visibility", "visible");

                var dataId = x.getAttribute('data-id');
                PageMethods.GetDataEstablishment(dataId, onsuccess, onfailed);

                function onsuccess(result) {
                    $(".lds-ellipsis").css("visibility", "hidden");
                    console.clear();
                    dataCurrentEst = JSON.parse(result);
                    console.log(dataCurrentEst);
                    $("#establishment-name").text(dataCurrentEst.Name);
                    $("#establishment-phone").text(dataCurrentEst.Phone);
                    $("#establishment-email").text(dataCurrentEst.Address);
                    $("#establishment-address").text(dataCurrentEst.Email);
                    $("#establishment-owner").text(/*result.Owner*/" Nombre del Dueño");
                    showElement(eDetailsEstablishment);
                }
                function onfailed(result) {
                    alert("Error");
                }
            }

            function showData(e) {
                document.querySelector('.container-data').innerHTML = "";
                const sltValue = e.value;
                let objs = "";
                if (sltValue === "users") {
                    dataCurrentEst.Employees.forEach((emp) => {
                        const elEmp = ` 
                        <article class="col-md-4 mt-1 fade-in-slide">
                             <div class="card p-0">
                                 <div class="row g-0">
                                     <div class="col-md-4">
                                         <img class="bd-placeholder-img img-fluid rounded-start" src="https://media.licdn.com/dms/image/C4D03AQEH5EGs0OkeTw/profile-displayphoto-shrink_400_400/0/1544222558401?e=2147483647&v=beta&t=9J2nsw37uSb5_1q6yQ2E5Dlpzf4cr1j00uh___veQ9k"
                                             alt="Imagen" style="width: 100%; height: 100%; object-fit: cover;">
                                     </div>
                                     <div class="col-md-8">
                                         <div class="card-body">
                                             <h5 class="card-title fs-6">${emp.Name} ${emp.Lastname}</h5>
                                             <div class="d-flex flex-column">
                                                 <p class="card-text mb-0" style="font-size:.8rem;"><strong>Dni:</strong> 2054237645</p>
                                                 <p class="card-text mb-0" style="font-size:.8rem;"><strong>Telefono:</strong> ${emp.Phone}</p>
                                                 <p class="card-text mb-0" style="font-size:.8rem;"><strong>Email:</strong> ${emp.Email}</p>
                                                 <p class="card-text mb-0" style="font-size:.8rem;"><strong>Estado:</strong> ${emp.Blocked}</p>
                                             </div>
                                         </div>
                                     </div>
                                 </div>
                             </div>
                         </article>`;
                        objs += elEmp;
                    });

                } else if (sltValue === "fields") {
                    dataCurrentEst.Fields.forEach((field) => {
                        const elField = ` 
                            <article class="col-md-4 mt-1 fade-in-slide">
                                 <div class="card p-0">
                                     <div class="row g-0">
                                         <div class="col-md-4">
                                             <img class="bd-placeholder-img img-fluid rounded-start" src="https://www.hoysejuega.com/uploads/Modules/ImagenesComplejos/800_600_papi-futbol-pichus.jpg"
                                                 alt="Imagen" style="width: 100%; height: 100%; object-fit: cover;">
                                         </div>
                                         <div class="col-md-8">
                                             <div class="card-body">
                                                 <h5 class="card-title fs-6">${field.FieldName}</h5>
                                                 <div class="d-flex flex-column">
                                                     <p class="card-text mb-0" style="font-size:.8rem;"><strong>Tipo:</strong> ${field.FloorType}</p>
                                                     <p class="card-text mb-0" style="font-size:.8rem;"><strong>Tamaño:</strong> ${field.Size}</p>
                                                 </div>
                                             </div>
                                         </div>
                                     </div>
                                 </div>
                             </article>`;
                        objs += elField;
                    });

                }
                $(".container-data").append(objs);
            }

            window.showElement = showElement;
            window.hideElement = hideElement;
            window.getDataEst = getDataEst;
            window.showData = showData;

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

            <div class="lds-ellipsis position-absolute align-self-center mx-auto d-flex flex-column justify-content-center align-items-center z-3">
                <div></div>
                <div></div>
                <div></div>
                <div></div>
            </div>

            <div class="container-establishment w-100 h-100 position-relative d-flex flex-column align-items-center">
                <asp:Repeater runat="server" ID="RepeaterEstablishments">
                    <ItemTemplate>
                        <article class="item-establishment m-2 d-flex" data-id="<%# Eval("idEstablishment")%>" onclick="getDataEst(this,document.querySelector('.container-details-establishment')); return false;">
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
                    </ItemTemplate>
                </asp:Repeater>
            </div>

            <div class="confirmation-box w-25 h-25 bg-light position-absolute align-self-center mx-auto rounded-3 d-flex flex-column justify-content-center align-items-center border border-2 border-secundary" style="visibility: hidden;">
                <p class="text-center">¿Esta seguro que desea eliminar el establecimiento?</p>
                <section>
                    <asp:Button runat="server" Text="Si" CssClass="btn btn-outline-danger" ID="ButtonDeleteConfirm" OnClick="ButtonDeleteConfirm_Click" />
                    <asp:Button runat="server" Text="Cancelar" CssClass="btn btn-outline-primary" OnClientClick="hideElement(document.querySelector('.confirmation-box')); return false;" />
                </section>
            </div>

            <div class="container-details-establishment w-75 h-100 bg-light position-absolute">
                <!-- Datos del establecimiento -->
                <header class="row mt-2" style="height: 15%; width: 100%;">
                    <article class="col-1">
                        <button class="btn btn-light mt-3" onclick="hideElement(document.querySelector('.container-details-establishment')); return false;">
                            <i class="bi bi-arrow-left fs-3"></i>
                        </button>
                    </article>
                    <article class="col-11">
                        <h4 id="establishment-name">Nombre establecimiento</h4>
                        <p class="m-0" id="establishment-address">1</p>
                        <p class="m-0" id="establishment-phone">2</p>
                        <p class="m-0" id="establishment-email">3</p>
                        <p class="m-0" id="establishment-owner">4</p>
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
                            <!-- Tarjeta -->
                            <!--
                            <article class="col-md-4 mt-1">
                                <div class="card p-0">
                                    <div class="row g-0">
                                        <div class="col-md-4">
                                            <img class="bd-placeholder-img img-fluid rounded-start" src="https://media.licdn.com/dms/image/C4D03AQEH5EGs0OkeTw/profile-displayphoto-shrink_400_400/0/1544222558401?e=2147483647&v=beta&t=9J2nsw37uSb5_1q6yQ2E5Dlpzf4cr1j00uh___veQ9k"
                                                alt="Imagen" style="width: 100%; height: 100%; object-fit: cover;">
                                        </div>
                                        <div class="col-md-8">
                                            <div class="card-body">
                                                <h5 class="card-title">Lucas Stockel</h5>
                                                <div class="d-flex flex-column">
                                                    <p class="card-text mb-0">Dni:</p>
                                                    <p class="card-text mb-0">Teléfono:</p>
                                                    <p class="card-text mb-0">Email:</p>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </article>
                            -->
                        </div>
                    </section>
                </main>
            </div>

        </section>
    </form>
    <script src="../Scripts/jquery-3.7.1.min.js"></script>
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@3.4.1/dist/js/bootstrap.min.js" integrity="sha384-aJ21OjlMXNL5UyIl/XNwTMqvzeRMZH2w8c5cRVpzpU8Y5bApTppSuUkhZXN0VxHd" crossorigin="anonymous"></script>

</asp:Content>
