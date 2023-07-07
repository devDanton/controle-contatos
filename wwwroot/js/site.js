// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

/*
    $(document).ready(() => {
        $('#mytable').DataTable();
    })
*/

let table = new DataTable('#table-contatos');

$('.close-alert').click(() => {
    $('.alert').hide('hide')
});

$('#table-contatos').DataTable({
    "ordering": true,
    "paging": true,
    "searching": true,
    "oLanguage": {
        "sEmptyTable": "Nenhum registro encontrado na tabela",
        "sInfo": "Mostrar _START_ até _END_ de _TOTAL_ registros",
        "sInfoEmpty": "Mostrar 0 até 0 de 0 Registros",
        "sInfoFiltered": "(Filtrar de _MAX_ total registros)",
        "sInfoPostFix": "",
        "sInfoThousands": ".",
        "sLengthMenu": "Mostrar _MENU_ registros por pagina",
        "sLoadingRecords": "Carregando...",
        "sProcessing": "Processando...",
        "sZeroRecords": "Nenhum registro encontrado",
        "sSearch": "Pesquisar",
        "oPaginate": {
            "sNext": "Proximo",
            "sPrevious": "Anterior",
            "sFirst": "Primeiro",
            "sLast": "Ultimo"
        },
        "oAria": {
            "sSortAscending": ": Ordenar colunas de forma ascendente",
            "sSortDescending": ": Ordenar colunas de forma descendente"
        }
    }
});

function adicionarLinha()
{
    // Obtém uma referência para a tabela
    var tabela = document.getElementById("table");

    var tbody = tabela.getElementsByTagName("tbody")[0];
    if (!tbody) {
        // Se não existir, cria o elemento tbody
        tbody = document.createElement("tbody");
        tabela.appendChild(tbody);
    }

    var tr = document.getElementsByTagName("tr")
    var ultimoTr = tr[tr.length - 1];

    var ultimoValorTr = ultimoTr.th;

    // Cria uma nova linha
    var novaLinha = tbody.insertRow();

    // Cria células na nova linha
    var th = document.createElement("th");
    th.setAttribute("scope", "row");
    th.innerText = tr.length-1;
    novaLinha.appendChild(th);

    var td1 = document.createElement("td");
    td1.setAttribute("contenteditable", "true");
    td1.innerText = "Nome";
    novaLinha.appendChild(td1);

    var td2 = document.createElement("td");
    td2.setAttribute("contenteditable", "true");
    td2.innerText = "Email";
    novaLinha.appendChild(td2);

    var td3 = document.createElement("td");
    td3.setAttribute("contenteditable", "true");
    td3.innerText = "Nº Telefone";
    novaLinha.appendChild(td3);

    var td4 = document.createElement("td");
    var div = document.createElement("div");
    div.setAttribute("class", "btn-group");
    div.setAttribute("role", "group");
    div.setAttribute("aria-label", "Salvar");

    var editarLink = document.createElement("button");
    editarLink.setAttribute("type", "button");
    editarLink.setAttribute("class", "btn btn-success");
    editarLink.setAttribute("title", "Salvar");
    /*editarLink.setAttribute("asp-controller", "Contato");*/
    /*editarLink.setAttribute("asp-action", "Editar");*/
    var editarIcon = document.createElement("ion-icon");
    editarIcon.setAttribute("name", "save");
    editarLink.appendChild(editarIcon);
    div.appendChild(editarLink);

    var deletarLink = document.createElement("button");
    /*deletarLink.setAttribute("type", "button");*/
    deletarLink.setAttribute("class", "btn btn-danger");
    deletarLink.setAttribute("title", "Deletar");
   /* deletarLink.setAttribute("asp-controller", "Contato");
    deletarLink.setAttribute("asp-action", "Deletar");*/
    var deletarIcon = document.createElement("ion-icon");
    deletarIcon.setAttribute("name", "trash");
    deletarLink.appendChild(deletarIcon);
    div.appendChild(deletarLink);

    td4.appendChild(div);
    novaLinha.appendChild(td4);

    // Adiciona a nova linha à tabela
    tbody.appendChild(novaLinha);

}