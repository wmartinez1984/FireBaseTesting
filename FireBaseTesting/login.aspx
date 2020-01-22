<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="FireBaseTesting.login" %>

<!DOCTYPE html>
<html>
<head>
  <meta name="viewport" content="width=device-width, initial-scale=1">
 <style>
        body {font-family: Arial, Helvetica, sans-serif;}
        form {border: 3px solid #f1f1f1;}

        input[type=text], input[type=password] {
          width: 100%;
          padding: 12px 20px;
          margin: 8px 0;
          display: inline-block;
          border: 1px solid #ccc;
          box-sizing: border-box;
        }

        button {
          background-color: #4CAF50;
          color: white;
          padding: 14px 20px;
          margin: 8px 0;
          border: none;
          cursor: pointer;
          width: 100%;
        }

        button:hover {
          opacity: 0.8;
        }

        .cancelbtn {
          width: auto;
          padding: 10px 18px;
          background-color: #f44336;
        }

        .imgcontainer {
          text-align: center;
          margin: 24px 0 12px 0;
        }

        img.avatar {
          width: 20%;
          border-radius: 50%;
        }

        .container {
          padding: 16px;
        }

        span.psw {
          float: right;
          padding-top: 16px;
        }

        /* Change styles for span and cancel button on extra small screens */
        @media screen and (max-width: 300px) {
          span.psw {
             display: block;
             float: none;
          }
          .cancelbtn {
             width: 100%;
          }
        }
        </style>
     <!--Mensajes...-->
    <script src="Scripts/sweetalert-dev.js"></script>
    <link href="css/sweetalert.css" rel="stylesheet" />
 </head>

<body>

<form runat="server">
    <div style="text-align:center;width:80%;margin:auto;background-color:#f4f2f2">
            <div class="imgcontainer">
                <img src="images/img_avatar2.png" alt="Avatar" class="avatar" >
            </div>
            <div class="container" style="text-align:center;width:40%;margin:auto;">
                <label for="uname"><b>Usuario:</b></label>
                <input type="text" placeholder="Capture usuario" runat="server" id="txtUsername" name="uname" required  style="width:100%;">
                <label for="psw"><b>Contraseña:</b></label>
                <input type="password" placeholder="Capture Password" name="psw" required runat="server" id="txtPassword">  
                <asp:Button ID="submit" runat="server" Text="Iniciar" CssClass="button" OnClick="submit_Click" style="background-color:#4CAF50;cursor:pointer;" Width="50%" Height="50px"/>
 
            </div>
        <br />
    </div> 
</form>
</body>
</html>