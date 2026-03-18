using ChinookContext;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Project.Pages{
    public class UpdateTrack : PageModel{
        //Getting required ID
        public Int32 TrackID {get; set;}
        public Int32 AlbumID {get; set;}
        public required String TrackName {get; set;}
        public void OnGet()
        {
            
        }
        public void OnPost()
        {
            TrackID = Int32.Parse(Request.Form["ddmSelTrack"]); //Save TrackId

            ChinookDatabase db = new ChinookDatabase();
            Track updTrack = db.Tracks.Single(f => f.TrackId == TrackID); //Find track from its TrackId

            //Updating all parts of the Track data
            updTrack.Name = Request.Form["tbxUpdateTrackName"];
            updTrack.AlbumId = Int32.Parse(Request.Form["ddmUpdateAlbum"]);
            updTrack.MediaTypeId = Int32.Parse(Request.Form["ddmUpdateMedia"]);
            updTrack.GenreId = Int32.Parse(Request.Form["ddmUpdateGenre"]);
            updTrack.Composer = Request.Form["tbxUpdateComposerName"];
            updTrack.Milliseconds = Int32.Parse(Request.Form["tbxUpdateLengthName"]);
            updTrack.Bytes = Int32.Parse(Request.Form["tbxUpdateSizeName"]);
            updTrack.UnitPrice = Double.Parse(Request.Form["tbxUpdatePriceName"]);

            //Updating the table then saving the Database
            db.Tracks.Update(updTrack);
            db.SaveChanges();

            //Updating Strings for the HTML page with the new data
            AlbumID = Int32.Parse(Request.Form["ddmUpdateAlbum"]);
            TrackName = Request.Form["tbxUpdateTrackName"];
        }
    }
}