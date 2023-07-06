using ControleContatos.Models;
using ControleContatos.Repositorio;
using Microsoft.AspNetCore.Mvc;

namespace ControleContatos.Controllers
{
    public class ContatoController : Controller
    {
        private readonly IContatoRepositorio _contatoRepositorio;
        public ContatoController(IContatoRepositorio contatoRepositorio)
        {
            _contatoRepositorio = contatoRepositorio;
        }
        public IActionResult Index()
        {
            List<ContatoModel> contatos = _contatoRepositorio.BuscarTodos();

            return View(contatos);
        }

        public IActionResult Adicionar()
        {
            return View();
        }

        public IActionResult Editar(int id)
        {
            ContatoModel contato = _contatoRepositorio.ListarPorId(id);
            return View(contato);
        }

        public IActionResult Deletar(int id)
        {
            //Exibe o nome do usuário que está selecionado para a deleção
            ContatoModel contato = _contatoRepositorio.ListarPorId(id);
            return View(contato);
        }

        public IActionResult Apagar(int Id)
        {
            //Apaga de fato o usuário selecionado
            _contatoRepositorio.Apagar(Id);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Adicionar(ContatoModel contato)
        {   
            //Adiciona de fato o contato
            if(ModelState.IsValid)
            {
            _contatoRepositorio.Adicionar(contato);
            return RedirectToAction("Index");
            }

            return View(contato);

        }

        [HttpPost]
        public IActionResult Alterar(ContatoModel contato)
        {
            //Altera de fato as informações de contato.
            _contatoRepositorio.Alterar(contato);
            return RedirectToAction("Index");
        }
    }
}
