// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

// Function to search in table and filter table
function searchFunction() {
    const trs = document.querySelectorAll('#table tr:not(.header)') // Selecting all tr inside my table with an id table and the tr that does not have the class header
    const filter = document.querySelector('#searchInput').value // The input value, that is filter after
    const regex = new RegExp(filter, 'i') // regex that looks at the characters in the input value
    const isFoundInTds = td => regex.test(td.innerHTML) // Returns a boolean value that indicates whether or not a pattern exists in a searched string
    const isFound = childrenArr => childrenArr.some(isFoundInTds)

    // An Arrow function that display the row if one of the column has the value in it or display none if it does not have the value
    const setTrStyleDisplay = ({ style, children }) => {
        style.display = isFound([
            ...children // <-- All columns
        ]) ? '' : 'none'
    }

    // Runs a foreach for each tr in table
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

// Button click listener
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