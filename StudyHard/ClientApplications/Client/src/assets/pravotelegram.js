function testPing() {
    window.angularComponentReference.zone.run(() => {
        window.angularComponentReference.navigateAfterLogin();
    });
}
function loginWithTelegram(user) {
    console.log(user);
    $.ajax({
        type: "POST",
        url: "/api/account/telegram",
        data: JSON.stringify({
            id: user.id.toString(),
            photoUrl: user.photo_url,
            username: user.username,
            firstName: user.first_name
        }),
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (response) {
            console.log(response);
            localStorage.setItem('access_token', response.access_token);
            localStorage.setItem('expires', response.expiresIn);
            window.angularComponentReference.zone.run(() => {
                window.angularComponentReference.navigateAfterLogin();
            });

        },
        error: function (errMsg) {
            console.log(errMsg);
        }
    });
}