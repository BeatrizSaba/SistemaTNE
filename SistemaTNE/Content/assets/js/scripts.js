
jQuery(document).ready(function() {
	
    /*
        Fullscreen background
    */
    $.backstretch([
                    "../Content/assets/img/backgrounds/2.jpg"
	              , "../Content/assets/img/backgrounds/3.jpg"
	              , "../Content/assets/img/backgrounds/1.jpg"
	             ], {duration: 3000, fade: 750});
    
    /*
        Form validation
    */
    $('.login-form input[type="text"], .login-form input[type="password"], .login-form textarea').on('focus', function() {
    	$(this).removeClass('input-error');
    });
   
    $('.login-form').on('submit', function(e) {
        
    	$(this).find('input[type="text"], input[type="password"], textarea').each(function(){
    		if( $(this).val() == "" ) {
    			e.preventDefault();
    			$(this).addClass('input-error');
    		}
    		else {

    		    $(this).removeClass('input-error');


                /*
    		    //PROTOTIPO CODE ---- -------------------------------------
    		    e.preventDefault();
    		    var user = $('input[type = "text"]').val();

    		    if (user === "Administrador")
    		        window.location.replace("../Administrador/Index");
    		    else if (user === "Gestor")
    		        window.location.replace("../Gestor/Visualizar");
    		    else
    		        $(this).addClass('input-error');
    		    //----------------------------------------------------------
                */
    		}
    	});      

    });
    
    
    
});
