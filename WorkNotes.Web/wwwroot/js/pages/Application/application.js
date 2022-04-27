function deleteConfirm(id, code) {
    confirmJs('Uygulama Siliniyor', code + ' isimli uygulama silinecek onaylıyor musunuz ?', function () {
        window.location.replace("/Application/Delete?id=" + id);
    });
}
