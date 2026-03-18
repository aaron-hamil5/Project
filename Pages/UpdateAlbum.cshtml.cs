using ChinookContext;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Project.Pages{
    public class UpdateAlbum : PageModel{
        public Int32 AlbumID {get; set;}
        public required String AlbumName {get; set;}
        public void OnGet()
        {
            
        }
        public void OnPost()
        {
            AlbumID = Int32.Parse(Request.Form["hdnAlbumID"]);

            ChinookDatabase db = new ChinookDatabase();
            Album updAlbum = db.Albums.Single(f => f.AlbumId == AlbumID);

            updAlbum.Title = Request.Form["tbxNewAlbumName"];
            updAlbum.ArtistId = Int32.Parse(Request.Form["ddmNewArtist"]);

            db.Albums.Update(updAlbum);
            db.SaveChanges();

            AlbumName = updAlbum.Title;
        }
    }
}