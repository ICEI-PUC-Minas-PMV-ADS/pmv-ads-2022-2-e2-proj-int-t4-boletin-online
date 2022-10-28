function search_student() {
    let input = document.getElementById("txtsearch").value
    input = input.toLowerCase();
    let x = document.getElementsByClassName("student");

    for (i = 0; i < x.length; i++) {
        if (!x[i].innerHTML.toLowerCase().includes(input)) {
            x[i].style.display = "none";
        }
        else {
            x[i].style.display = "list-item";
        }
    }


}

function toggle_enable_update_studant_button() {
    let button_is_disabled = document.getElementById("updateStudent").disabled

    if (button_is_disabled) {
        document.getElementById("updateStudent").disabled = false;
    } else {
        document.getElementById("updateStudent").disabled = true;
    }
}

function toggle_enable_consult_studant_button() {
    let button_is_disabled = document.getElementById("consultStudent").disabled

    if (button_is_disabled) {
        document.getElementById("consultStudent").disabled = false;
    } else {
        document.getElementById("consultStudent").disabled = true;
    }

}

function toggle_enable_insert_studant_button() {
    let button_is_disabled = document.getElementById("insertStudent").disabled

    if (button_is_disabled) {
        document.getElementById("insertStudent").disabled = false;
    } else {
        document.getElementById("insertStudent").disabled = true;
    }
}




