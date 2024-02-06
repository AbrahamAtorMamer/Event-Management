// modal.js
function showModal() {
    const successModal = document.getElementById('success-modal');
    successModal.style.display = 'block';
}

function hideModal() {
    const successModal = document.getElementById('success-modal');
    successModal.style.display = 'none';
}

document.addEventListener('DOMContentLoaded', function () {
    const closeButton = document.querySelector('.close-button');

    closeButton.addEventListener('click', hideModal);

    window.addEventListener('click', function (event) {
        const successModal = document.getElementById('success-modal');
        if (event.target === successModal) {
            hideModal();
        }
    });
});
