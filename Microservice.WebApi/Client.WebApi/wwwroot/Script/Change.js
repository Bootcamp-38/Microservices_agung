function Change() {
    var UserRoleVM = new Object();
    UserRoleVM.User_Password = $('#password').val();
    $.ajax({
        type: "PUT",
        url: '/Login/Change/',
        data: UserRoleVM
    }).then((result) => {
        if (result.statusCode == 200) {
            if (result.result == 'Redirect') {
                Swal.fire({
                    position: 'top-center',
                    icon: 'success',
                    title: 'Password Updated',
                    showConfirmButton: true,
                    timer: 3000
                });
                window.location = result.url;
            } else {
                Swal.fire({
                    position: 'top-center',
                    icon: 'Error',
                    title: 'Password Cannot Updated',
                    showConfirmButton: true,
                    timer: 3000
                });
            }
        }
    });
}