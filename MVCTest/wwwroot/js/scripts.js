
let edit = document.getElementsByClassName('edit');

let e = document.createElement('input');
e.type='text';
e.className='form-control';

Array.from(edit).forEach(element => {
    element.addEventListener('dblclick',addEdit);
    element.addEventListener('keypress',Save)
});



function addEdit(){
    e.value=this.textContent;
    this.replaceChildren();
    this.append(e);
    e.focus();
}

function Save(e){
    if(e.keyCode===13){
        let text=this.firstElementChild.value;
        this.replaceChildren();
        this.append(text);
    } 
}

$(document).ready(
    $(".form-control").change(function () {
        $("input.input-validation-error").removeClass("input-validation-error").addClass("is-invalid")
    })
)