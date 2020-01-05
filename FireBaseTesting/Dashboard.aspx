<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Dashboard.aspx.cs" Inherits="FireBaseTesting.Dashboard" %>

<!DOCTYPE html>
<html> 
<head> 
  <meta http-equiv="content-type" content="text/html; charset=UTF-8" /> 
  <title>Dashboard</title> 
  <script src="https://maps.google.com/maps/api/js?sensor=false" 
          type="text/javascript"></script>
</head> 
<body>
 <div style="background-color:#4b506f;margin-top:0;height:40px;">
     <p style="font-size:30px;color:#ffffff;width:100%;text-align:left;">      
      <strong>
          Operaciones, listado general
      </strong>
  </p>
 </div>
  
  <div id="map" style="width: 100%; height: 600px;">

  </div>
  <div id="divjson" runat="server" style="width: 100%; height: 600px;">

  </div>
  <script type="text/javascript">
    var locations = [
      ['Prueba 1 <br/> <img  style="width:200px;height:200px;"  src="https://firebasestorage.googleapis.com/v0/b/apptecnicos-9a471.appspot.com/o/images%2F4efa5c1b-68d8-45d1-b60b-15eb5fc3f4b3?alt=media&token=44172996-1faa-4b60-b482-0e35c1cda259"/>', 6.247197832423961, -75.6102218851447, 4],
      ['Prueba 2 <br/> <img  style="width:200px;height:200px;"  src="https://firebasestorage.googleapis.com/v0/b/apptecnicos-9a471.appspot.com/o/images%2F4efa5c1b-68d8-45d1-b60b-15eb5fc3f4b3?alt=media&token=44172996-1faa-4b60-b482-0e35c1cda259"/>', 6.253759175906705, -75.56317795068027, 5],
      ['Prueba 3 <br/> <img  style="width:200px;height:200px;"  src="https://firebasestorage.googleapis.com/v0/b/apptecnicos-9a471.appspot.com/o/images%2F4efa5c1b-68d8-45d1-b60b-15eb5fc3f4b3?alt=media&token=44172996-1faa-4b60-b482-0e35c1cda259"/>', 6.250503344039338, -75.60455840080976, 3],
      ['Prueba 4 <br/> <img  style="width:200px;height:200px;"  src="https://firebasestorage.googleapis.com/v0/b/apptecnicos-9a471.appspot.com/o/images%2F4efa5c1b-68d8-45d1-b60b-15eb5fc3f4b3?alt=media&token=44172996-1faa-4b60-b482-0e35c1cda259"/>', 6.204684256602132, -75.5724436417222, 2],
      ['Prueba 5 <br/> <img  style="width:200px;height:200px;"  src="https://firebasestorage.googleapis.com/v0/b/apptecnicos-9a471.appspot.com/o/images%2F4efa5c1b-68d8-45d1-b60b-15eb5fc3f4b3?alt=media&token=44172996-1faa-4b60-b482-0e35c1cda259"/>', 6.159561867589179, -75.62825705856085, 1]
    ];

    var map = new google.maps.Map(document.getElementById('map'), {
      zoom: 7,
      center: new google.maps.LatLng(6.247197832423961,-75.6102218851447),
      mapTypeId: google.maps.MapTypeId.ROADMAP
    });

    var infowindow = new google.maps.InfoWindow();

    var marker, i;

    for (i = 0; i < locations.length; i++) {  
      marker = new google.maps.Marker({
          position: new google.maps.LatLng(locations[i][1], locations[i][2],),
          icon:'http://maps.google.com/mapfiles/ms/icons/green.png',
          map: map
      });

      google.maps.event.addListener(marker, 'click', (function(marker, i) {
        return function() {
          infowindow.setContent(locations[i][0]);
          infowindow.open(map, marker);
        }
      })(marker, i));
    }
  </script>
</body>
</html>
