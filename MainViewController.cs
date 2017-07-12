using Foundation;
using System;
using UIKit;
using System.Collections.Generic;
using NavigationFromUnityToXamarin.HTTPRequestFolder;

namespace NavigationFromUnityToXamarin
{
    public partial class MainViewController : UIViewController
    {
        string desURL = "http://perceptweb.azurewebsites.net/api/venue/4/LocationOfInterestDetail/forOfflineD/destinations/";

        public List<string> choiceOfDes = new List<string>();

        public static string selectedDes;
        //public static LocationOfInterestDetail desObject; // for later use

        public MainViewController (IntPtr handle) : base (handle)
        {
        }

        public override void LoadView()
        {
            base.LoadView();
            loadDestination();

            desButton.TouchUpInside += ((sender, e) =>
            {
                UIAlertController destinationSheetAlert = UIAlertController.Create("Where do you want to go?", null, UIAlertControllerStyle.ActionSheet);
				destinationSheetAlert.AddAction(UIAlertAction.Create("Cancel", UIAlertActionStyle.Cancel, (action) => Console.WriteLine("Cancel button pressed.")));
				foreach (var des in choiceOfDes)
				{
					destinationSheetAlert.AddAction(UIAlertAction.Create(des, UIAlertActionStyle.Default, (action) => selectedDes = des));
				}

				UIPopoverPresentationController presentationPopover5 = destinationSheetAlert.PopoverPresentationController;
				if (presentationPopover5 != null)
				{
					presentationPopover5.SourceView = this.View;
					presentationPopover5.PermittedArrowDirections = UIPopoverArrowDirection.Up;
				}

				// Display the alert
				this.PresentViewController(destinationSheetAlert, true, null);
            });

            View.AddSubview(desButton);
        }

        #region Load destination information
        public async void loadDestination()
        {
            var httpDes = new HttpURL<LocationOfInterestDetail>();
            List<LocationOfInterestDetail> des = await httpDes.GetManyAsync(desURL);
			foreach (var d in des)
			{
				bool isDes = d.IsDestination;
				if (isDes)
				{
					var id = d.Id;
					var floor = d.Floor;
					var name = d.Name;
                    var landmarkLocationString = d.LandmarkLocationString;
					addTheDes(name);
				}

			}
        }

		public List<string> addTheDes(string s)
		{
			choiceOfDes.Add(s);
			return choiceOfDes;
		}

		#endregion

        public override void PrepareForSegue(UIStoryboardSegue segue, NSObject sender)
        {
            base.PrepareForSegue(segue, sender);
			if (segue.Identifier == "Show_Map")
			{
                Console.WriteLine(selectedDes);
				var MapViewContoller = segue.DestinationViewController as MapViewController;
				MapViewContoller.destination = selectedDes;
				//googleMapContoller.destinationCandidates = choicOfDes;
			}
        }
	}
}