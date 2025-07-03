/*document.addEventListener("DOMContentLoaded", () => {
    const selector = document.getElementById('theme-selector');
    const savedTheme = localStorage.getItem('theme') || 'blue';

    // Apply saved theme on load
    document.body.classList.remove('theme-blue', 'theme-light');
    document.body.classList.add('theme-' + savedTheme);
    if (selector) selector.value = savedTheme;

    // Change theme on dropdown selection
    selector?.addEventListener('change', function () {
        document.body.classList.remove('theme-blue', 'theme-light');
        document.body.classList.add('theme-' + this.value);
        localStorage.setItem('theme', this.value);
    });
});*/
