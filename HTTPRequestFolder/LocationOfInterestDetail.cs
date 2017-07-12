using System;
namespace NavigationFromUnityToXamarin.HTTPRequestFolder
{
    public class LocationOfInterestDetail
	{
		public LocationOfInterestDetail() { }

		public long Id { get; set; }
		public string BLE { get; set; }
		public string DetailName { get; set; }
		public string Name { get; set; }
		public long VenueId { get; set; }
		public int Floor { get; set; }
		public long LocationOfInterestId { get; set; }
		public bool IsDestination { get; set; }
		public int LocationType { get; set; }
		public int PurposeType { get; set; }
		public string LocationString { get; set; } // mapping to BLE tags
		public string LandmarkLocationString { get; set; } //mapping to landmarks 

		public LocationOfInterestDetail(LocationOfInterestDetail loiDetail)
		{
			Id = loiDetail.Id;
			BLE = loiDetail.BLE;
			DetailName = loiDetail.DetailName;
			Name = loiDetail.Name;
			VenueId = loiDetail.VenueId;
			Floor = loiDetail.Floor;
			LocationOfInterestId = loiDetail.LocationOfInterestId;
			IsDestination = loiDetail.IsDestination;
			LocationType = loiDetail.LocationType;
			PurposeType = loiDetail.PurposeType;
			LocationString = loiDetail.LocationString;
			LandmarkLocationString = loiDetail.LandmarkLocationString;
		}
    }
}
