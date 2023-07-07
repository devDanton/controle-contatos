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

            try
            {
                bool apagado = _contatoRepositorio.Apagar(Id);
                
                if (apagado)
                {
                    TempData["MensagemSucesso"] = "Contato deletado com sucesso!";
                }
            return RedirectToAction("Index");
            }
            
            catch (Exception error)
            {
               TempData["MensagemErro"] = $"Não foi possível deletar seu contato, detalhe do erro: {error.Message}";
               return View("Deletar");
            }
        }

        [HttpPost]
        public IActionResult Adicionar(ContatoModel contato)
        {
            try
            {
                if (ModelState.IsValid)
                {
                //Adiciona de fato o contato
                    _contatoRepositorio.Adicionar(contato);
                    TempData["MensagemSucesso"] = "Contato cadastrado com sucesso!";
                    return RedirectToAction("Index");
                }
                return View(contato);
            }
            catch (Exception error)
            {
                TempData["MensagemErro"] = $"Não foi possível cadastrar seu contato, detalhe do erro: {error.Message}";
                return RedirectToAction("Index");
            }

        }

        [HttpPost]
        public IActionResult Alterar(ContatoModel contato)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    //Altera de fato as informações de contato.
                    _contatoRepositorio.Alterar(contato);
                    TempData["MensagemSucesso"] = "Contato editado com sucesso!";
                    return RedirectToAction("Index");
                }

                return View("Editar", contato);
            }
            catch (Exception error)
            {
                TempData["MensagemErro"] = $"Não foi possível editar seu contato, detalhe do erro: {error.Message}";
                return RedirectToAction("Index");
            }
        }
    }
}
