using ControleContatos.Models;

namespace ControleContatos.Repositorio
{
    public interface IContatoRepositorio
    {
        ContatoModel ListarPorId(int id);
        List<ContatoModel> BuscarTodos();
        List<ContatoModel> Buscar(string termoDeBusca);
        ContatoModel Adicionar(ContatoModel contato);
        ContatoModel Alterar(ContatoModel contato);
        bool Apagar(int id);
    }
}
