
function showViewStateLength() {
    var vs = document.getElementById('__VIEWSTATE');
    var ph = document.getElementById('ViewStatePlaceHolder');
    ph.innerHTML = 'ViewState Length: ' + vs.value.length;
}
