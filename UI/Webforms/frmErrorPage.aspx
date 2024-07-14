<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="frmErrorPage.aspx.cs" Inherits="UI.Webforms.frmErrorPage" %>

<!DOCTYPE html>
<html>
<head runat="server">
    <link href="/Styles/style.css" rel="stylesheet" />
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Error</title>
</head>
<body>
    <form class="form-error" runat="server">
        <div class="container-error">
            <h1>Sitio en mantenimiento</h1>
            <p>Nos disculpamos por las molestias ocasionadas</p>
        </div>
        <div class="container-img">
            <img src="../Images/ball-sad.png" class="error-img" alt="Image Error"/>
        </div>
    </form>
</body>
</html>
