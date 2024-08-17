<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="frmEstablishments.aspx.cs" MasterPageFile="~/Webforms/masterPage.Master" Inherits="UI.Webforms.frmEstablishments" EnableEventValidation="false" %>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link rel="stylesheet" href="/Styles/style-structs.css">
    <link rel="stylesheet" href="/Styles/style-gv.css">
    <link rel="stylesheet" href="../Styles/style-establishment.css">
    <script>
        function confirmAction(action, establishmentName) {
            if (confirm("Are you sure you want to " + action + " establishment " + establishmentName + "?")) {
                return true;
            } else {
                return false;
            }
        }
    </script>

    <form runat="server">
        <section class="container-controls d-flex justify-content-center align-items-center">

            <section class="container-btn">
                <asp:Button ID="ButtonRegisterEstablishment" CssClass="btn btn-light w-auto" runat="server" OnClick="ButtonRegisterEstablishment_Click" Text="Registrar Establecimiento" />
            </section>
        </section>

        <section class="container-content overflow-auto">

            <asp:Repeater runat="server" ID="RepeaterEstablishments">
                <ItemTemplate>
                    <article class="item-establishment m-3 d-flex overflow-hidden w-auto" id="<%# Eval("idEstablishment")%>">
                        <section class="establishment-info card-body p-4">
                            <h4><%# Eval("establishmentName") %></h4>
                            <p class="m-0">Domicilio: <%# Eval("address") %></p>
                            <p class="m-0">Teléfono: <%# Eval("phone") %></p>
                            <p class="m-0">Email: <%# Eval("email") %></p>
                        </section>
                        <section class="d-flex align-items-center me-4">
                            <img src="https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQpudfgo73PdT_gISV6TWn9i5mhcx-26ZXxn_4Oh5Qr03jwKy0_jeBwlgnh50b4IFZoF7M&usqp=CAU"
                                alt="Imagen Establecimiento"
                                class="img-fluid"
                                style="width: 100px; height: 100px;" />
                        </section>
                        <section class="btn-group-vertical" role="group">

                            <asp:Button runat="server" ID="ButtonDelete" Text="Eliminar" CssClass="btn btn btn-outline-danger"
                                CommandName="Delete"
                                CommandArgument='<%# Eval("idEstablishment") %>'
                                OnCommand="Button_Command" />

                            <asp:Button runat="server" ID="ButtonModificate" Text="Modificar" CssClass="btn btn btn-outline-primary"
                                CommandName="Modify"
                                CommandArgument='<%# Eval("idEstablishment") %>'
                                OnCommand="Button_Command" />
                        </section>
                    </article>
                </ItemTemplate>
            </asp:Repeater>
        </section>
    </form>
</asp:Content>
