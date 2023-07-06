using ControleContatos.Data;
using ControleContatos.Models;

namespace ControleContatos.Repositorio
{
    public class ContatoRepositorio : IContatoRepositorio

    {
        private readonly BancoContext _bancoContext;

        public ContatoRepositorio(BancoContext bancoContext) 
        {
           this._bancoContext = bancoContext;
        }
        public ContatoModel ListarPorId(int id)
        {
            return _bancoContext.Contatos.FirstOrDefault(x => x.Id == id);
        }

        public List<ContatoModel> Buscar(string termoDeBusca)
        {
            return (List<ContatoModel>)_bancoContext.Contatos.Where(x => x.Nome.Contains(termoDeBusca) || x.Email.Contains(termoDeBusca) || x.Celular.Contains(termoDeBusca)) ;
        }

        public List<ContatoModel> BuscarTodos()
        {
            return _bancoContext.Contatos.ToList();
        }
        public ContatoModel Adicionar(ContatoModel contato)
        {
            _bancoContext.Contatos.Add(contato);
            _bancoContext.SaveChanges();
            return contato;
        }

        public ContatoModel Alterar(ContatoModel contato)
        {
            ContatoModel contatoDB = ListarPorId(contato.Id);

            if (contatoDB == null) { 
                throw new Exception("Erro na atualização do contato. Não foi possível buscar o contato desejado!"); 
            } else { 
            contatoDB.Nome = contato.Nome;
            contatoDB.Email = contato.Email;
            contatoDB.Celular = contato.Celular;

                _bancoContext.Contatos.Update(contatoDB);
                _bancoContext.SaveChanges();

                return contatoDB;
            }
        }

        public bool Apagar(int id)
        {
            ContatoModel contatoDB = ListarPorId(id);

            if (contatoDB == null)
            {
                throw new Exception("Erro na deleção do contato. Não foi possível buscar o contato desejado!");
            }
            else
            {
                _bancoContext.Contatos.Remove(contatoDB);
                _bancoContext.SaveChanges();

                return true;
            }
        }

       
    }
}
