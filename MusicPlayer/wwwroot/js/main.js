var song;
var tracker = $('.tracker');
var volume = $('.volume');
initAudio($('.playlist li:first-child'));
song.volume = 0.8;

tracker.slider({
    range: 'min',
    min: 0, max: 10,
    start: function (event, ui) { },
    slide: function (event, ui) {
        song.currentTime = ui.value;
    },
    stop: function (event, ui) { }
});

volume.slider({
    range: 'min',
    min: 0,
    max: 100,
    value: 100,
    start: function (event, ui) { },
    slide: function (event, ui) {
        song.volume = ui.value / 100;
    },
    stop: function (event, ui) { },
});

function initAudio(elem) {
    var url = elem.attr('audiourl');
    var title = elem.text();
    var cover = elem.attr('cover');
    var artist = elem.attr('artist');
    $('.player .title').text(title);
    $('.player .artist').text(artist);
    $('.player .cover-art').css('background-image', 'url(' + cover + ')');;

    song = new Audio('data/' + url);
     //timeupdate event listener
    song.addEventListener('timeupdate', function () {
        var curtime = parseInt(song.currentTime, 10);
        tracker.slider('value', curtime);
    });
    $('.playlist li').removeClass('active');
    elem.addClass('active');
}

function playAudio() {

    song.play();
    tracker.slider("option", "max", song.duration);

    $('.play').hide();
    $('.pause').show();
}
function stopAudio() {
    song.pause();
    $('.play').show();
    $('.pause').hide();
}

//play click evnt
$('.play').click(function (e) {
    e.preventDefault();
    playAudio();
});
// pause click evnt
$('.pause').click(function (e) {
    e.preventDefault();
    stopAudio();
});

// forward click evnt
$('.fwd').click(function (e) {
    e.preventDefault();
    stopAudio();
    var next = $('.playlist li.active').next();
    if (next.length == 0) {
        next = $('.playlist li:first-child');
    }
    initAudio(next);
    setTimeout(function () { playAudio(); }, 500);

});
// rewind click event
$('.rew').click(function (e) {
    e.preventDefault();
    stopAudio();
    var prev = $('.playlist li.active').prev();
    if (prev.length == 0) {
        prev = $('.playlist div:last-child');
    }
    initAudio(prev);
    setTimeout(function () { playAudio(); }, 500);

});

// playlist list - click
$('.playlist li').click(function () {
    stopAudio();
    initAudio($(this));
    setTimeout(function () { playAudio(); }, 500);

});