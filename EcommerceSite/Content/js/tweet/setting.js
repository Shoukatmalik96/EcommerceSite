/* twitter settings */
$(document).ready(function(){
    $(".tweet_list").tweet({
        join_text: "auto",
        username: "envatowebdesign",
        count: 1,
        auto_join_text_default: "we said,",
        auto_join_text_ed: "we",
        auto_join_text_ing: "we were",
        auto_join_text_reply: "we replied",
        auto_join_text_url: "we were checking out",
        loading_text: "loading tweets..."
	});
});