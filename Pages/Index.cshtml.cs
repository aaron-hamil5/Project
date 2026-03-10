using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Project.Pages{
    public class ViewAlbums : PageModel{
        public required String Heading {get; set;}

        public void OnGet(){
            Heading = "Albums";
        }
    }
}