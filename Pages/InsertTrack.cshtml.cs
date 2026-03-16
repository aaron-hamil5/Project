using ChinookContext;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Project.Pages{
    public class InsertTrack : PageModel{
        public Int32 AlbumID {get; set;}
        public required String TrackName {get; set;}
        public void OnGet()
        {
            
        }
        public void OnPost()
        {
            AlbumID = Int32.Parse(Request.Form["hdnAlbumID"]);
            TrackName = Request.Form["tbxTrackName"];
            Track insTrack = new Track() { 
                Name = Request.Form["tbxTrackName"],
                AlbumId = Int32.Parse(Request.Form["hdnAlbumID"]),
                MediaTypeId = 1,
                GenreId = 1,
                Composer = Request.Form["tbxComposerName"],
                Milliseconds = Int32.Parse(Request.Form["tbxLengthName"]),
                Bytes = Int32.Parse(Request.Form["tbxSizeName"]),
                UnitPrice = Double.Parse(Request.Form["tbxPriceName"]),
                };
            
            ChinookDatabase db = new ChinookDatabase();
            db.Tracks.Add(insTrack);
            db.SaveChanges();
        }
    }
}