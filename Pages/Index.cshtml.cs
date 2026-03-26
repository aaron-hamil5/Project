using ChinookContext;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Project.Pages{
    public class ViewAlbums : PageModel{
        #region public Variables
        //Variables that the HTML will take from
        public required String Heading {get; set;} //Page Heading
        public List<ArtistAlbum>ArtistAlbums{get; set;} //Tables Artist & Albums linked in 1 list
        public List<Artist> Artists {get; set;} //List of artist for Drop Down Menu
        #endregion


        #region OnGet Method
        //This section links Artist & Albums tables together and sorts them Alphabetically by Artist Name
        public void OnGet(){
            //Setting the page title
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
        #endregion

        #region OnPost Method
        //Same logic as on get, but has logic to order the list alphabetically, Accending or decending by Artist or Album
        public void OnPost(){
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
            .ToList();

            //Getting the list of Artist for Add Album, Artist Drop Down List
            Artists = db.Artists.OrderBy(a => a.Name).ToList();

            //Sorts the table by user request
            if (Int32.Parse(Request.Form["ddmSort"]) == 0){
                ArtistAlbums = ArtistAlbums.OrderBy(a => a.Name).ToList();
            }
            else if (Int32.Parse(Request.Form["ddmSort"]) == 1){
                ArtistAlbums = ArtistAlbums.OrderByDescending(a => a.Name).ToList();
            }
            else if (Int32.Parse(Request.Form["ddmSort"]) == 2){
                ArtistAlbums = ArtistAlbums.OrderBy(a => a.Title).ToList();
            }
            else if (Int32.Parse(Request.Form["ddmSort"]) == 3){
                ArtistAlbums = ArtistAlbums.OrderByDescending(a => a.Title).ToList();
            }
        }
        #endregion
    }
}