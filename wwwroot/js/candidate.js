$(document).ready(function () {
    //$('#Birthday').datetimepicker({
    //    //inline: false
    //});
    $('#show-toast').on('click', function () {
        console.log(showMessage("cascasfcas"));
    });
    var messageCount = 0, max_message = 2
    function showMessage(text, type = "success", title = "Thông báo", icon = "glyphicon-ok", delay = 5000) {
        if (messageCount < max_message) {
            messageCount++;
        }
        else {
            messageCount = 1;
            $.pnotify_remove_all();
        }
        var notice = $.pnotify({
            pnotify_title: title,
            pnotify_text: text,
            type: type,
            icon: 'glyphicon ' + icon,
            addclass: 'snotify',
            sticker: false,
            pnotify_delay: delay,
        }).click(function (event) {
            notice.pnotify_remove();
        });
    }
});