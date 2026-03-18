using ChinookContext;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Project.Pages{
    public class InsertArtist : PageModel{
        public void OnGet()
        {

        }
        public IActionResult OnPost()
        {
            Artist insArtist = new Artist() { Name = Request.Form["tbxArtistName"] };
            
            ChinookDatabase db = new ChinookDatabase();
            db.Artists.Add(insArtist);
            db.SaveChanges();
            return Redirect("~/Index");
        }
    }
}