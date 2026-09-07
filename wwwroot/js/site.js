/* ==========================================================================
   PORTFOLIO INTERACTIVE CONTROLLER
   - Real-time PHT Clock
   - Interactive Terminal Widget (>_ seth-terminal)
   - Independent Center Stream Scrollspy & Navigation Sync
   - AI Assistant Slide-over Drawer
   - Mobile Navigation Drawer
   ========================================================================== */

document.addEventListener("DOMContentLoaded", () => {
    initPhtClock();
    initTerminal();
    initScrollspy();
    initAiDrawer();
    initMobileNav();
    initTechPills();
    initCopyEmail();
});

/* --------------------------------------------------------------------------
   1. REAL-TIME PHILIPPINE STANDARD TIME (PHT GMT+8) CLOCK
   -------------------------------------------------------------------------- */
function initPhtClock() {
    const clockEl = document.getElementById("live-pht-clock");
    if (!clockEl) return;

    function updateClock() {
        try {
            const options = {
                timeZone: "Asia/Manila",
                hour12: true,
                hour: "2-digit",
                minute: "2-digit",
                second: "2-digit"
            };
            const formatter = new Intl.DateTimeFormat("en-US", options);
            const timeString = formatter.format(new Date());
            clockEl.textContent = `PHT (GMT+8) • ${timeString}`;
        } catch (e) {
            clockEl.textContent = "PHT (GMT+8)";
        }
    }

    updateClock();
    setInterval(updateClock, 1000);
}

/* --------------------------------------------------------------------------
   2. INTERACTIVE TERMINAL WIDGET (>_ seth-terminal)
   -------------------------------------------------------------------------- */
function initTerminal() {
    const form = document.getElementById("terminal-form");
    const input = document.getElementById("terminal-input");
    const historyContainer = document.getElementById("terminal-history");
    const terminalBody = document.getElementById("terminal-body");

    if (!form || !input || !historyContainer) return;

    const commands = {
        help: () => [
            "Available commands:",
            "  about        - Overview of Seth Andrey Jabagat",
            "  skills       - Core capabilities & tech stack",
            "  projects     - Deployed applications & solutions",
            "  experience   - Leadership, roles & track record",
            "  education    - Academic background & scholarships",
            "  contact      - Direct email, Teams & social links",
            "  uptime       - System reliability & hosting status",
            "  hire         - Employment availability & roles",
            "  quote        - Daily perspective quote",
            "  date         - Current Philippine Standard Time",
            "  clear        - Clear terminal history"
        ].join("\n"),

        about: () => 
            "Seth Andrey Jabagat\n" +
            "Junior Software Developer based in Cebu, Philippines.\n" +
            "Focused on Microsoft Power Platform (Power Apps, Automate),\n" +
            "C# / ASP.NET Core, Laravel, and practical user-centered software.",

        skills: () =>
            "Core Technologies:\n" +
            "• Microsoft & Low-Code: Power Apps, Power Automate, C#, ASP.NET Core\n" +
            "• Web & Data: HTML, CSS, JavaScript, PHP, Laravel, MySQL\n" +
            "• Cloud & DevOps: Azure, Vercel, Render, Docker, GitHub\n" +
            "• Design & AI: UI/UX Design, GitHub Copilot, Microsoft Copilot",

        projects: () =>
            "Key Projects:\n" +
            "1. Library Management System [Academic Project - Completed]\n" +
            "2. Hotel Booking System [PHP/Laravel - Full-Stack]\n" +
            "3. Activity Proposal System [Microsoft Power Platform - Internal]\n" +
            "4. REACH System [Community SMS Relief Automation]",

        experience: () =>
            "Experience:\n" +
            "• Youth Empowerment Participant (2025 – Present)\n" +
            "• Industry Learning: Accenture & AI Talks (2026)\n" +
            "• Alliance Student Developer (2025)",

        education: () =>
            "Education:\n" +
            "• Associate in Computer Technology — University of San Jose-Recoletos (2024–2026)\n" +
            "• Technology Scholar — Passerelles Numériques Philippines (Class of 2026)\n" +
            "• Senior High School — Mantalongon NHS (2021–2023)",

        contact: () =>
            "Contact Channels:\n" +
            "• Email: sethandreyabrasado@gmail.com\n" +
            "• Teams: Chat link on portfolio page\n" +
            "• GitHub: https://github.com/gsi78eywh\n" +
            "• LinkedIn: linkedin.com/in/seth-andrey-abrasado-868419366",

        uptime: () => "Uptime: 99.9% Operational | Deployed on Render Cloud with ASP.NET Core 8",

        hire: () => 
            "STATUS: Available for Hire!\n" +
            "Open to internships, junior software engineer, and Power Platform developer roles.\n" +
            "Send an email or message on Teams to connect!",

        quote: () => {
            const blockquote = document.querySelector(".quote-text-block");
            return blockquote ? blockquote.textContent.trim() : "“Always focus on your own lane.” — Sylvia Salow";
        },

        date: () => {
            return new Date().toLocaleString("en-US", { timeZone: "Asia/Manila" }) + " PHT";
        },

        sudo: () => "Permission granted: You are already operating in guest superuser mode.",

        clear: () => {
            historyContainer.innerHTML = "";
            return null;
        }
    };

    form.addEventListener("submit", (e) => {
        e.preventDefault();
        const rawCmd = input.value.trim();
        if (!rawCmd) return;

        const cmdLower = rawCmd.toLowerCase();
        
        const entry = document.createElement("div");
        entry.className = "term-output-entry";

        const echo = document.createElement("div");
        echo.className = "term-cmd-echo";
        echo.textContent = `$ ${rawCmd}`;
        entry.appendChild(echo);

        let outputText = "";
        if (commands[cmdLower]) {
            outputText = commands[cmdLower]();
        } else {
            outputText = `seth-sh: command not found: ${rawCmd}. Type 'help' to see valid commands.`;
        }

        if (outputText !== null) {
            const resp = document.createElement("div");
            resp.className = "term-response";
            resp.textContent = outputText;
            entry.appendChild(resp);
            historyContainer.appendChild(entry);
        }

        input.value = "";
        terminalBody.scrollTop = terminalBody.scrollHeight;
    });
}

/* --------------------------------------------------------------------------
   3. SEPARATE SCROLLABLE MIDDLE CONTAINER & SCROLLSPY
   (The center stream scrolls independently while sidebars remain fixed;
    the navigation dynamically moves the active hover/pill as you scroll!)
   -------------------------------------------------------------------------- */
function initScrollspy() {
    const centerStream = document.getElementById("center-stream");
    const navLinks = document.querySelectorAll(".nav-mono-link");
    const mobileLinks = document.querySelectorAll(".mobile-nav-link");

    const sectionIds = [
        "about",
        "experience",
        "projects",
        "stack",
        "certifications",
        "recommendations",
        "courses",
        "answers",
        "contact"
    ];

    const sections = sectionIds
        .map(id => document.getElementById(id))
        .filter(Boolean);

    function setActive(id) {
        if (!id) return;
        
        navLinks.forEach(link => {
            const linkTarget = link.getAttribute("href")?.replace("#", "");
            if (linkTarget === id) {
                link.classList.add("active");
            } else {
                link.classList.remove("active");
            }
        });

        mobileLinks.forEach(link => {
            const linkTarget = link.getAttribute("href")?.replace("#", "");
            if (linkTarget === id) {
                link.classList.add("active");
            } else {
                link.classList.remove("active");
            }
        });
    }

    // Scroll listener on the middle container (.center-stream)
    if (centerStream) {
        let isManualClick = false;
        let clickTimeout = null;

        function updateOnScroll() {
            if (isManualClick) return;

            // Calculate active section based on center-stream scroll position
            const streamScrollTop = centerStream.scrollTop;
            let currentId = sections[0]?.id || "about";

            for (let i = 0; i < sections.length; i++) {
                const sec = sections[i];
                // Offset calculation within the scroll container
                if (sec.offsetTop - 140 <= streamScrollTop) {
                    currentId = sec.id;
                }
            }
            setActive(currentId);
        }

        centerStream.addEventListener("scroll", updateOnScroll, { passive: true });

        // Click handler for navigation links
        navLinks.forEach(link => {
            link.addEventListener("click", (e) => {
                const href = link.getAttribute("href");
                if (href && href.startsWith("#")) {
                    e.preventDefault();
                    const targetId = href.substring(1);
                    const targetSec = document.getElementById(targetId);
                    
                    if (targetSec) {
                        isManualClick = true;
                        clearTimeout(clickTimeout);
                        setActive(targetId);

                        const targetTop = targetSec.offsetTop - 14;
                        centerStream.scrollTo({
                            top: targetTop,
                            behavior: "smooth"
                        });

                        clickTimeout = setTimeout(() => {
                            isManualClick = false;
                        }, 700);
                    }
                }
            });
        });
    }

    // Fallback window scroll for mobile viewports
    window.addEventListener("scroll", () => {
        if (window.innerWidth <= 1024) {
            const scrollY = window.scrollY;
            let currentId = sections[0]?.id || "about";

            for (let i = 0; i < sections.length; i++) {
                const sec = sections[i];
                if (sec.offsetTop - 120 <= scrollY) {
                    currentId = sec.id;
                }
            }
            setActive(currentId);
        }
    }, { passive: true });

    // Initial check
    setActive("about");
}

/* --------------------------------------------------------------------------
   4. INTERACTIVE TECH STACK PILLS (CLICK TO REVEAL PERCENTAGE)
   -------------------------------------------------------------------------- */
function initTechPills() {
    const layout = document.querySelector(".tech-stack-pills-layout");
    const pills = document.querySelectorAll(".tech-pill-btn");
    const toggleAllBtn = document.getElementById("btn-toggle-all-pct");
    const detailToast = document.getElementById("skill-detail-toast");
    const toastName = document.getElementById("toast-name");
    const toastLevel = document.getElementById("toast-level");
    const toastDesc = document.getElementById("toast-desc");
    const toastBadge = document.getElementById("toast-pct-badge");
    const toastFill = document.getElementById("toast-fill");
    const toastClose = document.getElementById("toast-close");

    if (!pills.length) return;

    pills.forEach(pill => {
        pill.addEventListener("click", () => {
            const isAlreadyActive = pill.classList.contains("is-active");

            // Deactivate all pills first
            pills.forEach(p => p.classList.remove("is-active"));

            if (!isAlreadyActive) {
                pill.classList.add("is-active");

                const name = pill.getAttribute("data-skill-name") || "";
                const pct = pill.getAttribute("data-skill-pct") || "80";
                const level = pill.getAttribute("data-skill-level") || "";
                const desc = pill.getAttribute("data-skill-desc") || "";

                if (detailToast && toastName && toastLevel && toastDesc && toastBadge && toastFill) {
                    toastName.textContent = name;
                    toastLevel.textContent = level;
                    toastDesc.textContent = desc;
                    toastBadge.textContent = `${pct}%`;
                    toastFill.style.width = `${pct}%`;
                    detailToast.style.display = "flex";
                }
            } else {
                if (detailToast) detailToast.style.display = "none";
            }
        });
    });

    toastClose?.addEventListener("click", () => {
        if (detailToast) detailToast.style.display = "none";
        pills.forEach(p => p.classList.remove("is-active"));
    });

    toggleAllBtn?.addEventListener("click", () => {
        if (!layout) return;
        const isShowAll = layout.classList.toggle("show-all-pct");
        const toggleText = toggleAllBtn.querySelector(".pct-toggle-text");
        if (toggleText) {
            toggleText.textContent = isShowAll ? "Hide All %" : "Show All %";
        }
    });
}

/* --------------------------------------------------------------------------
   5. ENHANCED AI ASSISTANT SLIDE-OVER DRAWER (WITH TYPEWRITER STREAMING)
   -------------------------------------------------------------------------- */
function initAiDrawer() {
    const overlay = document.getElementById("ai-drawer-overlay");
    const closeBtn = document.getElementById("ai-drawer-close");
    const openBtns = document.querySelectorAll("[data-open-ai-drawer]");
    const inputForm = document.getElementById("ai-input-form");
    const textInput = document.getElementById("ai-user-query");
    const messagesBox = document.getElementById("ai-chat-messages");
    const promptChips = document.querySelectorAll(".prompt-chip");

    if (!overlay) return;

    function openDrawer() {
        overlay.classList.add("open");
        overlay.setAttribute("aria-hidden", "false");
        setTimeout(() => textInput?.focus(), 150);
    }

    function closeDrawer() {
        overlay.classList.remove("open");
        overlay.setAttribute("aria-hidden", "true");
    }

    openBtns.forEach(btn => btn.addEventListener("click", openDrawer));
    closeBtn?.addEventListener("click", closeDrawer);

    overlay.addEventListener("click", (e) => {
        if (e.target === overlay) closeDrawer();
    });

    window.addEventListener("keydown", (e) => {
        if (e.altKey && (e.key === "k" || e.key === "K")) {
            e.preventDefault();
            if (overlay.classList.contains("open")) {
                closeDrawer();
            } else {
                openDrawer();
            }
        } else if (e.key === "Escape" && overlay.classList.contains("open")) {
            closeDrawer();
        }
    });

    function respondToQuery(query) {
        if (!query.trim()) return;

        appendMessage(query, "user");

        // Typing indicator
        const typingDiv = document.createElement("div");
        typingDiv.className = "ai-msg ai-msg-bot ai-typing";
        typingDiv.innerHTML = `<div class="ai-bubble"><span class="typing-dot">●</span> <span class="typing-dot">●</span> <span class="typing-dot">●</span></div>`;
        messagesBox.appendChild(typingDiv);
        messagesBox.scrollTop = messagesBox.scrollHeight;

        setTimeout(() => {
            typingDiv.remove();

            const q = query.toLowerCase();
            let reply = "";

            if (q.includes("power") || q.includes("platform") || q.includes("automate") || q.includes("sharepoint") || q.includes("dataverse")) {
                reply = "Seth has advanced hands-on expertise in Microsoft Power Platform:\n\n" +
                    "• Power Apps (9/10): Custom Canvas and Model-driven apps with responsive multi-screen UX.\n" +
                    "• Power Automate (9/10): Multi-tier automated approval workflows, notification pipelines, and scheduled syncs.\n" +
                    "• SharePoint (9/10): Enterprise list architecture, document libraries, and permission schemas.\n" +
                    "• Dataverse (7/10): Relational tables, business rules, and secure data modeling.\n\n" +
                    "Key Solution: Built an enterprise Activity Proposal System automating organizational budget approvals and financial compliance.";
            } else if (q.includes("rating") || q.includes("percent") || q.includes("level") || q.includes("expertise")) {
                reply = "Seth's technical proficiency levels (out of 10):\n\n" +
                    "• 9/10 (Advanced / Expert): Power Apps, Power Automate, SharePoint, HTML5, CSS3, AI & Agent-Assisted Dev, VS Code\n" +
                    "• 8/10 (Proficient): React, TypeScript, Tailwind CSS, Laravel, MySQL, Python, Microsoft 365, Git & GitHub, Postman\n" +
                    "• 7/10 (Skilled): C#, .NET / ASP.NET Core, PHP, Node.js, Dataverse, Docker & Cloud";
            } else if (q.includes("project") || q.includes("work") || q.includes("built") || q.includes("portfolio")) {
                reply = "Seth's featured projects include:\n\n" +
                    "1. Library Management System: Academic web platform with responsive catalog search, borrowing tracking, and real-time inventory.\n" +
                    "2. Hotel Booking System: Full-stack reservation engine in PHP/Laravel & MySQL with room tiers, guest billing, and staff schedules.\n" +
                    "3. Activity Proposal System: Microsoft Power Platform solution automating multi-tier approval workflows and budget audits.\n" +
                    "4. REACH System: Emergency disaster response platform coordinating automated SMS broadcasts and aid verification.";
            } else if (q.includes("contact") || q.includes("hire") || q.includes("email") || q.includes("schedule") || q.includes("availab")) {
                reply = "Seth is actively available for Internship and Junior Software Developer roles!\n\n" +
                    "• Location: Cebu, Philippines (Open to On-site, Hybrid, or Remote)\n" +
                    "• Email: sethandreyabrasado@gmail.com\n" +
                    "• Turnaround: Typically responds in under 24 hours\n" +
                    "• Teams: Direct chat link is available in the contact section or sidebar!";
            } else if (q.includes("education") || q.includes("school") || q.includes("scholar") || q.includes("university")) {
                reply = "Seth's academic background:\n\n" +
                    "• Associate in Computer Technology (2024–2026) at University of San Jose – Recoletos (USJ-R).\n" +
                    "• Technology Scholar at Passerelles Numériques Philippines (Class of 2026).\n" +
                    "• Senior High School Graduate from Mantalongon NHS, Dalaguete, Cebu.";
            } else if (q.includes("cert") || q.includes("google") || q.includes("training")) {
                reply = "Seth holds verified training and certificates from Google & Coursera:\n\n" +
                    "• Google Data Analytics Specialization\n" +
                    "• Using Python to Interact with the Operating System (Google)\n" +
                    "• Google UI/UX Design Fundamentals\n" +
                    "• Crash Course on Python (Google)";
            } else {
                reply = "Hi! I am Seth's AI portfolio assistant. Seth is a Junior Software Developer based in Cebu, Philippines, specializing in Microsoft Power Platform (Power Apps, Power Automate, SharePoint) and full-stack web applications (C# / .NET, PHP / Laravel, React).\n\nFeel free to ask about his specific skill ratings, deployed projects, education, or how to contact him for an interview!";
            }

            streamBotMessage(reply);
        }, 350);
    }

    function appendMessage(text, sender) {
        const msgDiv = document.createElement("div");
        msgDiv.className = `ai-msg ai-msg-${sender}`;
        const bubble = document.createElement("div");
        bubble.className = "ai-bubble";
        bubble.textContent = text;
        msgDiv.appendChild(bubble);
        messagesBox.appendChild(msgDiv);
        messagesBox.scrollTop = messagesBox.scrollHeight;
    }

    function streamBotMessage(fullText) {
        const msgDiv = document.createElement("div");
        msgDiv.className = "ai-msg ai-msg-bot";
        const bubble = document.createElement("div");
        bubble.className = "ai-bubble";
        msgDiv.appendChild(bubble);
        messagesBox.appendChild(msgDiv);

        // Convert line breaks and basic formatting
        const lines = fullText.split("\n");
        let formattedHtml = lines.map(line => {
            if (line.startsWith("• ")) {
                return `<li>${escapeHtml(line.substring(2))}</li>`;
            } else if (/^\d+\.\s/.test(line)) {
                return `<li>${escapeHtml(line)}</li>`;
            } else if (line.trim() === "") {
                return "<br/>";
            } else {
                return `<p>${escapeHtml(line)}</p>`;
            }
        }).join("");

        bubble.innerHTML = formattedHtml;
        messagesBox.scrollTop = messagesBox.scrollHeight;
    }

    function escapeHtml(str) {
        const div = document.createElement("div");
        div.textContent = str;
        return div.innerHTML;
    }

    inputForm?.addEventListener("submit", (e) => {
        e.preventDefault();
        const q = textInput.value.trim();
        if (q) {
            respondToQuery(q);
            textInput.value = "";
        }
    });

    const widgetForm = document.getElementById("ai-widget-form");
    const widgetInput = document.getElementById("ai-widget-input");

    widgetForm?.addEventListener("submit", (e) => {
        e.preventDefault();
        const q = widgetInput.value.trim();
        if (q) {
            openDrawer();
            respondToQuery(q);
            widgetInput.value = "";
        }
    });

    promptChips.forEach(chip => {
        chip.addEventListener("click", () => {
            const prompt = chip.getAttribute("data-prompt");
            if (prompt) {
                openDrawer();
                respondToQuery(prompt);
            }
        });
    });
}

/* --------------------------------------------------------------------------
   5. MOBILE NAVIGATION DRAWER
   -------------------------------------------------------------------------- */
function initMobileNav() {
    const menuBtn = document.querySelector("[data-menu-button]");
    const menuDrawer = document.getElementById("mobile-nav-drawer");
    if (!menuBtn || !menuDrawer) return;

    menuBtn.addEventListener("click", () => {
        const isOpen = menuDrawer.classList.toggle("open");
        menuBtn.setAttribute("aria-expanded", String(isOpen));
    });

    menuDrawer.querySelectorAll("a").forEach(link => {
        link.addEventListener("click", () => {
            menuDrawer.classList.remove("open");
            menuBtn.setAttribute("aria-expanded", "false");
        });
    });
}

/* --------------------------------------------------------------------------
   6. COPY EMAIL ADDRESS TO CLIPBOARD
   -------------------------------------------------------------------------- */
function initCopyEmail() {
    const copyBtn = document.getElementById("copy-email-btn");
    const indicator = document.getElementById("copy-status-indicator");
    if (!copyBtn) return;

    copyBtn.addEventListener("click", async () => {
        const email = "sethandreyabrasado@gmail.com";
        try {
            await navigator.clipboard.writeText(email);
            showCopiedFeedback();
        } catch (err) {
            // Fallback for older browsers
            const textarea = document.createElement("textarea");
            textarea.value = email;
            textarea.style.position = "fixed";
            textarea.style.opacity = "0";
            document.body.appendChild(textarea);
            textarea.select();
            document.execCommand("copy");
            document.body.removeChild(textarea);
            showCopiedFeedback();
        }
    });

    function showCopiedFeedback() {
        if (!indicator) return;
        indicator.textContent = "Copied!";
        indicator.classList.add("copied");
        setTimeout(() => {
            indicator.textContent = "Copy";
            indicator.classList.remove("copied");
        }, 2200);
    }
}

