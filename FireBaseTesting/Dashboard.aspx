<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Dashboard.aspx.cs" Inherits="FireBaseTesting.Dashboard" %>

<!DOCTYPE html>
<html> 
<head> 
  <meta http-equiv="content-type" content="text/html; charset=UTF-8" /> 
  <title>Dashboard</title> 
  <script src="http://maps.google.com/maps/api/js?sensor=false" 
          type="text/javascript"></script>
</head> 
<body>
  <div id="map" style="width: 100%; height: 600px;"></div>

  <script type="text/javascript">
    var locations = [
      ['Prueba 1', 6.247197832423961, -75.6102218851447, 4],
      ['Prueba 2', 6.253759175906705, -75.56317795068027, 5],
      ['Prueba 3', 6.250503344039338, -75.60455840080976, 3],
      ['Prueba 4', 6.204684256602132, -75.5724436417222, 2],
      ['Prueba 5', 6.159561867589179, -75.62825705856085, 1]
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
        position: new google.maps.LatLng(locations[i][1], locations[i][2]),
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
