function Forgot() {
    var UserRoleVM = new Object();
    UserRoleVM.User_Email = $('#email').val();
    $.ajax({
        type: "Patch",
        url: '/Login/Forgot/',
        data: UserRoleVM
    }).then((result) => {
        //debugger;
        console.log(result);
        if (result.data == 200) {
            Swal.fire({
                position: 'center',
                type: 'success',
                icon: 'success',
                title: 'Forgot Success, check Your Email',
                
            }).then(() => {
                window.location = result.url;
            });
        }
        else {
            Swal.fire({
                position: 'center',
                type: 'error',
                icon: 'error',
                title: 'Failed!'
            });
        }
    }).catch((error) => {
        console.log(error);
    });
}