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
var stageold;
$(function () {
    stageold = $("#Stage").val();
    stageSet($("#Stage").val());
    $("#investSum").html(sum($("#invest input")));
    $("#Stage").change(function () {
        //从后台获取阶段进行判断
        var stagenew = $(this).val();
        $.get("/agentinput/getagentStatus?stage=" + stagenew + "&agent=" + $('#AgentName').val() + "&agentId=" + $('#AgentId').val(), function (data) {
            if (data == "ok") {
                stageSet(stagenew);
            } else {
                alert(stagenew + "已存在，请重新选择");
                $("#Stage").val(stageold);
            }
        });

   
    })

    $("#invest input").bind("input property change", function () {
        var inputs = $("#invest input");

        $("#investSum").html(sum(inputs));

    })
})
