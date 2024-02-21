// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.




//style boxes - Bootstrap Alerts////////////////////////////////////////////////////////////////////////////////////////

//função para tranformar text em html-----------------
$.fn.toHtml = function () {
	return $(this).html($(this).html())
}

//variaveis globais------------------------------------

//alertDanger
var alertDanger       = "<div class='alert alert-dismissible alert-danger' id='#alertMsg#'></div>";
var alertDangerIcon   = "<i class='bi-exclamation-diamond-fill'></i>";
var alertDangerMsg    = "<strong>Erro!</strong> #messages#";
var alertDangerButton = "<button type='button' class='btn-close btn-sm' data-bs-dismiss='alert' aria-hidden='true'></button>";

//função para pegar a msg do tipo correspondente---------
function getAlertType(type) {
	if (type =="alertDanger") {
		return alertDangerMsg;
    }
}

//função para criar style boxes
/* parametros
id:  id da div
msg: menssagem do style boxes
alertType: tipo do style boxes
*/
function createAlertBoxe(id, msg, alertType) {

	//criando a div do style boxes
	var idValidation = id + "-validation";
	var newAlertDanger = alertDanger.replace("#alertMsg#", idValidation);	
	$("#" + id).append(newAlertDanger);
	
	//criando o icone
	var newAlertIcon = alertDangerIcon;
	$("#" + idValidation).append(newAlertIcon);	
	
	//criando a msg
	var newAlertMsg = getAlertType(alertType).replace("#messages#", msg);
	$("#" + idValidation).append(newAlertMsg);
	
	//criando o botão
	var newAlertButton = alertDangerButton;
	$("#" + idValidation).append(newAlertButton);
	
	//transformando em html
	$("#" + id).toHtml();
	
}
/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
