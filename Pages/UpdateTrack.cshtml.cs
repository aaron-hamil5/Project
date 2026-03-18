using ChinookContext;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Project.Pages{
    public class UpdateTrack : PageModel{
        public Int32 TrackID {get; set;}
        public required String TrackName {get; set;}
        public void OnGet()
        {
            
        }
        public void OnPost()
        {
            TrackID = Int32.Parse(Request.Form["ddmSelTrack"]);

            ChinookDatabase db = new ChinookDatabase();
            Track updTrack = db.Tracks.Single(f => f.TrackId == TrackID);

            updTrack.Name = Request.Form["tbxUpdateTrackName"];
            updTrack.AlbumId = Int32.Parse(Request.Form["ddmUpdateAlbum"]);
            updTrack.MediaTypeId = Int32.Parse(Request.Form["ddmUpdateMedia"]);
            updTrack.GenreId = Int32.Parse(Request.Form["ddmUpdateGenre"]);
            updTrack.Composer = Request.Form["tbxUpdateComposerName"];
            updTrack.Milliseconds = Int32.Parse(Request.Form["tbxUpdateLengthName"]);
            updTrack.Bytes = Int32.Parse(Request.Form["tbxUpdateSizeName"]);
            updTrack.UnitPrice = Double.Parse(Request.Form["tbxUpdatePriceName"]);

            db.Tracks.Update(updTrack);
            db.SaveChanges();
        }
    }
}