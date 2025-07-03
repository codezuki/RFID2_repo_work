//document.addEventListener("DOMContentLoaded", function () {
//    const links = document.querySelectorAll(".sidebar .nav-link");
//    const currentPath = window.location.pathname.toLowerCase();

//    links.forEach(link => {
//        const href = link.getAttribute("href");
//        if (href && currentPath.startsWith(href.toLowerCase())) {
//            link.classList.add("active");
//            const parentCollapse = link.closest(".collapse");
//            if (parentCollapse) {
//                parentCollapse.classList.add("show");
//            }
//        }
//        link.setAttribute("title", link.textContent.trim());
//    });

//    const tooltipTriggerList = [].slice.call(document.querySelectorAll('[title]'));
//    tooltipTriggerList.forEach(el => {
//        new bootstrap.Tooltip(el);
//    });

//    // Optional: collapse sidebar on small screens
//    const toggleBtn = document.getElementById("sidebar-toggle");
//    const sidebar = document.querySelector(".sidebar");
//    if (toggleBtn && sidebar) {
//        toggleBtn.addEventListener("click", () => {
//            sidebar.classList.toggle("collapsed");
//        });
//    }
//});


// Combined version: wwwroot/js/sidebar-enhancements.js

document.addEventListener("DOMContentLoaded", function () {
    const sidebar = document.querySelector(".sidebar");
    const toggleBtn = document.getElementById("sidebar-toggle");
    const backdrop = document.getElementById("sidebar-backdrop");

    if (!sidebar) return;

    // Active link highlight
    const links = sidebar.querySelectorAll(".nav-link");
    const currentPath = window.location.pathname.toLowerCase();

    links.forEach(link => {
        const href = link.getAttribute("href");
        if (href && currentPath.startsWith(href.toLowerCase())) {
            link.classList.add("active");
            const parentCollapse = link.closest(".collapse");
            if (parentCollapse) {
                parentCollapse.classList.add("show");
            }
        }
        link.setAttribute("title", link.textContent.trim());
    });

    // Tooltip init
    const tooltipTriggerList = [].slice.call(document.querySelectorAll('[title]'));
    tooltipTriggerList.forEach(el => {
        new bootstrap.Tooltip(el);
    });

    // Toggle logic
    toggleBtn?.addEventListener("click", function () {
        const isMobile = window.innerWidth < 768;
        if (isMobile) {
            sidebar.classList.toggle("show-on-mobile");
            backdrop?.classList.toggle("active");
        } else {
            sidebar.classList.toggle("collapsed");
            localStorage.setItem('sidebar-collapsed', sidebar.classList.contains("collapsed"));
        }
    });

    backdrop?.addEventListener("click", () => {
        sidebar.classList.remove("show-on-mobile");
        backdrop.classList.remove("active");
    });

    // Restore collapsed state for desktop
    if (window.innerWidth >= 768 && localStorage.getItem("sidebar-collapsed") === "true") {
        sidebar.classList.add("collapsed");
    }
});
