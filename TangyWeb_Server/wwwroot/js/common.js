window.ShowToastr = (type, message) => {
    if (type === "success") {
        toastr.success(message, 'Operation Successful', { timeOut: 5000 });
    }

    if (type === "error") {
        toastr.error(message, 'Operation Faild', { timeOut: 5000 });
    }
}

window.ShowSwal = (type, message) => {
    if (type === "success") {
        Swal.fire({
            title: "Success Notification!",
            text: message,
            icon: "success"
        });
    }

    if (type === "error") {
        Swal.fire({
            title: "Error Notification!",
            text: message,
            icon: "error"
        });
    }
}
function ShowDeleteConfiremationModel() {
    $('#deleteConfirmationModal').modal('show');
}

function HideDeleteConfiremationModel() {
    $('#deleteConfirmationModal').modal('hide');
}