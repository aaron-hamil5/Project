let open = false;

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