function DropdownList() {
	var autor = document.getElementById("lblAutores").value;
	window.location.href = '/Libro/BusquedaAutor?autor=' + autor;
}
function Titulo() {
	var titulo = document.getElementById("txttitulo").value;
	window.location.href = '/Libro/BusquedaTitulo?titulo=' + titulo;
}