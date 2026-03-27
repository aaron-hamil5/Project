using System.ComponentModel.DataAnnotations;

//This is the Albums table
public class Album{
    public Int32 AlbumId{get; set;}
    public required String Title{get; set;}
    public Int32 ArtistId{get; set;}
}

//This is the Artists table

public class Artist{
    public Int32 ArtistId{get; set;}
    public required String Name{get; set;}
}

//This is the Genres table
public class Genre{
    public Int32 GenreId{get; set;}
    public required String Name{get; set;}
}

//This is the MediaTypes table
public class MediaType{
    public Int32 MediaTypeId{get; set;}
    public required String Name{get; set;}
}


//This is the Tracks table
public class Track{
    public Int32 TrackId{get; set;}
    public required String Name{get; set;}
    public Int32 AlbumId{get; set;}
    public Int32 MediaTypeId{get; set;}
    public Int32 GenreId{get; set;}
    public String? Composer{get; set;}
    public Int32 Milliseconds{get; set;}
    public Int32 Bytes{get; set;}
    public Double UnitPrice{get; set;}
}

//This is the InvoiceItems table
public class InvoiceItem
{
    //https://learn.microsoft.com/en-us/ef/core/modeling/keys?tabs=data-annotations
    //Had to specify that the primary key is InvoiceLineId because it was not finding it.
    [Key]
    public Int32 InvoiceLineId {get; set;}
    public Int32 InvoiceId {get; set;}
    public Int32 TrackId {get; set;}
    public Double UnitPrice {get; set;}
    public Int32 Quantity {get; set;}
}

//This is the Playlists table
public class Playlist
{
    public Int32 PlaylistId {get; set;}
    public Int32 Name {get; set;}
}

//This is the PlaylistTracks table
public class PlaylistTrack
{
    //https://learn.microsoft.com/en-us/ef/core/modeling/keys?tabs=data-annotations
    //Had to specify that the primary key is PlaylistId because this table has 2 primary keys and didnt know which one to use.
    [Key]
    public Int32 PlaylistId { get; set; }
    public Int32 TrackId { get; set; }
}

//This is a class that has both Artist and Album tables for joining later.
public class ArtistAlbum{
    public Int32 ArtistId{get; set;}
    public required String Name{get; set;}
    public Int32 AlbumId{get; set;}
    public required String Title{get; set;}
}

//This is a class that has both Album and Track tables for joining later.
public class AlbumTrack{
    public Int32 AlbumId{get; set;}
    public required String Title{get; set;}
    public Int32 ArtistId{get; set;}
    public Int32 TrackId{get; set;}
    public required String Name{get; set;}
    public Int32 MediaTypeId{get; set;}
    public Int32 GenreId{get; set;}
    public String? Composer{get; set;}
    public Int32 Milliseconds{get; set;}
    public Int32 Bytes{get; set;}
    public Double UnitPrice{get; set;}
}