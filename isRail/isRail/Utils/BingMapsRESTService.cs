using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BingMapsRESTToolkit;
using Microsoft.Maps.MapControl.WPF;

namespace isRail.Utils
{
    public static class BingMapsRESTService
    {
        public static void SendRequest(Map myMap, List<SimpleWaypoint> waypoints)
        {
            RouteRequest routeRequest = new RouteRequest()
            {
                Waypoints = waypoints,
                RouteOptions = new RouteOptions()
                {
                    TravelMode = TravelModeType.Driving,
                    RouteAttributes = new List<RouteAttributeType>()
                    {
                        RouteAttributeType.RoutePath,
                        RouteAttributeType.ExcludeItinerary
                    }
                },
                BingMapsKey = "jcN70CoOBDnsrAlWKqWM~KGgDd7HLbAy2iRafyB9ytw~ApXB3OvpKS1Loo6XUCGodM0rf6U6ph0Jtc-kt3pk3FWMZ8zZVBhOxxMSViza80RG"
            };

            ProcessRequest(routeRequest, myMap);

        }

        private static async void ProcessRequest(BaseRestRequest request, Map myMap)
        {
            try
            {
                //Execute the request.
                Response response = await request.Execute();

                if (response != null &&
                    response.ResourceSets != null &&
                    response.ResourceSets.Length > 0 &&
                    response.ResourceSets[0].Resources != null &&
                    response.ResourceSets[0].Resources.Length > 0)
                {

                    var route = response.ResourceSets[0].Resources[0] as Route;
                    var coords = route.RoutePath.Line.Coordinates;
                    var locs = new LocationCollection();

                    for (int i = 0; i < coords.Length; i++)
                    {
                        locs.Add(new Microsoft.Maps.MapControl.WPF.Location(coords[i][0], coords[i][1]));
                    }

                    var routeLine = new MapPolyline()
                    {
                        Locations = locs,
                        Stroke = new System.Windows.Media.SolidColorBrush(System.Windows.Media.Colors.Blue),
                        StrokeThickness = 3
                    };

                    myMap.Children.Add(routeLine);
                }
            }
            catch (Exception ex)
            {
                if (ex.Message != "Not enough Waypoints specified.")
                    //TODO: add message box popup
                    _ = new MessageBoxCustom(ex.Message, MessageType.Error, MessageButtons.Ok).ShowDialog();
            }
        }
    }
}
