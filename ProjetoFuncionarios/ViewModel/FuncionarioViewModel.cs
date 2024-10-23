namespace ProjetoFuncionarios.ViewModel
{
    public class FuncionarioViewModel
    {
        public int Id { get; private set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public IFormFile Photo { get; set; }
    }
}
