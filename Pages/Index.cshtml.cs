using ChinookContext;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Project.Pages{
    public class ViewAlbums : PageModel{
        //Creating a variable to hold what section of the page the user is in
        public required String Heading {get; set;}

        public List<Album>Albums{get; set;}

        //OnGet gets called when the page loads.
        public void OnGet(){
            //Setting the page title to Albums
            Heading = "Albums";

            ChinookDatabase db = new ChinookDatabase();
            Albums = db.Albums.ToList();
        }
    }
}