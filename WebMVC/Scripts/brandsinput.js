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

    stageold = $("#Stage").val();
    stageSet($("#Stage").val());
    $("#investSum").html(sum($("#invest input")));
    $("#Stage").change(function () {
        //从后台获取阶段进行判断
        var stagenew = $(this).val();
        $.get("/BrandsInput/getstageStatus?stage=" + stagenew + "&brand=" + $('#Brand').val() + "&brandId=" + $('#BrandID').val(), function (data) {
            if (data == "ok") {
                stageSet(stagenew);
            } else {
                alert(stagenew + "已存在，请重新选择");
                $("#Stage").val(stageold);
            }
        });


    })
 

    $("#jggkb input").bind("input property change", function () {
        var inputs = $("#jggkb input");

        $("#investSum").html(sum(inputs));

    })
    $("#jggkb1 input").bind("input property change", function () {
        var inputs = $("#jggkb1 input");

        $("#investSum1").html(sum(inputs));

    })
})
