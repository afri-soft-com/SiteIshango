function myslide_next() {
    if ($('.myslide_next').length) {
        $('.myslide_next').owlCarousel({
            loop: true,
            margin: 30,
            items: 1,
            nav: false,
            autoplay: true,
            smartSpeed: 1800,
        })
    }
}
myslide_next();
