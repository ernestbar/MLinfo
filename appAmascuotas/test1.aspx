﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="test1.aspx.cs" Inherits="appAmascuotas.test1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <meta charset="utf-8" />
  <meta name="viewport" content="width=device-width, initial-scale=1.0" />
  <link rel="stylesheet" href="//maxcdn.bootstrapcdn.com/bootstrap/4.0.0/css/bootstrap.min.css" />
  <script src="//cdnjs.cloudflare.com/ajax/libs/jquery/3.3.1/jquery.min.js"></script>
  <script src="//maxcdn.bootstrapcdn.com/bootstrap/4.0.0/js/bootstrap.min.js"></script>
    <script async defer src="https://maps.googleapis.com/maps/api/js?key=AIzaSyB6XhmQ0TrlvdgfDu59q1lTyBp5NskGo7I&callback=initMap"></script>
    <script type="text/javascript">
        var markers = [
            {
                "title": 'Aksa Beach',
                "lat": '19.1759668',
                "lng": '72.79504659999998',
                "description": 'Aksa Beach is a popular beach and a vacation spot in Aksa village at Malad, Mumbai.'
            },
            {
                "title": 'Juhu Beach',
                "lat": '19.0883595',
                "lng": '72.82652380000002',
                "description": 'Juhu Beach is one of favourite tourist attractions situated in Mumbai.'
            },
            {
                "title": 'Girgaum Beach',
                "lat": '18.9542149',
                "lng": '72.81203529999993',
                "description": 'Girgaum Beach commonly known as just Chaupati is one of the most famous public beaches in Mumbai.'
            },
            {
                "title": 'Jijamata Udyan',
                "lat": '18.979006',
                "lng": '72.83388300000001',
                "description": 'Jijamata Udyan is situated near Byculla station is famous as Mumbai (Bombay) Zoo.'
            },
            {
                "title": 'Sanjay Gandhi National Park',
                "lat": '19.2147067',
                "lng": '72.91062020000004',
                "description": 'Sanjay Gandhi National Park is a large protected area in the northern part of Mumbai city.'
            }
        ];
        window.onload = function () {
            LoadMap();
        }
        var map, mapOptions;
        function LoadMap() {
            mapOptions = {
                center: new google.maps.LatLng(19.0883595, 72.82652380000002),
                zoom: 10,
                mapTypeId: google.maps.MapTypeId.ROADMAP
            };
            map = new google.maps.Map(document.getElementById("dvMap"), mapOptions);

            for (var i = 0; i < markers.length; i++) {
                var data = markers[i];
                var myLatlng = new google.maps.LatLng(data.lat, data.lng);
                var marker = new google.maps.Marker({
                    position: myLatlng,
                    map: map,
                    title: data.title
                });
            }
        };
        function Export() {
            //URL of Google Static Maps.
            var staticMapUrl = "https://maps.googleapis.com/maps/api/staticmap";

            //Set the Google Map Center.
            staticMapUrl += "?center=" + mapOptions.center.lat() + "," + mapOptions.center.lng();

            //Set the Google Map Size.
            staticMapUrl += "&size=220x350";

            //Set the Google Map Zoom.
            staticMapUrl += "&zoom=" + mapOptions.zoom;

            //Set the Google Map Type.
            staticMapUrl += "&maptype=" + mapOptions.mapTypeId;

            //Loop and add Markers.
            for (var i = 0; i < markers.length; i++) {
                staticMapUrl += "&markers=color:red|" + markers[i].lat + "," + markers[i].lng;
            }

            //Save the Image Url of Google Map.
            document.getElementById("hfImageUrl").value = staticMapUrl + "&key=AIzaSyB6XhmQ0TrlvdgfDu59q1lTyBp5NskGo7I";
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
      <div>
    
            <table border="0" cellpadding="0" cellspacing="0">
                <tr>
                    <td>
                        <div id="dvMap" style="width: 220px; height: 350px">
                        </div>
                    </td>
                    <td>
                        &nbsp; &nbsp;
                    </td>
                    <td>
                        <asp:HiddenField ID="hfImageUrl" runat="server" />
                    </td>
                </tr>
            </table>
            <br />
                <asp:Button Text="Save Image" OnClick="Save" OnClientClick="Export()" runat="server" />
            <br />
            <br />
            <asp:Image ID="imgServer" runat="server" />
        </div>
        </form>
</body>
    
</html>
