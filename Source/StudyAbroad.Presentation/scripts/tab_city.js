var opened = -1;

$(window).load(function () {

    open(0);
    $('a[data-toggle="tab"]').on('shown', function (e) {
        climateClosed();
        switch (e.target.text) {
            case 'City Life':
                open(4);
                places_init('city');
                break;
            case 'Climate':
                open(5);
                climateOpened();
                climate_draw();
                break;
            case 'General':
                open(1);
                break;
            case 'Costs':
                open(2);
                break;
            case 'Reviews':
                open(3);
                break;
            case 'Introduction':
                open(0);
                break;
        }
    });

});


function open(id) {
    if (opened != -1) {
       // document.getElementById('btn_tab' + opened).style.marginLeft = '-60px';
        $('#btn_tab' + opened).addClass("btn-primary");
        $('#btn_tab' + opened).removeClass("btn-inverse");
    }

    opened = id;
    //document.getElementById('btn_tab' + id).style.marginLeft = '-30px';
    $('#btn_tab' + id).removeClass("btn-primary");
    $('#btn_tab' + id).addClass("btn-inverse");

    //How to change the color??? color is text, backgroundcolor does nothing...
    //document.getElementById('btn_tab' + id).style.color = '033C73';
}