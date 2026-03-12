public class Album{
    public Int32 AlbumId{get; set;}
    public required String Title{get; set;}
    public Int32 ArtistId{get; set;}
}

public class Artist{
    public Int32 ArtistId{get; set;}
    public required String Name{get; set;}
}

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

public class AlbumTrack{
    public Int32 AlbumId{get; set;}
    public required String Title{get; set;}
    public Int32 TrackId{get; set;}
    public required String Name{get; set;}
    public Int32 MediaTypeId{get; set;}
    public Int32 GenreId{get; set;}
    public String? Composer{get; set;}
    public Int32 Milliseconds{get; set;}
    public Int32 Bytes{get; set;}
    public Double UnitPrice{get; set;}
}