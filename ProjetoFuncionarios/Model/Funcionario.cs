using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjetoFuncionarios.Model
{
    [Table("funcionario")]
    public class Funcionario
    {
        [Key]
        public int id { get; private set; }
        public string name { get; set; }
        public int age { get; set; }
        public string photo { get; set; }

        public Funcionario(int id, string name, int age, string photo) 
        {
            this.id = id;
            this.name = name ?? throw new ArgumentNullException(nameof(name));
            this.age = age;
            this.photo = photo;

        }
    }
}
