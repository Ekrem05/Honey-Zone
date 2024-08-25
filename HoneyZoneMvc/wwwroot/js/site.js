// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
    const togglerButton = document.getElementById('toggler');
    const phoneMenu = document.getElementById('phone-menu');

    togglerButton.addEventListener('click', function () {
        if (phoneMenu.style.display === 'none' || phoneMenu.style.display === '') {
        phoneMenu.style.display = 'block';
        } else {
        phoneMenu.style.display = 'none';
        }
    });
