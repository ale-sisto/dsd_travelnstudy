var opened = -1;

$(window).load(function () {

    open(0);

    $('a[data-toggle="tab"]').on('shown', function (e) {
        tabClosed();
        switch (e.target.text) {
            case 'University Life':
                places_init('univ');
                open(4);
                break;
            case 'Details and Contacts':
                open(1);
                break;
            case 'Costs and Admissions':
                tabOpened();
                charts_show();
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