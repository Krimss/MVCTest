
$(document).ready(() => { 
    let id = $("#id")[0].value;
    let url = $('#url')[0].value;
    let ret = {id: id}
$.ajax({
    url: url,
    type: 'POST',
    contentType: "application/json",
    dataType:'json',
    data: JSON.stringify(ret)
}).done((d) => {
    $.each(d, (i) => {
        let selected = d[i]['isSelected'] ? "selected" : '';
        $('#founders').append('<option '+selected+' value="' + d[i]['id']+'">' + d[i]['fio']+ '</option>')
    });
})
});

