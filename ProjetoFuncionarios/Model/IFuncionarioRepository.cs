namespace ProjetoFuncionarios.Model
{
    public interface IFuncionarioRepository
    {
        void Add(Funcionario funcionario);
        
        List<Funcionario> Get();

        Funcionario Get(int id);
    }
}
