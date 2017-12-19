function stageSet(stage) {
  
    $('#jggkb').find('label[data-show]').each(function () { 
        $(this).parent().hide();
        if ($(this).data('show') == stage) {
            $(this).parent().show();
        }

    });
    //$('.rc0').hide();
    //$('.rc1').hide();
    //$('.rc2').hide();
    //$('.rc3').hide();

    //if (stage == "第1阶段") {
    //    $('#lab').html("第一阶段单品：")
    //    $('.rc0').show();
    //    $('.rc1').show();
    //} else if (stage == "第2阶段") {
    //    $('#lab').html("第二阶段单品：")
    //    $('.rc1').show();
    //    $('.rc2').show();
    //} else if (stage == "第3阶段") {
    //    $('#lab').html("第三阶段单品：")
    //    $('.rc1').show();
    //    $('.rc2').show();
    //    $('.rc3').show();
    //}
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
