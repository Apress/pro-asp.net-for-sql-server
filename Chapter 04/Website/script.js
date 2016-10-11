
function showViewStateLength() {
    var vs = document.getElementById('__VIEWSTATE');
    var ph = document.getElementById('ViewStatePlaceHolder');
    if (vs.value.length > 0)
    {
        ph.innerHTML = 'ViewState Length: ' + (vs.value.length/1024).toPrecision(4) + ' KB';
    }
    else
    {
        ph.innerHTML = 'ViewState Length: 0 KB';
    }
}
