using ProjetoFuncionarios.Model;

namespace ProjetoFuncionarios.Data
{
    public class FuncionarioRepository : IFuncionarioRepository
    {
        private readonly ContextoConexao context = new ContextoConexao();
        public void Add(Funcionario funcionario)
        {
            context.Funcionarios.Add(funcionario);
            context.SaveChanges();
        }

        public List<Funcionario> Get()
        {
            return context.Funcionarios.ToList();
        }

        public Funcionario? Get(int id)
        {
            return context.Funcionarios.Find(id);
        }
    }
}
