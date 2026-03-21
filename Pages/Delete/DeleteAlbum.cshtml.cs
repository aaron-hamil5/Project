using ChinookContext;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Project.Pages{
    public class DeleteAlbum : PageModel{
        //Getting required ID
        public Int32 TrackID {get; set;}
        public Int32 AlbumID {get; set;}
        public required String AlbumName {get; set;}
        public void OnGet()
        {
            
        }
        public void OnPost()
        {
            ChinookDatabase db = new ChinookDatabase();
            AlbumID = Int32.Parse(Request.Form["hdnAlbumID"]); //Save TrackId
            //Updating Strings for the HTML page.
            AlbumName = db.Albums.Single(f => f.AlbumId == AlbumID).Title;
            List<Track> remTracks = db.Tracks.Where(f => f.AlbumId == AlbumID).ToList(); //Find all tracks from its AlbumID

            foreach (Track track in remTracks){
                List<InvoiceItem> remInvoiceItems = db.Invoice_Items.Where(f => f.TrackId == track.TrackId).ToList();
                List<PlaylistTrack> remPlaylistTrack = db.Playlist_Track.Where(f => f.TrackId == track.TrackId).ToList();

                db.Invoice_Items.RemoveRange(remInvoiceItems);
                db.Playlist_Track.RemoveRange(remPlaylistTrack);
            }
            Album remAlbum = db.Albums.Single(f => f.AlbumId == AlbumID);

            //Bulk deleting Tracks first
            db.Tracks.RemoveRange(remTracks);
            db.SaveChanges();
            //Then deleting the Album
            db.Albums.Remove(remAlbum);
            db.SaveChanges();
        }
    }
}