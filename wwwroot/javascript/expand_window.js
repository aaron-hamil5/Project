let open = false;

//Function to open the modify window, if the window is closed it will open it, if its open it will close it
function open_window(){
    let window = document.getElementById("modify_window")
    if (!open){
        window.style.height = "auto";
        open = !open;
    } else if (open){
        window.style.height = "30px";
        open = !open;
    }
}