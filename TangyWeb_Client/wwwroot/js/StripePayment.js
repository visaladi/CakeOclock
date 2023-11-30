redirectToCheckout = function (sessionId) {
    var stripe = Stripe("pk_test_51OHkI5GhXUw8WryJSSQRP6xoGDk4OICDpuL0xg6KEjqwEW8WTia3n8n1CJ7VDnciUYLtw1JDpN1vyuEn8pXAx0se00gzMd5RtM");

    stripe.redirectToCheckout({ sessionId: sessionId });

}

//redirectToCheckout = function (sessionId) {
//    var stripe = Stripe("pk_test_51OHkI5GhXUw8WryJSSQRP6xoGDk4OICDpuL0xg6KEjqwEW8WTia3n8n1CJ7VDnciUYLtw1JDpN1vyuEn8pXAx0se00gzMd5RtM");

//    try {
//        stripe.redirectToCheckout({ sessionId: sessionId });
//    } catch (error) {
//        console.error('Error during redirectToCheckout:', error);
//        // You can add additional error handling here, such as showing a user-friendly message to the user.
//    }
//}


