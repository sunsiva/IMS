﻿$(document).ready(function () {
    
//    (function () {
//    var clock = document.querySelector('.loggedInTicker');
//    // But there is a little problem, we need to pad 0-9 with an extra 0 on the left for hours, seconds, minutes
//    var pad = function(x) {
//        return x < 10 ? '0'+x : x;
//    };
	
//    var ticktock = function() {
//        var d = new Date();
		
//        var h = pad( d.getHours() );
//        var m = pad( d.getMinutes() );
//        var s = pad( d.getSeconds() );
//        var current_time = [h,m,s].join(':');
//        clock.innerHTML = current_time;
//    };
//    ticktock();
//    // Calling ticktock() every 1 second
//    setInterval(ticktock, 1000);
//}());

    var url = window.location.pathname,
        urlRegExp = new RegExp(url.replace(/\/$/, '') + "$"); // create regexp to match current url pathname and remove trailing slash if present as it could collide with the link in navigation in case trailing slash wasn't present there
    // now grab every link from the navigation
    $('.ulMenu li a').each(function () {
        // and test its normalized href against the url pathname regexp
        if (urlRegExp.test(this.href.replace(/\/$/, ''))) {
            $(this).addClass('active');
        }
    });

    window.fnLeftMenu = function (e) {
        var id = e.id;
        var oUrl = "/Home/About?" + id;
        if (id == 'today')
            oUrl = "/Home/today?" + id;

        $(".ulMenu li a.active").removeClass("active"); //Remove any "active" class  
        $(this).addClass("active"); //Add "active" class to selected tab  

        $.ajax({
            type: "GET",
            url: oUrl,
            success: function (data, textStatus, jqXHR) {
                $('#mainBody').html(data);
            }
        });

    };
});