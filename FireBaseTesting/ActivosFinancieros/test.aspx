<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="test.aspx.cs" Inherits="FireBaseTesting.ActivosFinancieros.test" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <script>
        function test() {
            var list = ["1", "3", "3"];

            for (i = 0; i < list.length; i++) {
                list[i][0] = '0';
                list[i][1] = '1';
                list[i][2] = '2';
            }

            alert(list);
        }
    </script>
</head>
<body onload="test();">
    <form id="form1" runat="server">
        <div>
        </div>
    </form>
</body>
</html>
