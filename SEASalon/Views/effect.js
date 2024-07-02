var prevScrollPos = window.pageYOffset;
var navbar = document.querySelector('.navbar');

window.addEventListener('scroll', function () {
    var currentScrollPos = window.pageYOffset;

    if (prevScrollPos > currentScrollPos) {
        navbar.classList.remove('hidden');

    } else {
        navbar.classList.add('hidden');
    }

    prevScrollPos = currentScrollPos;
});

const slides = document.querySelectorAll('.banner-slide');
let currentSlide = 0;
function showSlide(slideIndex) {
    slides.forEach((slide) => {
        slide.classList.remove('active');
    });

    slides[slideIndex].classList.add('active');
}

function nextSlide() {
    currentSlide++;
    if (currentSlide >= slides.length) {
        currentSlide = 0;
    }
    showSlide(currentSlide);
}

setInterval(nextSlide, 3000);


function scrollToBriefInfo() {
    var briefInfo = document.querySelector('.briefInfo');
    var scrollTo = briefInfo.offsetTop;

    function scrollStep() {
        if (window.pageYOffset < scrollTo) {
            window.scroll(0, window.pageYOffset + 30);
            requestAnimationFrame(scrollStep);
        }
    }

    scrollStep();
}



let clickCount = 0;
window.onload = function () {
    var burger = document.getElementById('burger');
    var nav = document.getElementById('nav-links');
    let countnav = navbar.style.height;

    burger.addEventListener('click', function () {
        clickCount++;

        if (clickCount % 2 !== 0) {
            nav.style.display = 'flex';
            nav.style.flexDirection = 'column';
            nav.style.position = 'absolute';
            nav.style.left = '50%';
            nav.style.top = '50%';
            nav.style.transform = 'translate(-50%, -50%)';
            navbar.style.height = '36%';
            burger.style.marginRight = '0px';
        } else {
            nav.style.display = 'none';
            burger.style.marginRight = '0';
            navbar.style.height = countnav;

        }
    });
}

    