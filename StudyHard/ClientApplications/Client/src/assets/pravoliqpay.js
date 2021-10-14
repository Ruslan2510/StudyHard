window.initAngularLiqpay = function (pravoData, signature, router) {
    LiqPayCheckout.init({
        data: pravoData,
        signature: signature,
        embedTo: "#liqpay_checkout",
        language: "uk",
        mode: "embed"
    })
    .on("liqpay.callback",
        function (data) {
            var jwt = localStorage.getItem('access_token');
            $.ajax({
            type: 'POST',
            url: "/api/Liqpay/accept",
            data: JSON.stringify(data),
            headers: {
                'Accept':'application/json',
                'Content-Type':'application/json',
                'Authorization':'Bearer '+ jwt,
            },
            success: function (data) {
                window.angularComponentReference.zone.run(() => {
                    if (data) {
                        window.angularComponentReference.goToNewPostDetails();
                    }
                    else {
                        window.angularComponentReference.goToSubjects();
                    }
                });
            },
            error: function (errMsg) {
                console.log(errMsg);
            }
        })
    });
}