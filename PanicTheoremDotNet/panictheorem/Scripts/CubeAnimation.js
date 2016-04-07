var logoImg = new Image();
var logoX = 0;
var logoY = 200;
var cycleEnd = 31;
var x = 200;
var animEnd;

function beginAnimation() {
    logoImg.src = 'http://www.panictheorem.net/Images/PanicCubePurple.png';
    endAnim = setInterval(drawFrame, 16);
}

function endAnimation() {
    clearTimeout(animEnd);
}

function drawFrame() {
    //update logo coordinates
    if (x < cycleEnd) {
        x += Math.PI / 8;
    } else {
        x = 0;
    }
    logoY = 20 * Math.sin(0.2 * x) + 30;
    //draw logo at new location
    var canvas = document.getElementById('logoBounce');
    var context = canvas.getContext('2d');
    context.clearRect(0, 0, canvas.width, canvas.height);
    context.drawImage(logoImg, logoX, logoY, 280, 280);
}
beginAnimation();