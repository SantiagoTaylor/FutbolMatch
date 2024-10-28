<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="frmLogin.aspx.cs" Inherits="UI.Webforms.frmLogin" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Inicio Sesion | FutbolMatch</title>
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <link rel="stylesheet" href="../Styles/style-login.css" />
    <link rel="shortcut icon" href="../Images/favicon_io/favicon.ico" type="image/x-icon"/>
    <style>
        .translate-x-full {
            transform: translateX(100%);
        }

        .-translate-x-full {
            transform: translateX(-100%);
        }
    </style>
</head>
<body class="select-none">
    <main>
        <!-- Container Logo -->
        <div id="container-logo" class="container-logo transition-transform w-1/2">
            <section class="text-[#669233] w-1/2 h-auto p-6 transition-transform">
                <span class="text-2xl font-extrabold pb-4">Welcome to</span>
                <img
                    src="../Images/logotype.png"
                    class="img-logo drop-shadow-lg mx-auto mb-4 w-50"
                    alt="Company Logo" />
                <br />
                <span class="msg-init block text-xl font-semibold mb-2">Don't have an account? No worries!</span>
                <!-- Sign Up Section -->
                <article class="text-green-600">
                    <p class="msg-init-meta">
                        Create your account now to start booking the best football fields in town.
              <a href="#"
                  onclick="handleRegisterClick(event)"
                  class="text-blue-500 hover:underline">
                  <asp:Label ID="LabelSignUp" runat="server" Text="<strong>Sign Up</strong>"></asp:Label>
              </a>
                    </p>
                </article>
                <img
                    src="../Images/ball-happy.png"
                    class="w-60 drop-shadow-[2px_2px_10px_rgb(128,128,128)]" />
            </section>
        </div>

        <!-- Container Content -->
        <form runat="server" class="w-1/2 h-full container-content transition-transform">

            <div class="w-1/2">
                <div class="form-login space-y-6">
                    <!-- Heading -->
                    <h3 class="text-2xl font-semibold text-center">Hello!!!</h3>

                    <!-- Input Fields -->
                    <div class="space-y-4">
                        <article class="w-full flex justify-center">
                            <div class="relative z-0 w-3/4 mb-2 group">
                                <asp:TextBox ID="txtUser" runat="server" placeholder=" "
                                    CssClass="block py-2.5 px-0 w-full text-sm text-gray-900 bg-transparent border-0 border-b-2 border-gray-300 appearance-none focus:outline-none focus:ring-0 focus:border-blue-600 peer"></asp:TextBox>
                                <label
                                    for="txtUser"
                                    class="text-start absolute text-sm text-gray-500 duration-300 transform -translate-y-6 scale-75 top-3 -z-10 origin-[0] peer-placeholder-shown:scale-100 peer-placeholder-shown:translate-y-0 peer-focus:scale-75 peer-focus:-translate-y-6 flex items-center">
                                    <svg
                                        xmlns="http://www.w3.org/2000/svg"
                                        fill="none"
                                        viewBox="0 0 24 24"
                                        strokeWidth="{1.5}"
                                        stroke="currentColor"
                                        className="size-6"
                                        class="w-5 mr-2">
                                        <path
                                            strokeLinecap="round"
                                            strokeLinejoin="round"
                                            d="M15.75 6a3.75 3.75 0 1 1-7.5 0 3.75 3.75 0 0 1 7.5 0ZM4.501 20.118a7.5 7.5 0 0 1 14.998 0A17.933 17.933 0 0 1 12 21.75c-2.676 0-5.216-.584-7.499-1.632Z" />
                                    </svg>

                                    Email or Username
                                </label>
                            </div>
                        </article>

                        <article class="w-full flex justify-center">
                            <div class="relative z-0 w-3/4 mb-2 group">
                                <asp:TextBox ID="txtPassword" runat="server" placeholder=" " TextMode="Password"
                                    CssClass="block py-2.5 px-0 w-full text-sm text-gray-900 bg-transparent border-0 border-b-2 border-gray-300 appearance-none focus:outline-none focus:ring-0 focus:border-blue-600 peer"></asp:TextBox>
                                <svg
                                    onclick="showPass(this);"
                                    xmlns="http://www.w3.org/2000/svg"
                                    fill="none"
                                    viewBox="0 0 24 24"
                                    strokeWidth="1.5"
                                    stroke="currentColor"
                                    class="eye absolute right-2 top-1/2 transform -translate-y-1/2 cursor-pointer w-5 h-5">
                                    <path
                                        strokeLinecap="round"
                                        strokeLinejoin="round"
                                        d="M2.036 12.322a1.012 1.012 0 0 1 0-.639C3.423 7.51 7.36 4.5 12 4.5c4.638 0 8.573 3.007 9.963 7.178.07.207.07.431 0 .639C20.577 16.49 16.64 19.5 12 19.5c-4.638 0-8.573-3.007-9.963-7.178Z" />
                                    <path
                                        strokeLinecap="round"
                                        strokeLinejoin="round"
                                        d="M15 12a3 3 0 1 1-6 0 3 3 0 0 1 6 0Z" />
                                </svg>

                                <svg
                                    onclick="hiddenPass(this);"
                                    xmlns="http://www.w3.org/2000/svg"
                                    fill="none"
                                    viewBox="0 0 24 24"
                                    strokeWidth="1.5"
                                    stroke="currentColor"
                                    class="eye-close absolute right-2 top-1/2 transform -translate-y-1/2 cursor-pointer w-5 h-5">
                                    <path
                                        strokeLinecap="round"
                                        strokeLinejoin="round"
                                        d="M3.98 8.223A10.477 10.477 0 0 0 1.934 12C3.226 16.338 7.244 19.5 12 19.5c.993 0 1.953-.138 2.863-.395M6.228 6.228A10.451 10.451 0 0 1 12 4.5c4.756 0 8.773 3.162 10.065 7.498a10.522 10.522 0 0 1-4.293 5.774M6.228 6.228 3 3m3.228 3.228 3.65 3.65m7.894 7.894L21 21m-3.228-3.228-3.65-3.65m0 0a3 3 0 1 0-4.243-4.243m4.242 4.242L9.88 9.88" />
                                </svg>

                                <label
                                    for="txtPassword"
                                    class="text-start absolute text-sm text-gray-500 duration-300 transform -translate-y-6 scale-75 top-3 -z-10 origin-[0] peer-placeholder-shown:scale-100 peer-placeholder-shown:translate-y-0 peer-focus:scale-75 peer-focus:-translate-y-6 flex items-center">
                                    <svg
                                        xmlns="http://www.w3.org/2000/svg"
                                        fill="none"
                                        viewBox="0 0 24 24"
                                        strokeWidth="{1.5}"
                                        stroke="currentColor"
                                        className="size-6"
                                        class="w-4 h-4 mr-2">
                                        <path
                                            strokeLinecap="round"
                                            strokeLinejoin="round"
                                            d="M16.5 10.5V6.75a4.5 4.5 0 1 0-9 0v3.75m-.75 11.25h10.5a2.25 2.25 0 0 0 2.25-2.25v-6.75a2.25 2.25 0 0 0-2.25-2.25H6.75a2.25 2.25 0 0 0-2.25 2.25v6.75a2.25 2.25 0 0 0 2.25 2.25Z" />
                                    </svg>

                                    Password
                                </label>
                            </div>
                        </article>
                        <article class="flex items-center justify-center">
                            <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
                            <asp:Button runat="server" Text="Sign Up" ID="btnLogin" CssClass="btn-register w-30 h-1/2 bg-[#8ac545] text-white py-2 rounded-md hover:bg-[#669233] transition duration-200" OnClick="btnLogin_Click"/>
                        </article>
                        <article>
                            <a
                                href="#"
                                class="forgot-password text-sm text-blue-500 hover:underline text-center block mt-2">Forgot your password?
                            </a>
                        </article>
                    </div>

                    <!-- Social Login Section -->
                    <article>
                        <hr class="my-4 border-gray-300" />
                        <p class="text-center text-gray-600">or sign up with</p>

                        <div class="flex justify-center gap-3 mt-4 items-stretch">
                            <!-- Google -->
                            <button
                                class="btn btn-outline-light border border-gray-300 rounded-lg p-2 shadow-sm hover:bg-gray-100 transition duration-200 hover:drop-shadow-lg active:drop-shadow-none"
                                style="width: 3rem; height: 3rem"
                                aria-label="Sign in with Google"
                                onclick="return false;">
                                <img
                                    src="https://cdn-icons-png.flaticon.com/512/300/300221.png"
                                    alt="Google Logo"
                                    class="w-full h-full object-contain" />
                            </button>

                            <!-- Facebook -->
                            <button
                                class="btn btn-outline-light border border-gray-300 rounded-lg p-2 shadow-sm hover:bg-gray-100 transition duration-200 hover:drop-shadow-lg active:drop-shadow-none"
                                style="width: 3rem; height: 3rem"
                                aria-label="Sign in with Facebook"
                                onclick="return false;">
                                <img
                                    src="https://static.vecteezy.com/system/resources/thumbnails/018/930/698/small_2x/facebook-logo-facebook-icon-transparent-free-png.png"
                                    alt="Facebook Logo"
                                    class="w-full h-full object-contain" />
                            </button>

                            <!-- Twitter -->
                            <button
                                class="btn btn-outline-light border border-gray-300 rounded-lg p-2 shadow-sm hover:bg-gray-100 transition duration-200 hover:drop-shadow-lg active:drop-shadow-none"
                                style="width: 3rem; height: 3rem"
                                aria-label="Sign in with Twitter"
                                onclick="return false;">
                                <img
                                    src="https://uxwing.com/wp-content/themes/uxwing/download/brands-and-social-media/x-social-media-logo-icon.png"
                                    alt="Twitter Logo"
                                    class="w-full h-full object-contain" />
                            </button>
                        </div>
                    </article>
                </div>
                <div class="form-register w-100 h-full bg-white flex items-center justify-center p-6 hidden flex-col">
                    <h3 class="text-2xl font-semibold text-center">Sign Up</h3>
                    <section
                        class="w-full space-y-4 flex justify-center items-center flex-col">
                        <!-- DNI Field -->
                        <div class="relative z-0 w-full group flex justify-center">
                            <input
                                type="tel"
                                id="dni"
                                name="dni"
                                class="block py-2 px-0 w-full text-sm text-gray-900 bg-transparent border-0 border-b-2 border-gray-300 focus:outline-none focus:ring-0 focus:border-blue-600 peer"
                                placeholder=" " />
                            <label
                                for="dni"
                                class="left-0 absolute text-sm text-gray-500 duration-300 transform -translate-y-6 scale-75 top-3 -z-10 origin-[0] peer-placeholder-shown:scale-100 peer-placeholder-shown:translate-y-0 peer-focus:scale-75 peer-focus:-translate-y-6">
                                DNI</label>
                        </div>

                        <!-- Email Field -->
                        <div class="relative z-0 w-full group flex justify-center">
                            <input
                                type="email"
                                id="email"
                                name="email"
                                class="block py-2 px-0 w-full text-sm text-gray-900 bg-transparent border-0 border-b-2 border-gray-300 focus:outline-none focus:ring-0 focus:border-blue-600 peer"
                                placeholder=" " />
                            <label
                                for="email"
                                class="left-0 absolute text-sm text-gray-500 duration-300 transform -translate-y-6 scale-75 top-3 -z-10 origin-[0] peer-placeholder-shown:scale-100 peer-placeholder-shown:translate-y-0 peer-focus:scale-75 peer-focus:-translate-y-6">
                                Email</label>
                        </div>
                        <!-- Username Field -->
                        <div class="relative z-0 w-full group flex justify-center">
                            <input
                                type="text"
                                id="username"
                                name="username"
                                class="block py-2 px-0 w-full text-sm text-gray-900 bg-transparent border-0 border-b-2 border-gray-300 focus:outline-none focus:ring-0 focus:border-blue-600 peer"
                                placeholder=" " />
                            <label
                                for="username"
                                class="left-0 absolute text-sm text-gray-500 duration-300 transform -translate-y-6 scale-75 top-3 -z-10 origin-[0] peer-placeholder-shown:scale-100 peer-placeholder-shown:translate-y-0 peer-focus:scale-75 peer-focus:-translate-y-6">
                                Username</label>
                        </div>

                        <!-- Password Field -->
                        <div class="relative z-0 w-full group flex justify-center">
                            <input
                                type="password"
                                id="password"
                                name="password"
                                class="block py-2 px-0 w-full text-sm text-gray-900 bg-transparent border-0 border-b-2 border-gray-300 focus:outline-none focus:ring-0 focus:border-blue-600 peer"
                                placeholder=" "
                                onfocus="showRequirements()"
                                onblur="hideRequirements()"
                                oninput="validPassoword(this.value)" />
                            <label
                                for="password"
                                class="left-0 absolute text-sm text-gray-500 duration-300 transform -translate-y-6 scale-75 top-3 -z-10 origin-[0] peer-placeholder-shown:scale-100 peer-placeholder-shown:translate-y-0 peer-focus:scale-75 peer-focus:-translate-y-6">
                                Password</label>
                            <div
                                id="password-requirements"
                                class="absolute top-0 left-full ml-4 p-2 h-auto rounded bg-gray-500 opacity-0 transition-opacity duration-300">
                                <p class="text-sm text-white">Password Requirements</p>
                                <ul class="req-pass text-xs text-gray-200 list-disc ml-4">
                                    <li>At least 8 characters</li>
                                    <li>One uppercase letter</li>
                                    <li>One special character</li>
                                </ul>
                            </div>
                        </div>

                        <!-- Confirm Password Field -->
                        <div class="relative z-0 w-full group flex justify-center">
                            <input
                                type="password"
                                id="confirm-password"
                                name="confirm-password"
                                class="block py-2 px-0 w-full text-sm text-gray-900 bg-transparent border-0 border-b-2 border-gray-300 focus:outline-none focus:ring-0 focus:border-blue-600 peer"
                                oninput="verificatePasswords(this)"
                                placeholder=" " />
                            <label
                                for="confirm-password"
                                class="left-0 absolute text-sm text-gray-500 duration-300 transform -translate-y-6 scale-75 top-3 -z-10 origin-[0] peer-placeholder-shown:scale-100 peer-placeholder-shown:translate-y-0 peer-focus:scale-75 peer-focus:-translate-y-6">
                                Confirm Password</label>
                        </div>

                        <!-- Nombre Field -->
                        <div class="relative z-0 w-full group flex justify-center">
                            <input
                                type="text"
                                id="nombre"
                                name="nombre"
                                class="block py-2 px-0 w-full text-sm text-gray-900 bg-transparent border-0 border-b-2 border-gray-300 focus:outline-none focus:ring-0 focus:border-blue-600 peer"
                                placeholder=" " />
                            <label
                                for="nombre"
                                class="left-0 absolute text-sm text-gray-500 duration-300 transform -translate-y-6 scale-75 top-3 -z-10 origin-[0] peer-placeholder-shown:scale-100 peer-placeholder-shown:translate-y-0 peer-focus:scale-75 peer-focus:-translate-y-6">
                                Name</label>
                        </div>

                        <!-- Apellido Field -->
                        <div class="relative z-0 w-full group flex justify-center">
                            <input
                                type="text"
                                id="apellido"
                                name="apellido"
                                class="block py-2 px-0 w-full text-sm text-gray-900 bg-transparent border-0 border-b-2 border-gray-300 focus:outline-none focus:ring-0 focus:border-blue-600 peer"
                                placeholder=" " />
                            <label
                                for="apellido"
                                class="left-0 absolute text-sm text-gray-500 duration-300 transform -translate-y-6 scale-75 top-3 -z-10 origin-[0] peer-placeholder-shown:scale-100 peer-placeholder-shown:translate-y-0 peer-focus:scale-75 peer-focus:-translate-y-6">
                                Lastname</label>
                        </div>

                        <!-- Telefono Field -->
                        <div class="relative z-0 w-full group flex justify-center">
                            <input
                                type="tel"
                                id="telefono"
                                name="telefono"
                                class="block py-2 px-0 w-full text-sm text-gray-900 bg-transparent border-0 border-b-2 border-gray-300 focus:outline-none focus:ring-0 focus:border-blue-600 peer"
                                placeholder=" " />
                            <label
                                for="telefono"
                                class="left-0 absolute text-sm text-gray-500 duration-300 transform -translate-y-6 scale-75 top-3 -z-10 origin-[0] peer-placeholder-shown:scale-100 peer-placeholder-shown:translate-y-0 peer-focus:scale-75 peer-focus:-translate-y-6">
                                Phone</label>
                        </div>

                        <!-- Provincia Select -->
                        <div
                            class="relative z-0 w-full group flex justify-center gap-1 flex-col">
                            <label for="slt-provincia" class="block text-sm text-gray-500">
                                Provincia</label>
                            <select
                                id="slt-provincia"
                                name="provincia"
                                class="block w-full py-2 px-3 text-sm text-gray-700 bg-white border border-gray-300 rounded-md focus:ring-blue-500 focus:border-blue-500 focus:outline-none">
                                <!-- Opciones de provincia -->
                            </select>
                        </div>

                        <!-- Localidad Select -->
                        <div
                            class="relative z-0 w-full group flex justify-center gap-1 flex-col">
                            <label for="slt-minu" class="block text-sm text-gray-500">
                                Localidad</label>
                            <select
                                id="slt-minu"
                                name="localidad"
                                class="block w-full py-2 px-3 text-sm text-gray-700 bg-white border border-gray-300 rounded-md focus:ring-blue-500 focus:border-blue-500 focus:outline-none">
                                <!-- Opciones de localidad -->
                            </select>
                        </div>
                        <div class="flex items-center">
                            <input
                                type="checkbox"
                                id="terms"
                                name="terms"
                                class="form-checkbox h-4 w-4 text-blue-600 transition duration-150 ease-in-out" />
                            <label for="terms" class="ml-2 text-sm text-gray-700">
                                I accept the
                <a href="#" class="text-blue-500 hover:underline">terms and conditions</a>.
                            </label>
                        </div>
                        <!-- Submit Button -->
                        <div class="w-full flex justify-center">
                            <button
                                type="submit"
                                class="w-full md:w-auto text-white bg-[#8ac545] hover:bg-green-600 focus:ring-4 focus:outline-none focus:ring-green-300 font-medium rounded-lg text-sm px-5 py-2.5 text-center">
                                Sign Up
                            </button>
                        </div>
                    </section>
                </div>
            </div>
        </form>
    </main>
    <script src="https://cdn.tailwindcss.com"></script>
    <script>
        let passCurrent;

        document.querySelector(".eye").style.visibility = "hidden";

        let isActive = false;
        const formLogin = document.querySelector(".form-login");
        const formRegister = document.querySelector(".form-register");

        function handleRegisterClick(event) {
            event.preventDefault();
            const logo = document.getElementById("container-logo");
            const content = document.querySelector(".container-content");

            logo.classList.toggle("translate-x-full");
            content.classList.toggle("-translate-x-full");

            if (isActive) {

                document.title = "Sign Up | FutbolMatch";
                clearInputsForm(formLogin);
                changeStatusForm(formLogin, formRegister);
                $(".msg-init").text("Don't have an account? No worries!");
                $(".msg-init-meta")
                    .html(`Create your account now to start booking the best football fields in town.
              <a href="#" onclick="handleRegisterClick(event)" class="text-blue-500 hover:underline"><strong>Sign Up</strong></a>`);
            } else {

                document.title = "Sign In | FutbolMatch";
                clearInputsForm(formRegister);
                changeStatusForm(formRegister, formLogin);
                $(".msg-init").text("Already Have an Account?");
                $(".msg-init-meta").html(`
                <a href="#"
                  onclick="handleRegisterClick(event)"
                  class="text-blue-500 hover:underline"><strong>Sign In</strong></a> to continue booking your favorite football fields and secure the best spots for your next match.`);
            }

            // Toggle the state
            isActive = !isActive;
        }

        function changeStatusForm(c1, c2) {
            c1.classList.remove("hidden");
            c1.classList.add("block");
            c2.classList.remove("block");
            c2.classList.add("hidden");
        }

        function clearInputsForm(c) {
            var inputs = c.querySelectorAll("input");
            Array.from(inputs).forEach((input) => {
                input.value = "";
            });
        }

        function showPass() {
            document.querySelector(".eye-close").style.visibility = "visible";
            document.querySelector(".eye").style.visibility = "hidden";
            document.getElementById("txtPassword").type = "password";
        }

        function hiddenPass() {
            document.querySelector(".eye").style.visibility = "visible";
            document.querySelector(".eye-close").style.visibility = "hidden";
            document.getElementById("txtPassword").type = "text";
        }
        function showRequirements() {
            document.getElementById("password-requirements").style.opacity = "1";
        }

        function hideRequirements() {
            document.getElementById("password-requirements").style.opacity = "0";
        }

        function validPassoword(password) {
            // Al menos 8 caracteres
            const minLength = /.{8,}/;
            // Al menos una letra mayúscula
            const upperCase = /[A-Z]/;
            // Al menos un carácter especial
            const specialChar = /[!@#$%^&*(),.?":{}|<>]/;

            var li = document.querySelector(".req-pass").getElementsByTagName("li");

            const t1 = minLength.test(password)
                ? (li[0].style.color = "greenyellow")
                : (li[0].style.color = "red");
            const t2 = upperCase.test(password)
                ? (li[1].style.color = "greenyellow")
                : (li[1].style.color = "red");
            const t3 = specialChar.test(password)
                ? (li[2].style.color = "greenyellow")
                : (li[2].style.color = "red");

            if (t1 && t2 && t3) {
                passCurrent = password;
            }
        }

        function verificatePasswords(pass) {
            const confirmPassword = pass.value;

            if (confirmPassword === "") {
                // Si confirmPassword está vacío, solo quitamos las clases de error o éxito
                pass.classList.remove(
                    "focus:border-red-600",
                    "focus:border-lime-500"
                );
            } else if (confirmPassword === passCurrent) {
                // Si las contraseñas coinciden
                pass.classList.remove("focus:border-red-600");
                pass.classList.add("focus:border-lime-500");
            } else {
                // Si las no contraseñas coinciden y confirmPassword no está vacío
                pass.classList.remove("focus:border-lime-500");
                pass.classList.add("focus:border-red-600");
            }
        }
    </script>
    <script src="../Scripts/scripts-forms/data-provinces.js"></script>
    <script
        src="https://code.jquery.com/jquery-3.7.1.js"
        integrity="sha256-eKhayi8LEQwp4NKxN+CfCh+3qOVUtJn3QNZ0TciWLP4="
        crossorigin="anonymous"></script>
</body>
</html>
