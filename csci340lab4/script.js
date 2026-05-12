//Random Fact API
$(document).ready(function() {
    $('.getFact').click(function() {
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
    });
});