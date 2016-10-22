$('document').ready(function () {
    Stripe.setPublishableKey('pk_test_QjWaF9I2pEalkH8dKsqLaJZW');
    $('#btnCharge').on('click', function (e) {
        e.preventDefault();
        e.stopPropagation();

        Stripe.card.createToken({
            number: $('#txtCardNumber').val(),
            cvc: $('#txtCvc').val(),
            exp_month: $('#txtExpiryMonth').val(),
            exp_year: $('#txtExpiryYear').val()
        }, stripeResponseHandler);
    });

    function stripeResponseHandler(status, response) {
        var $form = $('#frmCharge');
        if (response.error) {
            // Show the errors on the form
            alert(response.error.message);
        } else {
            // response contains id and card, which contains additional card details
            var token = response.id;
            // Insert the token into the form so it gets submitted to the server
            $('#hdnToken').val(token);
            alert('your hidden token for payment ' + token);
            // and submit
            $form.get(0).submit();
        }
    }
    var edd_stripe_vars = { "publishable_key": "pk_test_QjWaF9I2pEalkH8dKsqLaJZW Roll Key", "is_ajaxed": "true" };
});