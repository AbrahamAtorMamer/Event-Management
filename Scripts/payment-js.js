document.addEventListener('DOMContentLoaded', function () {
    const form = document.getElementById('payment-form');
    const cancelButton = document.getElementById('cancel-button');

    form.addEventListener('submit', function (e) {
        e.preventDefault();

        // Simulate payment processing (replace with actual payment gateway integration)
        const paymentSuccess = processPayment();

        if (paymentSuccess) {
            // Payment was successful, you can redirect or show a thank you message
            //alert('Payment successful! Redirecting to Home page...');
            showModal();
            // You can replace this with an actual redirect URL
            window.location.href = 'index.html';
        } else {
            // Payment failed, you can display an error message
            //alert('Payment failed. Please try again.');
            showModal();
        }
    });

    cancelButton.addEventListener('click', function () {
        // Redirect the user to the previous page
        history.back();
    });

    // Simulated payment processing function (replace with actual payment gateway integration)
    function processPayment() {
        // Simulate success by returning true (replace this with your real payment gateway logic)
        return Math.random() < 0.8; // Simulate an 80% success rate
    }
});

