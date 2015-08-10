var main = function () {
    $('.dropdown-toggle').click(function () {
        $('.dropdown-menu').toggle();
    });
    
    $('#agree').change(function () {
        if (this.checked) {    		
            document.getElementById("signup").removeAttribute("disabled");
        }
        else {
            document.getElementById("signup").setAttribute('disabled','disabled');
        }        
    });
}

$(document).ready(main);