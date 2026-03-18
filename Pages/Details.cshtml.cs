using ChinookContext;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Project.Pages{
    public class ViewTracks : PageModel{
        //Creating a variable to hold what section of the page the user is in
        public required String Heading {get; set;}
        public required String AlbumName {get; set;}
        public required String ArtistName{get;set;}

        public List<AlbumTrack>AlbumTrack{get; set;}
        public List<Album> Albums{get; set;}
        public Album _Album{get; set;}

        public List<Genre> Genres {get; set;}
        public List<MediaType> MediaTypes {get; set;}
        public List<Artist> Artists {get; set;}
        

        public void OnPost(){
            Heading = "Viewing Tracks";

            ChinookDatabase db = new ChinookDatabase();
            Genres = db.Genres.ToList();
            MediaTypes = db.Media_Types.ToList();
            Artists = db.Artists.ToList();
            Albums = db.Albums.ToList();


            _Album = db.Albums.Single(f => f.AlbumId == Int32.Parse(Request.Form["hdnAlbumID"]));

            //Linking the Album and Tracks Table together
            AlbumTrack = db.Albums
            .Join(
                db.Tracks, a => a.AlbumId, t => t.AlbumId,
                (a,t) => new AlbumTrack(){
                    AlbumId = a.AlbumId,
                    Title = a.Title,
                    ArtistId = a.ArtistId,
                    TrackId = t.TrackId,
                    Name = t.Name,
                    MediaTypeId = t.MediaTypeId,
                    GenreId = t.GenreId,
                    Composer = t.Composer,
                    Milliseconds = t.Milliseconds,
                    Bytes = t.Bytes,
                    UnitPrice = t.UnitPrice,
                }
            )
            //Filtering it from the AlbumID
            .Where(a => a.AlbumId == Int32.Parse(Request.Form["hdnAlbumID"]))
            .ToList();

            //Searching the Artist Table for the name by the Artist ID
            ArtistName = db.Artists.Find(_Album.ArtistId).Name;

            //Displaying the Album name with the Artist name
            AlbumName = $"{_Album.Title} By {ArtistName}";
        }
        
    }
}