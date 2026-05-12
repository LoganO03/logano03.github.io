//Random Fact API
$(document).ready(function() {

    $('#fact-button').click(function (){
        getFact();
    });
    $('#coffee-button').click(function() {
        getCoffee();
    });



    function getFact(){
        $.ajax({
            url: 'https://uselessfacts.jsph.pl/api/v2/facts/random',
            type: 'GET',
            dataType: 'json',
            success: function(results){
                $('.fact').text(results.text);
            },
            error: function(xhr,status,error){
                console.log(error);
                $('.fact').text('Could not load a random fact.');
            }
        });
    }

    function getCoffee() {
        var timestamp = new Date().getTime(); // prevents browser caching the same image
        $('.coffee-img')
            .attr('src', 'https://coffee.alexflipnote.dev/random?' + timestamp)
            .show();
    }
        
});
