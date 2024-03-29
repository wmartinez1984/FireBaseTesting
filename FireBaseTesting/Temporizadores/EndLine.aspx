﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EndLine.aspx.cs" Inherits="FireBaseTesting.Temporizadores.EndLine" %>


<!DOCTYPE html>

<html>

<head>
    <title>Final de Línea</title>

    <style>
        * {
            box-sizing: border-box;
        }

        .wrapper {
            perspective: 800px;
        }

        .btn {
            position: relative;
            height: 200px;
            width: 100%;
            transform-style: preserve-3d;
            transition: transform 300ms ease-in-out;
            transform: translateZ(-75px);
        }

        .btn:hover {
            transform: rotateX(-90deg) translateY(75px);
        }

        .side {
            position: absolute;
            backface-visibility: hidden;
            width: 100%;
            height: 100%;
            display: flex;
            justify-content: center;
            align-items: center;
            font-size: 4em;
            font-weight: bold;
        }

        .default-side {
            background-color: white;
            border: 10px solid #069;
            color: #069;
            transform: translateZ(75px);
        }

        .hover-side {
            color: white;
            background-color: #069;
            transform: rotateX(90deg) translateZ(75px);
        }

        /* Background Styles Only */

        @import url("https://fonts.googleapis.com/css?family=Raleway");

        * {
            font-family: Raleway;
        }

        /*html {
            width: 100%;
            height: 100%;
            display: flex;
            justify-content: center;
            align-items: center;
            background-color: #dfdfdf;
        }*/

        .side-links {
            position: absolute;
            top: 15px;
            right: 15px;
        }

        .side-link {
            display: flex;
            align-items: center;
            justify-content: center;
            text-decoration: none;
            margin-bottom: 10px;
            color: white;
            width: 180px;
            padding: 10px 0;
            border-radius: 10px;
        }

        .side-link-youtube {
            background-color: red;
        }

        .side-link-twitter {
            background-color: #1da1f2;
        }

        .side-link-github {
            background-color: #6e5494;
        }

        .side-link-text {
            margin-left: 10px;
            font-size: 18px;
        }

        .side-link-icon {
            color: white;
            font-size: 30px;
        }

    </style>
</head>

<body>
    
    <div class="wrapper">
        <table style="width:100%;">
            <tr>

                <td style="width:65%;height:250px;text-align:center;">
                    <div class="btn">
                        <div class="side default-side" style="font-size:120px;width:100%;color:black; ">Estado:Envasando</div>
                        <div class="side hover-side" style="font-size:120px;width:100%;color:black; ">00:00:000</div>

                    </div>
                    <br />
                </td>

                <td rowspan="3" style="text-align: right;">

                    <a href="login.aspx">
                        aaaa
                    </a>
                  
                    <h3 style="color:#207529; text-align:left; font-size:12px;" id="messageUpdateData"></h3>


                </td>

            </tr>
            <tr>
                <td style="width: 65%;height: 200px; text-align: center;">
                    <div class="btn">
                        <div class="side default-side" style="font-size:120px;width:100%;color:black; ">Estado:Parada</div>
                        <div class="side hover-side" style="font-size:120px;width:100%;color:black; ">
                            1:0:22:00
                            <p>Parada</p>
                        </div>

                    </div>
                    <br />
                </td>
            </tr>
            <tr>
                <td style="width: 65%;height: 200px;text-align: center;">
                    <div class="btn">
                        <div class="side default-side" style="font-size:120px;width:100%;color:black; ">Estado:Parada</div>
                        <div class="side hover-side" style="font-size:120px;width:100%;color:black; ">1:0:22:00</div>
                    </div>
                </td>
            </tr>

        </table>

    </div>

   
</body>

</html>
