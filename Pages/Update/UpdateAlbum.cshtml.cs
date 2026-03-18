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
            AlbumID = Int32.Parse(Request.Form["hdnAlbumID"]); //Getting the album we are in

            ChinookDatabase db = new ChinookDatabase();
            Album updAlbum = db.Albums.Single(f => f.AlbumId == AlbumID); //Putting it into a variable so we can start modifiying the data

            //Pulling updated info from the form
            updAlbum.Title = Request.Form["tbxNewAlbumName"];
            updAlbum.ArtistId = Int32.Parse(Request.Form["ddmNewArtist"]);

            //Updating and saving the database
            db.Albums.Update(updAlbum);
            db.SaveChanges();

            //Displays the Album it is in.
            AlbumName = updAlbum.Title;
        }
    }
}