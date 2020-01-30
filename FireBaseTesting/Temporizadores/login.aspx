<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="FireBaseTesting.Temporizadores.login" ValidateRequest="true" %>

<!DOCTYPE html>
<html lang="en" >
<head>
    <meta charset="UTF-8">
    
     <meta name="viewport" content="width=device-width, initial-scale=1"><link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/meyer-reset/2.0/reset.min.css">
    <link rel="stylesheet" href="./styleLogin.css"/>

    <link href="css/sweetalert.css" rel="stylesheet" />
    <script src="js/sweetalert-dev.js"></script>
    <script>
        function Loginvalidate() {

            if (document.getElementById('username').value == "Nivel1") {               
                
                window.location.href = 'Linestart';
                document.getElementById('spanMessage').innerHTML = "";
            }

            else if (document.getElementById('username').value == "Nivel2") {
                                
                window.location.href = 'EndLine';
                document.getElementById('spanMessage').innerHTML = "";
            }
            else {
                swal('Usuario o contraseña no válidos', '', 'error');
            }
        }
    </script>
</head>
<body>  
    <form onsubmit="return false">
        <div class="form-item">
        <img src="Images/Fruselva.png" style="width:200px" />
            <br />
        <label>Username</label>
        <div class="input-wrapper">
            <input type="text" id="username" autocomplete="off" autocorrect="off" autocapitalize="off" spellcheck="false" data-lpignore="true"/>
        </div>
        </div>
        <div class="form-item">
        <label>Password</label>
        <div class="input-wrapper">
            <input type="password" id="password" autocomplete="off" autocorrect="off" autocapitalize="off" spellcheck="false" data-lpignore="true"/>
            <button type="button" id="eyeball">
            <div class="eye"></div>
            </button>
            <div id="beam"></div>
        </div>
        </div>
        <button id="submit" onclick="Loginvalidate();">Sign in</button>
    </form>
      
    <script  src="./scriptLogin.js"></script>
</body>

</html>

