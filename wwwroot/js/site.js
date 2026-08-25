const header = document.querySelector("[data-header]");
const menuButton = document.querySelector("[data-menu-button]");
const menu = document.querySelector("[data-menu]");

const updateHeader = () => {
    header?.classList.toggle("scrolled", window.scrollY > 12);
};

menuButton?.addEventListener("click", () => {
    const isOpen = menu?.classList.toggle("open") ?? false;
    menuButton.setAttribute("aria-expanded", String(isOpen));
});

menu?.querySelectorAll("a").forEach((link) => {
    link.addEventListener("click", () => {
        menu.classList.remove("open");
        menuButton?.setAttribute("aria-expanded", "false");
    });
});

const observer = new IntersectionObserver(
    (entries) => {
        entries.forEach((entry) => {
            if (entry.isIntersecting) {
                entry.target.classList.add("visible");
                observer.unobserve(entry.target);
            }
        });
    },
    { threshold: 0.12 }
);

document.querySelectorAll(".reveal").forEach((element) => observer.observe(element));
window.addEventListener("scroll", updateHeader, { passive: true });
updateHeader();
