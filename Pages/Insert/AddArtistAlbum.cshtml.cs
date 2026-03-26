using ChinookContext;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Project.Pages{
    public class AddArtistAlbums : PageModel{
        #region public Variables
        //Variables that the HTML will take from
        public List<Artist> Artists {get; set;} //List of artist for Drop Down Menu
        #endregion


        #region OnGet Method
        //This section links Artist & Albums tables together and sorts them Alphabetically by Artist Name
        public void OnGet(){
            ChinookDatabase db = new ChinookDatabase();

            //Getting the list of Artist for Add Album, Artist Drop Down List
            Artists = db.Artists.OrderBy(a => a.Name).ToList();
        }
        #endregion
    }
}