(function ($) {

    var IndexPage = function () {

        var that = this;

        this.$htmlEditor = undefined;
        this.$saveButton = undefined;
        //this.$loadedText = undefined;

        this.initialize = function () {
            this.$htmlEditor = $('#some-textarea');
            this.$saveButton = $("#save-button");
            //this.$loadedText = $("articleContent");
            

            this.$saveButton.on("click", this.onSaveButton);
            
        };

        this.loadFormattedText = function () {
            var articleId = this.$htmlEditor.data('id');
            var xhr = $.ajax({
                url: "/Home/LoadFormattedText",
                dataType: "json",
                type: "POST",
                data: {
                id: articleId
                }
            });

            xhr.done(function (data) {
                var decodedText = decodeURIComponent(data.formattedText);
                var finalText = decodedText.split('+').join(' ');

                CKEDITOR.instances['some-textarea'].setData(finalText);
                
                
            });
        };

        this.onSaveButton = function () {
            var formattedText = CKEDITOR.instances['some-textarea'].getData();
            
            var articleId = $(this).data('id');
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
        page.loadFormattedText();
        
    });

})(jQuery);