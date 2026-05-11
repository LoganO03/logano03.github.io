//Anime Fact API
$(document).ready(function() {
    $('.getFact').click(function() {
        $.ajax({
            url: 'https://anime-facts-rest-api.herokuapp.com/api/v1/fma_brotherhood',
            type: 'GET',
            dataType: 'json',
            success: function(results){
                $('.fact').text(results.data[0].fact);
            },
            error: function(xhr,status,error){
                console.log(error);
                $('.fact').text('Could not load anime fact.');
            }
        });
    });
});