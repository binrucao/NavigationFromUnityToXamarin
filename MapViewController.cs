using Foundation;
using System;
using UIKit;
using Google.Maps;
using CoreLocation;
using System.Collections.Generic;
using NavigationFromUnityToXamarin.HTTPRequestFolder;

namespace NavigationFromUnityToXamarin
{
    public partial class MapViewController : UIViewController
    {
        public string destination { get; set; }
        public MapView mapView;

		public string currentFloor;
		public int mapfloor;
		public Marker startMarker;
		public CLLocationCoordinate2D location_Coordinate;
		public UrlTileLayer _originalLayer;

		//map layer url
		string tileURL_1 = "http://perceptone.azurewebsites.net/Blueprints/MBTA/NorthStation/Subway/U1_v3/";// level 1. main floor
		string tileURL_2 = "http://perceptone.azurewebsites.net/Blueprints/MBTA/NorthStation/Subway/Floor3/";// level 2
		string tileURL_0 = "http://perceptone.azurewebsites.net/Blueprints/MBTA/NorthStation/Subway/F1/";// street level

		// surrounding lamdmarks url
		// standard form: api/venue/{venueId}/floor/{floor}/location/{location}/LocationOfInterest/surrounding
		string surroundingLandmarksURL_part1 = "http://perceptweb.azurewebsites.net/api/venue/4/floor/";
        string surroundingLandmarksURL_part3 = "/location/";
        string surroundingLandmarksURL_part5 = "/LocationOfInterest/surrounding/";
        string completeSurroundingURL; // part1+floor+part3+location+part5

        List<LocationOfInterest> nearbyLandmarks = new List<LocationOfInterest>(); // parsing TOP 5 nearest points

		public MapViewController (IntPtr handle) : base (handle)
        {
        }
    }
}