$(document).ready(function () {
    
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

    //var url = window.location.pathname,
    //    urlRegExp = new RegExp(url.replace(/\/$/, '') + "$"); // create regexp to match current url pathname and remove trailing slash if present as it could collide with the link in navigation in case trailing slash wasn't present there
    //// now grab every link from the navigation
    //$('.ulMenu div a').each(function () {
    //    // and test its normalized href against the url pathname regexp
    //    if (urlRegExp.test(this.href.replace(/\/$/, ''))) {
    //        $(this).addClass('lf-Menu-cust-active');
    //    }
    //});

    //$("div.leftmenu a").click(function (e) {
    //    e.preventDefaul(); // prevent default link button redirect behaviour
    //    var url = $(this).attr("href");
    //    $('#page-content').load(url);
    //});

    window.fnLeftMenu = function (e) {
        var id = e.id;
        var oUrl = "/Home/About?" + id;
        if (id == 'today')
            oUrl = "/Home/today";
        else if (id == 'customer')
            oUrl = "/Customer/Index";
        else if (id == 'customernew')
            oUrl = "/Customer/Create";

        $(".ulMenu div a").removeClass("lf-Menu-cust-active"); //Remove any "active" class  
        $('#'+id).addClass("lf-Menu-cust-active"); //Add "active" class to selected tab  

        $.ajax({
            type: "GET",
            url: oUrl,
            success: function (data, textStatus, jqXHR) {
                $('#page_content').html(data);
            }
        });
    };
    
    $('#CollapseMe1').click(function () {
        $(this).hasClass('glyphicon-triangle-right') ? $(this).removeClass('glyphicon-triangle-right') && $(this).addClass('glyphicon-triangle-bottom') : $(this).removeClass('glyphicon-triangle-bottom') && $(this).addClass('glyphicon-triangle-right');
    });
    $('#CollapseMe2').click(function () {
        $(this).hasClass('glyphicon-triangle-right') ? $(this).removeClass('glyphicon-triangle-right') && $(this).addClass('glyphicon-triangle-bottom') : $(this).removeClass('glyphicon-triangle-bottom') && $(this).addClass('glyphicon-triangle-right');
    });
    $('#CollapseMe3').click(function () {
        $(this).hasClass('glyphicon-triangle-right') ? $(this).removeClass('glyphicon-triangle-right') && $(this).addClass('glyphicon-triangle-bottom') : $(this).removeClass('glyphicon-triangle-bottom') && $(this).addClass('glyphicon-triangle-right');
    });
    $('#CollapseMe4').click(function () {
        $(this).hasClass('glyphicon-triangle-right') ? $(this).removeClass('glyphicon-triangle-right') && $(this).addClass('glyphicon-triangle-bottom') : $(this).removeClass('glyphicon-triangle-bottom') && $(this).addClass('glyphicon-triangle-right');
    });

    ///Multi Tab selction
    $(document).ready(function () {
        $('a[data-toggle="tab"]').on('shown.bs.tab', function (e) {

            var href = $(e.target).attr('href');
            var $curr = $(".checkout-bar  a[href='" + href + "']").parent();

            $('.checkout-bar li').removeClass();

            $curr.addClass("active");
            $curr.prevAll().addClass("visited");


        });
    });
});