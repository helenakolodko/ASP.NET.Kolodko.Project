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
	
	$('#load').click(function () {
        $('.topics > tbody:last-child').append(
			'<tr>'+
				'<td><a href=\"#\">What else is there?</a></td>'+
				'<td><a href=\"#\">Jack</a></td>'+
				'<td>11:11 11-11-11<\/td>'+
				'<td><a href=\"#\">Music</a></td>'+
				'<td><span class=\"glyphicon glyphicon-chevron-up\" aria-hidden=\"true\"></span> 11</td>'+
				'<td><span class=\"glyphicon glyphicon-chevron-down\" aria-hidden=\"true\"></span> 1</td>'+
				'<td><span class=\"glyphicon glyphicon-comment\" aria-hidden=\"true\"></span> 5</td>'+
			'</tr>');
    });
	
	$('#add').click(function () {
        $('<div class="container content">'+
				'<div class=\"row-fluid comment-header\">'+
					'<div class=\"pull-left\">11:11 11-11-11<\/div>'+
					'<div class=\"pull-right\">'+
						'<a href=\"#\"><span class=\"glyphicon glyphicon-chevron-up\" aria-hidden=\"true\"></span><\/a> 0 '+
						'<a href=\"#\"><span class=\"glyphicon glyphicon-chevron-down\" aria-hidden=\"true\"></span><\/a> 0'+
					'<\/div>'+
				'<\/div>'+
				'<div class=\"col-md-2 comment-body\">'+		
					'<div class=\"well\">'+
					'<img src=\"images\/foto.jpg\" alt=\"Foto\" class=\"img-rounded avatar-sm\"><br>'+
					'<a href=\"#\">Jack<\/a><br>'+
					'Role: User<br>'+
					'Topics: <a href=\"#\">13<\/a><br>'+
					'Sex: Male'+
					'<\/div>'+
				'<\/div>'+
				'<div class=\"col-md-10 comment-body\">'+
					'<div class=\"well\">'+
						'The C# specification states that the runtime is permitted broad latitude to detect when storage containing a reference is never going to be accessed again, and to stop treating that storage as a root of the garbage collector. For example, suppose we have a local variable foo and a reference is written into it at the top of the block. If the jitter knows that a particular read is the last read of that variable, the variable can legally be removed from the set of GC roots immediately; it doesn’t have to wait until control leaves the scope of the variable. If that variable contained the last reference then the GC can detect that the object is unreachable and put it on the finalizer queue immediately. Use GC.KeepAlive to avoid this.'+
					'<\/div>'+
					'<div class=\"pull-right\"><a href=\"#\">Answer<\/a><\/div>'+
				'<\/div>'+
			'<\/div>').insertBefore('#comment-form');
    });
	
	$(".logo").hover(function(){
		$(this).attr("src", "/Content/images/" + $(this).attr("alt") + "-icon.png");
		}, function(){
		$(this).attr("src", "/Content/images/" + $(this).attr("alt") + "-grey-icon.png");
		
});
}

	$(function () {
	  $('[data-toggle="popover"]').popover()
	})

$(document).ready(main);
