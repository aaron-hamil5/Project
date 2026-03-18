using ChinookContext;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc;

namespace Project.Pages{
    public class ViewAlbums : PageModel{
        //Creating a variable to hold what section of the page the user is in
        public required String Heading {get; set;}

        //Creating variable to hold data from their corisponding table
        public List<ArtistAlbum>ArtistAlbums{get; set;}
        public List<Artist> Artists {get; set;}

        //OnGet gets called when the page loads.
        public void OnGet(){
            //Setting the page title to Albums
            Heading = "Albums";

            ChinookDatabase db = new ChinookDatabase();
            //Linking Artist and Album togeter and adding it to the list
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

            //Getting the list of Artist for Add Album, Artist Drop Down List
            Artists = db.Artists.OrderBy(a => a.Name).ToList();
        }
    }
}