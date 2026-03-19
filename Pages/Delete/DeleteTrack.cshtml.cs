using ChinookContext;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Project.Pages{
    public class DeleteTrack : PageModel{
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
            Track remTrack = db.Tracks.Single(f => f.TrackId == TrackID); //Find track from its TrackId

            //Updating the table then saving the Database
            db.Tracks.Remove(remTrack);
            db.SaveChanges();

            //Updating Strings for the HTML page.
            AlbumID = remTrack.AlbumId;
            TrackName = remTrack.Name;
        }
    }
}