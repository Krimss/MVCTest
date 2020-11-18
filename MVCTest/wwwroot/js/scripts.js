$(document).ready(() => {
    let edit = $('.edit');
    //let e = document.createElement('input');
    //e.type = 'text';
    //e.className = 'form-control';
    let e = $('<input>', {
        'class': 'form-control',
        'type':'text',
    })
    edit.dblclick(addEdit);
   
    function addEdit(ev) {
        ev['target'].firstChild.replaceWith(e);
    }

});