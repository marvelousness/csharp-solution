$(function () {
    f.username.value = username.value = "root";
    f.password.value = password.value = "123";
    $("#f button").on("click", login);
});


function login() {
    let uri = location.pathname.endsWith(".html") ? "/login" : "/login.ashx";
    $.post(uri, {
        username: f.username.value,
        password: f.password.value,
    }, function (resp) {
        if (resp == "OK") {
            location.href = "/";
        }
    });
}