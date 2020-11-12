function Login() {
    var UserRoleVM = new Object();
    UserRoleVM.User_Email = $('#email').val();
    UserRoleVM.User_Password = $('#password').val();
    //debugger;
    $.ajax({
        type: "Post",
        url: '/Login/Get/',
        data: UserRoleVM
    }).then((result) => {
        if (result.result == 'Redirect') {
            window.location = result.url;
        }
    }).catch((error) => {
        console.log(error);
    });
}