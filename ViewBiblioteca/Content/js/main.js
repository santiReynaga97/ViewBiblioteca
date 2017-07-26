$(document).ready(function () {
  $('#idEnviar').click(function(){
      var nombre= $('#idNom').val();
      var descripcion=$('#idDes').val();

      if (nombre == ""){
        $('#mensaje1').fadeIn();
        return false;
      }
      else {
          $('#mensaje1').fadeOut();
          if (descripcion == "") {
              $('#mensaje2').fadeIn();
              return false;
          }
          else {
              $('#mensaje2').fadeOut();
          }
      }
  });
  
});