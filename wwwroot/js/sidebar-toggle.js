document.addEventListener("DOMContentLoaded", function () {
    const sidebar = document.querySelector(".sidebar");
    const toggleBtn = document.getElementById("sidebar-toggle");
    const backdrop = document.getElementById("sidebar-backdrop");

    function toggleSidebar() {
        const isVisible = sidebar.classList.contains("show-on-mobile");
        sidebar.classList.toggle("show-on-mobile", !isVisible);
        backdrop.classList.toggle("active", !isVisible);
    }

    toggleBtn?.addEventListener("click", toggleSidebar);
    backdrop?.addEventListener("click", toggleSidebar);
});
