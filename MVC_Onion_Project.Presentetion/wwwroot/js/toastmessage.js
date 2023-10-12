function showWarningMessage() {
    if (messageFromServer) {
        toastr.warning('Bu bir uyarıdır!', 'Uyarı');
    }

    function showInfoMessage() {
        if (messageFromServer) {
            toastr.info('Bilgi mesajı!', 'Bilgi');
        }
        function showSuccessMessage() {
            if (messageFromServer) {
                toastr.success(messageFromServer, 'Başarılı');
            }
        }

        function showErrorMessage() {
            if (messageFromServer) {
                toastr.error(messageFromServer, 'Hata');
            }
        }