using ChinookContext;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Project.Pages{
    public class SearchQuery : PageModel{
        //Creating a variable to hold what section of the page the user is in
        public required String Query {get; set;}

        //Creating a variable that tiggers when no results are found
        public Boolean NoResults {get; set;} = false;
        //Creating variable to hold data from their corisponding table
        public List<ArtistAlbum>ArtistAlbums{get; set;}
        public List<Artist> Artists {get; set;}

        //OnGet gets called when the page loads.
        public void OnPost(){
            //Setting the page title to Albums
            Query = Request.Form["tbxSearch"];

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
            .Where(a => a.Title.ToLower() == Query.ToLower()) //Using .ToLower() so any strange capilization by artist or input will still be found
            .OrderBy(a => a.Name)
            .ToList();

            //If there is nothing in the list, try looking up by artist next
            if (!ArtistAlbums.Any())
            {
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
            .Where(a => a.Name.ToLower() == Query.ToLower()) //Using .ToLower() so any strange capilization by artist or input will still be found
            .OrderBy(a => a.Title)
            .ToList();

            
                if (!ArtistAlbums.Any()){
                    //If no artist is also found, no results warning will display
                    NoResults = true;
                }
            }

            //Getting the list of Artist for Add Album, Artist Drop Down List
            Artists = db.Artists.OrderBy(a => a.Name).ToList();
        }
    }
}