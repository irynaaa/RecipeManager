
//var path_to_delete;

//$(".deleteItem").click(function(e) {
//    path_to_delete = $(this).data('path');
//});
//$('#btnContinueDelete').click(function () {
//    window.location = path_to_delete;
//});


(function () {

    $(function () {
        var RecipeManager = {};
        RecipeManager.AjaxDelete = function () {
            var form = $("#form_delete");
            $.ajax({
                url: "/Recipe/DeletePopup",
                type: "POST",
                data: form.serialize(),
                success: function (data) {
                    alert(data.rez + " " + data.message);
                }
            });
            console.log("RecipeManager.AjaxDelete");
        }
        var aMgr = RecipeManager;
        $("#btnDeletePopup").on("click", function () {
            console.log("btnDeletePopup pressed");
            aMgr.AjaxDelete();
        });
    });
})();