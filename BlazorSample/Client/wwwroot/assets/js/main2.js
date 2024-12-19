function renderjQueryComponents() {

    $('.mobile-nav-toggle').click(function () {
        $('body').toggleClass('mobile-nav-active');
        $(this).toggleClass('bi-list');
        $(this).toggleClass('bi-x');
    })

    $('.scrollto').click(function () {
        $('.scrollto').removeClass('active');
        if ($('body').hasClass('mobile-nav-active')) {
            $('body').toggleClass('mobile-nav-active');
            $('.mobile-nav-toggle').toggleClass('bi-list');
            $('.mobile-nav-toggle').toggleClass('bi-x');
        }
    })
    
}

function Color() {
	var colorSelect = document.getElementById("colorSelect");
        if (colorSelect.value == '赤'){
            colorSelect.style.color = '#ff0000';
    }
        else if (colorSelect.value == '青'){
            colorSelect.style.color = '#0000ff';
    }
        else if (colorSelect.value == '黄'){
            colorSelect.style.color = '#ffff00';
    }
        else{
            colorSelect.style.color = '';
	}
}