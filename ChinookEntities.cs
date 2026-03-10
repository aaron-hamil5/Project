public class Albums{
    public Int32 AlbumId{get; set;}
    public required String Title{get; set;}
    public Int32 ArtistId{get; set;}
}

public class Artists{
    public Int32 ArtistId{get; set;}
    public required String Name{get; set;}
}

public class Tracks{
    public Int32 TrackId{get; set;}
    public required String Name{get; set;}
    public Int32 AlbumId{get; set;}
    public Int32 MediaTypeId{get; set;}
    public Int32 GenreId{get; set;}
    public required String Composer{get; set;}
    public Int32 Milliseconds{get; set;}
    public Int32 Bytes{get; set;}
    public Double UnitPrice{get; set;}
}