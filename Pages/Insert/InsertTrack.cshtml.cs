using ChinookContext;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Project.Pages{
    public class InsertTrack : PageModel{
        public Int32 AlbumID {get; set;}
        public required String TrackName {get; set;}
        public void OnPost()
        {
            AlbumID = Int32.Parse(Request.Form["hdnAlbumID"]);
            TrackName = Request.Form["tbxTrackName"];
            
            Track insTrack = new Track() { 
                Name = Request.Form["tbxTrackName"],
                AlbumId = Int32.Parse(Request.Form["hdnAlbumID"]),
                MediaTypeId = Int32.Parse(Request.Form["ddmMedia"]),
                GenreId = Int32.Parse(Request.Form["ddmGenre"]),
                Composer = Request.Form["tbxComposerName"],
                Milliseconds = ((Int32.Parse(Request.Form["tbxMinuteName"]) * 60) + Int32.Parse(Request.Form["tbxSecondName"])) * 1000, //We are converting minutes to seconds, adding the remaining seconds then timesing it to get the milisecond
                Bytes = Int32.Parse(Request.Form["tbxSizeName"]) * 1048576, //We are taking in MB so we need to times it by 1048576 to get the bytes
                UnitPrice = Double.Parse(Request.Form["tbxPriceName"]),
                };
            
            ChinookDatabase db = new ChinookDatabase();
            db.Tracks.Add(insTrack);
            db.SaveChanges();
        }
    }
}