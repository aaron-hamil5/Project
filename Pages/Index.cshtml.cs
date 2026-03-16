using ChinookContext;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc;

namespace Project.Pages{
    public class ViewAlbums : PageModel{
        //Creating a variable to hold what section of the page the user is in
        public required String Heading {get; set;}

        public Boolean AccendingFilter {get; set;} = true;

        public List<ArtistAlbum>ArtistAlbums{get; set;}

        public List<Artist> Artists {get; set;}

        //OnGet gets called when the page loads.
        public void OnGet(){
            //Setting the page title to Albums
            Heading = "Albums";

            ChinookDatabase db = new ChinookDatabase();
            //Linking Artist and Album togeter
            ArtistAlbums = db.Artists.Join(
                db.Albums, art => art.ArtistId, alb => alb.ArtistId,
                (art,alb) => new ArtistAlbum()
                {
                    ArtistId = art.ArtistId,
                    Name = art.Name,
                    AlbumId = alb.AlbumId,
                    Title = alb.Title
                }
            )
            .OrderBy(a => a.Name)
            .ToList();

            //Getting the list of Artist
            Artists = db.Artists.OrderBy(a => a.Name).ToList();
        }
    }
}