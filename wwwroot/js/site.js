// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

$(document).ready(function () {
    $('#tabela-dados').editable({
        /*columnDefs: [{
            targets: [0, 5], // Índices das colunas editáveis (começando em 0)
            className: 'editable'
        }]*/
    });
});


$(document).ready(function () {
    $('#tabela-dados').on('click', 'td[contenteditable="true"]', function () {
        $(this).addClass('editing');
    });

    $('#tabela-dados').on('blur', 'td.editing', function () {
        $(this).removeClass('editing');
    });
});