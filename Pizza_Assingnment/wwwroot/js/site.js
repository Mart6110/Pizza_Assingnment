// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

function searchFunction() {
    const trs = document.querySelectorAll('#table tr:not(.header)')
    const filter = document.querySelector('#searchInput').value
    const regex = new RegExp(filter, 'i')
    const isFoundInTds = td => regex.test(td.innerHTML)
    const isFound = childrenArr => childrenArr.some(isFoundInTds)
    const setTrStyleDisplay = ({ style, children }) => {
        style.display = isFound([
            ...children // <-- All columns
        ]) ? '' : 'none'
    }

    trs.forEach(setTrStyleDisplay)
}



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