let popup = (() => {
    let redirection = document.getElementById('redirect');
    redirection.className += ' popup';
    redirection.innerHTML = 'Loading Telerik Academy JS Apps course program';
    redirection.style.display = 'none';

    function display() {
        redirection.style.display = '';
    }

    function fadeOut(time) {
        redirection.style.opacity = redirection.style.opacity || 1;
        let opacityDecreaseStep = 1 / time * 5;
        decreaseOpacity(opacityDecreaseStep);
    }

    function decreaseOpacity(step) {
        const callBack = () => {
            decreaseOpacity(step);
        };

        if (redirection.style.opacity <= 0) {
            return;
        }

        redirection.style.opacity -= step;
        setTimeout(callBack, 1);
    }

    return {
        display,
        fadeOut
    };
})();

const redirect = ((popup) => {
    const redirectPromise = new Promise((resolve, reject) => {
        popup.display();
        popup.fadeOut(10000);
        setTimeout(function () {
            resolve("https://telerikacademy.com/Courses/Courses/Details/350");
        }, 5000);
    })
        .then((newAddress) => window.location = newAddress);
})(popup);
