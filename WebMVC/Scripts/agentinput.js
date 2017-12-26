function stageSet(stage) {



    $('#jggkb').find('label[data-show]').each(function () {

        $(this).next().children().attr("disabled", "disabled");
        $(this).parent().hide();
        if ($(this).data('show') == stage) {
            $(this).parent().show()
            $(this).next().children().removeAttr("disabled");
        }

    });
    $('#jhb').find('label[data-show]').each(function () {

        $(this).next().children().attr("disabled", "disabled");
        $(this).parent().hide();
        if ($(this).data('show') == stage) {
            $(this).parent().show();
            $(this).next().children().removeAttr("disabled");
        }

    });
    //$('#jggkb').find('label[data-show]').each(function () { 
    //    $(this).parent().hide();
    //    if ($(this).data('show') == stage) {
    //        $(this).parent().show();
    //    }

    //});
    //$('#jhb').find('label[data-show]').each(function () {
    //    $(this).parent().hide();
    //    if ($(this).data('show') == stage) {
    //        $(this).parent().show();
    //    }

    //});
   
}
function sum(inputs) {
    var sum = 0;
    $(inputs).each(function () {
        var v = $(this).val();
        sum += parseFloat(v);
    });
    return sum;
}

$(function () {
    stageSet($("#Stage").val());
    $("#investSum").html(sum($("#invest input")));
    $("#Stage").change(function () {
        stageSet($(this).val());
    })

    $("#invest input").bind("input property change", function () {
        var inputs = $("#invest input");

        $("#investSum").html(sum(inputs));

    })
})
