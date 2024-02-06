document.addEventListener('DOMContentLoaded', function() {
    const editVenueForm = document.getElementById('edit-venue-form');

    editVenueForm.addEventListener('submit', function(event) {
        event.preventDefault();

        // Clear previous error messages
        clearErrorMessages();

        // Retrieve form data
        const formData = new FormData(editVenueForm);

        // Validate the venue name (required)
        const editVenueName = formData.get('edit-venue-name');
        if (!editVenueName) {
            displayError('edit-venue-name', 'Venue Name is required.');
            return;
        }

        // Validate the description (required)
        const editDescription = formData.get('edit-description');
        if (!editDescription) {
            displayError('edit-description', 'Description is required.');
            return;
        }

        // Validate the location address (required)
        const editLocationAddress = formData.get('edit-location-address');
        if (!editLocationAddress) {
            displayError('edit-location-address', 'Location Address is required.');
            return;
        }

        // Validate the capacity (required, must be a positive number)
        const editCapacity = formData.get('edit-capacity');
        if (!editCapacity || isNaN(editCapacity) || editCapacity <= 0) {
            displayError('edit-capacity', 'Capacity must be a positive number.');
            return;
        }

        for (const [key, value] of formData.entries()) {
            console.log(`${key}: ${value}`);
        }

        // Venue data is valid, submit the form
        // editVenueForm.submit();
    });

    function displayError(fieldId, message) {
        const field = document.getElementById(fieldId);
        const errorElement = document.createElement('p');
        errorElement.className = 'error-message';
        errorElement.textContent = message;
        field.parentNode.appendChild(errorElement);
    }

    function clearErrorMessages() {
        const errorMessages = document.querySelectorAll('.error-message');
        errorMessages.forEach(function(errorMessage) {
            errorMessage.remove();
        });
    }
});
