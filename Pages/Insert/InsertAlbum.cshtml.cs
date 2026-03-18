using ChinookContext;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Project.Pages{
    public class InsertAlbum : PageModel{
        public void OnGet()
        {

        }
        public IActionResult OnPost()
        {
            Album insAlbum = new Album() { 
                Title = Request.Form["tbxAlbumName"],
                ArtistId = Int32.Parse(Request.Form["ddmArtist"])
            };
            
            ChinookDatabase db = new ChinookDatabase();
            db.Albums.Add(insAlbum);
            db.SaveChanges();
            return Redirect("~/Index");
        }
    }
}