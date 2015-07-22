(function ($) {

    var IndexPage = function () {

        var that = this;

        this.$loadedText = undefined;

        this.initialize = function () {
            this.$loadedText = $("#articleContent");
        };

        this.loadFormattedText = function () {

            var articleId = this.$loadedText.data('id');
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
              
                that.$loadedText.append(finalText);
            });
        };

    };

    $(function () {
        var page = new IndexPage();
        page.initialize();
        page.loadFormattedText();
    });


})(jQuery);