function showDataAlert() {

    var confirmStatus = confirm("Silmek istediğinize emin misiniz?");
    if (confirmStatus==true) {
        return true;
    }
    else {
        return false;
    }

    
}