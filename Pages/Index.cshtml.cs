using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Project.Pages{
    public class ViewAlbums : PageModel{
        //Creating a variable to hold what section of the page the user is in
        public required String Heading {get; set;}

        //OnGet gets called when the page loads.
        public void OnGet(){
            //Setting the page title to Albums
            Heading = "Albums";
        }
    }
}