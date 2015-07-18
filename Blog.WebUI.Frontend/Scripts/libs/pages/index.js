(function ($) {

    var IndexPage = function () {

        var that = this;

        this.$htmlEditor = undefined;
        this.$saveButton = undefined;

        this.initialize = function () {
            this.$htmlEditor = $('#some-textarea');
            this.$saveButton = $("#save-button");

            //this.$htmlEditor.CKEDITOR.

            this.$saveButton.on("click", this.onSaveButton);
            //var data = CKEDITOR.instances.editor1.getData();
        };

        this.onSaveButton = function () {
            var formattedText = CKEDITOR.instances['some-textarea'].getData();
            var articleId = $(this).data('article-id');
            var xhr = $.ajax({
                url: "/Home/SaveFormattedText",
                dataType: "json",
                type: "POST",
                data: {
                    id:articleId,
                    formattedText: escape(formattedText)
                }
            });

            xhr.done(function (data) {
                console.log("saveButton_Click - done", arguments);
            });
        };

    };
    $(function () {
        var page = new IndexPage();
        page.initialize();
        
    });

})(jQuery);