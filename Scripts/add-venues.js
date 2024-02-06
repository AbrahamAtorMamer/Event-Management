document.addEventListener('DOMContentLoaded', function() {
    const venueForm = document.getElementById('venue-form');
    const errorContainer = document.getElementById('error-container'); // Create an element to display errors

    venueForm.addEventListener('submit', function(event) {
        event.preventDefault();

        // Clear previous error messages
        errorContainer.innerHTML = '';

        // Retrieve form data
        const formData = new FormData(venueForm);
        
        // Validate the venue name (required)
        const venueName = formData.get('venue-name');
        if (!venueName) {
            displayError('Venue Name is required.');
            return;
        }

        // Validate the description (required)
        const description = formData.get('description');
        if (!description) {
            displayError('Description is required.');
            return;
        }

        // Validate the location address (required)
        const locationAddress = formData.get('location-address');
        if (!locationAddress) {
            displayError('Location Address is required.');
            return;
        }

        // Validate the capacity (required, must be a positive number)
        const capacity = formData.get('capacity');
        if (!capacity || isNaN(capacity) || capacity <= 0) {
            displayError('Capacity must be a positive number.');
            return;
        }

        

        // Example: Log form data to the console and submit the form
        for (const [key, value] of formData.entries()) {
            console.log(`${key}: ${value}`);
        }

        // Venue data is valid, submit the form
        venueForm.submit();
    });

    function displayError(message) {
        const errorElement = document.createElement('p');
        errorElement.textContent = message;
        errorContainer.appendChild(errorElement);
    }
});
