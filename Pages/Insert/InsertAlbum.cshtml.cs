using ChinookContext;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Project.Pages{
    public class InsertAlbum : PageModel{
        public IActionResult OnPost()
        {
            String albumName = Request.Form["tbxAlbumName"];
            Album insAlbum = new Album() { 
                Title = Request.Form["tbxAlbumName"],
                ArtistId = Int32.Parse(Request.Form["ddmArtist"])
            };
            
            ChinookDatabase db = new ChinookDatabase();
            //Check if the Album exsits
            List<Album> checkAlbum = db.Albums.Where(w => w.Title.ToLower() == albumName.ToLower()).ToList();

            //If it does not exist, add it to the database
            if (!checkAlbum.Any()){
                db.Albums.Add(insAlbum);
                db.SaveChanges();
            }

            return Redirect("~/Index");
        }
    }
}