// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

// Global variable
const slides = document.querySelectorAll(".slide");
const nextBtn = document.querySelector(".next-btn");
const prevBtn = document.querySelector(".prev-btn");

const auto = true;
const intervalTime = 5000;
let slidesInterval;

// Button click listener
nextBtn.addEventListener("click", (e) => {
    nextSlide();
    if (auto) {
        //reset slide interval
        clearInterval(slidesInterval);

        slidesInterval = setInterval(nextSlide, intervalTime);
    }
});

prevBtn.addEventListener("click", (e) => {
    prevSlide();
    if (auto) {
        //reset slide interval
        clearInterval(slidesInterval);

        slidesInterval = setInterval(nextSlide, intervalTime);
    }
});

// let's go create a nextSlide function
const nextSlide = () => {
    // Get current class
    const current = document.querySelector(".current");
    // remove current class
    current.classList.remove("current");
    // nextElementSibling for next slide
    if (current.nextElementSibling) {
        // jump current class in next div
        current.nextElementSibling.classList.add("current");
    } else {
        //reset slide
        slides[0].classList.add("current");
    }

    setTimeout(() => current.classList.remove("current"));
};

// let's go create a prevSlide function
const prevSlide = () => {
    // Get current class
    const current = document.querySelector(".current");
    // remove current class
    current.classList.remove("current");
    // previousElementSibling for prev slide
    if (current.previousElementSibling) {
        // jump current class in previous div
        current.previousElementSibling.classList.add("current");
    } else {
        //reset slide
        slides[slides.length - 1].classList.add("current");
    }

    setTimeout(() => current.classList.remove("current"));
};

// auto slide in interval time
if (auto) {
    slidesInterval = setInterval(nextSlide, intervalTime);
}

// Get the element with id="defaultOpen" and click on it
document.getElementById("defaultMenu").click();

// Menu Tabs
function openMenu(evt, MenuName) {
    var i, tabcontent, tablinks;
    tabcontent = document.getElementsByClassName("tabcontent");
    for (i = 0; i < tabcontent.length; i++) {
        tabcontent[i].style.display = "none";
    }
    tablinks = document.getElementsByClassName("tablinks");
    for (i = 0; i < tablinks.length; i++) {
        tablinks[i].className = tablinks[i].className.replace(" active", "");
    }
    document.getElementById(MenuName).style.display = "block";
    evt.currentTarget.className += " active";
}