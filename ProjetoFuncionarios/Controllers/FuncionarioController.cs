using Microsoft.AspNetCore.Mvc;
using ProjetoFuncionarios.Model;
using ProjetoFuncionarios.ViewModel;
using System.Reflection;

namespace ProjetoFuncionarios.Controllers
{
    [ApiController]
    [Route("api/v1/funcionario")]
    public class FuncionarioController : ControllerBase
    {
        private readonly IFuncionarioRepository _funcionarioRepository;

        public FuncionarioController(IFuncionarioRepository funcionarioRepository)
        {
            _funcionarioRepository = funcionarioRepository ?? throw new ArgumentNullException(nameof(funcionarioRepository));
        }

        [HttpPost]
        public IActionResult Add([FromForm]FuncionarioViewModel funcionarioView)
        {
            var filePath = Path.Combine("Storage", funcionarioView.Photo.FileName);
            using Stream fileStream = new FileStream(filePath, FileMode.Create);
            funcionarioView.Photo.CopyTo(fileStream);

            var funcionario = new Funcionario(funcionarioView.Id, funcionarioView.Name, funcionarioView.Age, filePath);

            _funcionarioRepository.Add(funcionario);

            return Ok();
        }

        [HttpPost]
        [Route("{id}/download")]
        public IActionResult DownloadPhoto(int id) 
        {
            var funcionario = _funcionarioRepository.Get(id);
            var folder = @"/Users\Adm\source\repos\ProjetoFuncionarios\ProjetoFuncionarios\Storage\";
            var dataBytes = System.IO.File.ReadAllBytes(funcionario.photo);

            foreach (string file in Directory.GetFiles(folder)) 
            {
                string ext = Path.GetExtension(file).ToLower();
                if (ext == ".png")
                {
                    return File(dataBytes, "image/png");
                    
                }
                else if (ext == ".jpg")
                {
                    return File(dataBytes, "image/jpg");
                }
                else if (ext == ".jpeg")
                {
                    return File(dataBytes, "image/jpeg");
                }
            }
            return Ok();
        }

        [HttpGet]
        public IActionResult Get() 
        {
            var funcionario = _funcionarioRepository.Get(); 
            return Ok(funcionario);
        }
    }
}
