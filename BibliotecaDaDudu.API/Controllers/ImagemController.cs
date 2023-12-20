using BibliotecaDaDudu.API.Entities;
using BibliotecaDaDudu.API.Persistence;
using Microsoft.AspNetCore.Mvc;

namespace BibliotecaDaDudu.API.Controllers
{
    [Route("api/imagem")]
    [ApiController]
    public class ImagemController : Controller
    {
        private readonly BibibliotecaDaDuduDbContext _context;

        public ImagemController(BibibliotecaDaDuduDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult GetAll(Guid id)
        {
            var imagemsList = _context.Imagens.ToList();
            return Ok(imagemsList);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult GetById(Guid id)
        {
            var imagem = _context.Imagens.SingleOrDefault(imagem => imagem.Id == id);
            if (imagem == null)
            {
                return NotFound();
            }
            return Ok(imagem);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult Post(ImagemEntity imagem)
        {
            _context.Imagens.Add(imagem);
            _context.SaveChanges();

            return CreatedAtAction(nameof(GetById), new { id = imagem.Id }, imagem.Id);
        }
    }
}
