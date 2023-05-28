// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
{
	var buttons = document.querySelectorAll('#MyButton');

	buttons.forEach(function (button) {
		button.addEventListener('click', function () {
			alert("Product/s added!");
		});
	});
}
{
	var buttons = document.querySelectorAll('#MyButtonUpdate');

	buttons.forEach(function (button) {
		button.addEventListener('click', function () {
			alert("Quantity updated!");
		});
	});
}