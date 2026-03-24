function deleteTrackRequest(){
    //Find the elements by their IDs
    let request = document.getElementById("delete_track")
    let confirm = document.getElementById("delete_track_confirm")
    //Hide the button and show the confimation
    request.style.display = "none";
    confirm.style.display = "block";
}
function deleteAlbumRequest(){
    //Find the elements by their IDs
    let request = document.getElementById("delete_album")
    let confirm = document.getElementById("delete_album_confirm")
    //Hide the button and show the confimation
    request.style.display = "none";
    confirm.style.display = "block";
}