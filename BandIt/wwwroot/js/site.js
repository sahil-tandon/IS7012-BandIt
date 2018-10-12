// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your Javascript code.

$(document).ready(function(){
    $(window).scroll(function(){
        if($(this).scrollTop()>90){
            $('.header,body').addClass("collapsed");
        }
        else{
            $('.header,body').removeClass("collapsed");
        }
    });
})