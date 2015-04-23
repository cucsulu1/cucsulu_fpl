$(function () {
    $(".choose-type select").each(function () {
        if ($(this).val() == 0) {
            $(this).removeClass("filter-select");
        } else {
            $(this).addClass("filter-select");
        }
    });

    $("#showPass").click(function() {
        $("#password").removeAttr('disabled');
        $("#password").show();
        $(this).hide();
    });

    $(".user-login").click(function() {
        $(".profile").toggle();
    });

    //$('.tags').tagsInput({ width: 'auto', height:'28px' });

    $(".chzn-select").chosen();
    $('#id-input-file-1 , #id-input-file-2').ace_file_input({
        no_file: 'No File ...',
        btn_choose: 'Choose',
        btn_change: 'Change',
        droppable: false,
        onchange: null,
        thumbnail: false //| true | large
        //whitelist:'gif|png|jpg|jpeg'
        //blacklist:'exe|php'
        //onchange:''
        //
    });
    var tag_input = $('#form-field-tags');
    if (!(/msie\s*(8|7|6)/.test(navigator.userAgent.toLowerCase())))
        tag_input.tag({ placeholder: tag_input.attr('placeholder') });
    else {
        //display a textarea for old IE, because it doesn't support this plugin or another one I tried!
        tag_input.after('<textarea id="' + tag_input.attr('id') + '" name="' + tag_input.attr('name') + '" rows="3">' + tag_input.val() + '</textarea>').remove();
        //$('#form-field-tags').autosize({append: "\n"});
    }

    $('#sample-table-2').dataTable({
        "aaSorting": [[0, "desc"]]
    });
    $('#tbl-sort-asc').dataTable({
        "aaSorting": [[0, "asc"]]
    });
    
    /*========= validate form plugin =========*/
    $("#validate").validate({
        rules: {
            name: "required",
            lastname: "required",
            username: "required",
            email: {
                required: true,
                email: true
            },
            sort: {
                number: true
            },
            password: {
                required: true,
                minlength: 5
            },
            confirm_password: {
                required: true,
                minlength: 5,
                equalTo: "#pass_con"
            },
            message: "required"
        }
    });

    $("#validateLogin").validate({
        rules: {
            username: "required",
            password: "required"
        }
    });
});

function typeidchange(typeid) {
    window.location = '?typeid=' + typeid;
}

function parentchange(parent) {
    window.location = '?parent=' + parent;
}

function grouppagechange(typeid) {
    window.location = '?groupid=' + typeid;
}
function PopupCenter(pageURL, w, h) {
    var left = (screen.width / 2) - (w / 2);
    var top = (screen.height / 2) - (h / 2) - 50;
    window.open(pageURL, 'popup', 'toolbar=no, location=no, directories=no, status=no, menubar=no, scrollbars=1, resizable=1, copyhistory=no, width=' + w + ', height=' + h + ', top=' + top + ', left=' + left);
}