using ChinookContext;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Project.Pages{
    public class ViewAlbums : PageModel{
        //Creating a variable to hold what section of the page the user is in
        public required String Heading {get; set;}

        public List<ArtistAlbum>ArtistAlbums{get; set;}

        //OnGet gets called when the page loads.
        public void OnGet(){
            //Setting the page title to Albums
            Heading = "Albums";

            ChinookDatabase db = new ChinookDatabase();
            ArtistAlbums = db.Artists.Join(
                db.Albums, art => art.ArtistId, alb => alb.AlbumId,
                (art,alb) => new ArtistAlbum()
                {
                    ArtistId = art.ArtistId,
                    Name = art.Name,
                    AlbumId = alb.AlbumId,
                    Title = alb.Title
                }
            ).ToList();
        }
    }
}