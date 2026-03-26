using ChinookContext;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Project.Pages{
    public class InsertArtist : PageModel{
        public IActionResult OnPost()
        {
            //Saving the text in a variable 
            String artistName = Request.Form["tbxArtistName"];
            Artist insArtist = new Artist() { Name = Request.Form["tbxArtistName"] };
            
            ChinookDatabase db = new ChinookDatabase();
            //Check the database if they exist already
            List<Artist> checkArtist = db.Artists.Where(w => w.Name.ToLower() == artistName.ToLower()).ToList();

            if (!checkArtist.Any())
            {
                // If the artist doesnt exist then we add it else we dont save it
                db.Artists.Add(insArtist);
                db.SaveChanges();
            }
            return Redirect("~/Insert/AddArtistAlbum");
        }
    }
}