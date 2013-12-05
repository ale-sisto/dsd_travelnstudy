// Reviewing functions for University and City pages
//########################################################################
function makeReviewSection() {
    BindRatyEvents();
}

function BindRatyEvents() {
    $('.star').raty({
        readOnly: true,
        score: function () {
            return $(this).attr('data-rating');
        }
    });

    $('#inputstars').raty({
        cancel: true,
        target: '#inputrating',
        targetKeep: true,
        targetType: 'number',
        score: function () {
            return $(this).attr('data-rating');
        }
    });
};

function RatingCheck(source, args) {
    var score = $('#inputrating').attr('value');
    if (score > 0) {
        args.IsValid = true;
        return;
    }
    args.IsValid = false;
}

function ConfirmReviewDeletion(context) {
    var r = confirm('Are you sure you want to delete this review ?');
    if (r==true)
    {
        $(context).closest('.controls').hide()
    }
    return r;
}

function ValidateReview(context) {

    if (Page_ClientValidate())
    {
        $(context).closest('.controls').hide();
        return true;
    }
    return false;
}

//Re-bind for callbacks
var prm = Sys.WebForms.PageRequestManager.getInstance();

prm.add_endRequest(function () {
    BindRatyEvents();
});