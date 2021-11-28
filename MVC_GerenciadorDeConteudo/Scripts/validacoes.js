var ValidaExclusao = function (id, evento) {
    if (confirm("Confirma exclusão?")) {
        return true;
    } else {
        event.preventDefault();
        return false;
    }
}
