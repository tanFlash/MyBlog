(function ($) {

    var IndexPage = function () {

        var that = this;

        
        this.$commentButton = undefined;
        this.$text = undefined;

        this.initialize = function () {
           
            this.$commentButton = $("#comment-button");
            this.$text = $("#comments-area");


            this.$commentButton.on("click", this.onleaveCommentButton);

        };

        
        this.onleaveCommentButton = function () {
            var formattedText = that.$text.val();
            console.log("saveButton_Click", formattedText);
            var articleId = $(this).data('id');
            var xhr = $.ajax({
                url: "/Comments/LeaveCommment",
                dataType: "json",
                type: "POST",
                data: {
                    id: articleId,
                    formattedText: escape(formattedText)
                }
            });

           
            xhr.done(function (data) {
                console.log("saveButton_Click - done", arguments);
                window.location.href = data.url;
            });
        };
        
    };
    $(function () {
        var page = new IndexPage();
        page.initialize();
       

    });

})(jQuery);