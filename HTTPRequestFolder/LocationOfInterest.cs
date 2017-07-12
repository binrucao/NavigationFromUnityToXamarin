using System;
namespace NavigationFromUnityToXamarin.HTTPRequestFolder
{
    public class LocationOfInterest
    {
		public LocationOfInterest() { }

		public LocationOfInterest(LocationOfInterest loi)
		{
			Id = loi.Id;
			Name = loi.Name;
			DisplayName = loi.DisplayName;
			DetailName = loi.DetailName;
			Floor = loi.Floor;
			LocationType = loi.LocationType;
			LoiType = loi.LoiType;
			PurposeType = loi.PurposeType;
			LocationString = loi.LocationString;
			Texture = loi.Texture;
			VenueId = loi.VenueId;
		}

		public long Id { get; set; }
		public string Name { get; set; }
		public string DetailName { get; set; }
		public string DisplayName { get; set; }
		public int Floor { get; set; }
		public LocationType LocationType { get; set; }
		public LocationOfInterestType LoiType { get; set; }
		public PurposeType PurposeType { get; set; } = PurposeType.Both;
		public string LocationString { get; set; }
		public string Texture { get; set; }
		public long VenueId { get; set; }

	}
}
