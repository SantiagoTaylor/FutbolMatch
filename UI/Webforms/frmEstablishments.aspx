<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="frmEstablishments.aspx.cs" MasterPageFile="~/Webforms/masterPage.Master" Inherits="UI.Webforms.frmEstablishments" EnableEventValidation="false" %>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link rel="stylesheet" href="/Styles/style-structs.css">
    <link rel="stylesheet" href="../Styles/style-establishment.css">
    <link rel="stylesheet" href="../Styles/style-animation.css">

    <script>
        document.addEventListener("DOMContentLoaded", function () {
            let confirmBox = document.querySelector('.confirmation-box');
            confirmBox.style.visibility = "hidden";

            function showConfirmationBox(id) {
                document.getElementById('<%= HiddenFieldEstablishmentID.ClientID %>').value = id;
                confirmBox.style.visibility = 'visible';
                confirmBox.classList.remove("blur-out-contract");
                confirmBox.classList.add("blur-in-expand");
            }

            function hideConfirmationBox() {
                confirmBox.classList.remove("blur-in-expand");
                confirmBox.classList.add("blur-out-contract");

                setTimeout(() => {
                    confirmBox.style.visibility = 'hidden';
                }, 300);
            }

            window.showConfirmationBox = showConfirmationBox;
            window.hideConfirmationBox = hideConfirmationBox;
        });
    </script>

    <form runat="server">
        <asp:HiddenField runat="server" ID="HiddenFieldEstablishmentID"/>
        <section class="container-controls d-flex justify-content-center align-items-center">

            <section class="container-btn">
                <asp:Button ID="ButtonRegisterEstablishment" CssClass="btn btn-light w-auto" runat="server" OnClick="ButtonRegisterEstablishment_Click" Text="Registrar Establecimiento" />
            </section>
        </section>

        <section class="container-content overflow-auto d-flex flex-column justify-content-center">
            <asp:Repeater runat="server" ID="RepeaterEstablishments">
                <ItemTemplate>
                    <article class="item-establishment m-3 d-flex overflow-hidden w-auto" id="<%# Eval("idEstablishment")%>">
                        <section class="establishment-info card-body p-4">
                            <h4><%# Eval("establishmentName") %></h4>
                            <p class="m-0"><strong>Domicilio:</strong>  <%# Eval("address") %></p>
                            <p class="m-0"><strong>Teléfono:</strong> <%# Eval("phone") %></p>
                            <p class="m-0"><strong>Email:</strong> <%# Eval("email") %></p>
                        </section>
                        <section class="d-flex align-items-center me-4">
                            <img src="https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQpudfgo73PdT_gISV6TWn9i5mhcx-26ZXxn_4Oh5Qr03jwKy0_jeBwlgnh50b4IFZoF7M&usqp=CAU"
                                alt="Imagen Establecimiento"
                                class="img-fluid"
                                style="width: 100px; height: 100px;" />
                        </section>
                        <section class="btn-group-vertical" role="group">
                            <input type="button" id="ButtonDelete" class="btn btn btn-outline-danger"
                                onclick="showConfirmationBox('<%# Eval("idEstablishment") %>')" value="Eliminar" />
                            <asp:Button runat="server" ID="ButtonModificate" Text="Modificar" CssClass="btn btn btn-outline-primary"
                                CommandName="Modify"
                                CommandArgument='<%# Eval("idEstablishment") %>'
                                OnCommand="Button_Command" />
                        </section>
                    </article>
                </ItemTemplate>
            </asp:Repeater>
            <div class="confirmation-box w-25 h-25 bg-light position-absolute align-self-center rounded-3 d-flex flex-column justify-content-center align-items-center border border-2 borfder-secundary">
                <p class="text-center">¿Esta seguro que desea eliminar el establecimiento?</p>
                <section>
                    <asp:Button runat="server" Text="Si" CssClass="btn btn-outline-danger" ID="ButtonDeleteConfirm" OnClick="ButtonDeleteConfirm_Click" />
                    <asp:Button runat="server" Text="Cancelar" CssClass="btn btn-outline-primary" OnClientClick="hideConfirmationBox(); return false;" />
                </section>
            </div>
        </section>
        
    </form>
</asp:Content>
