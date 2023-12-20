using BibliotecaDaDudu.API.Entities;
using BibliotecaDaDudu.API.Persistence;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BibliotecaDaDudu.API.Controllers
{
    [Route("api/manga")]
    [ApiController]
    public class MangaController : ControllerBase
    {
        private readonly BibibliotecaDaDuduDbContext _context;

        public MangaController(BibibliotecaDaDuduDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult GetAll()
        {
            var mangasList = _context.Mangas.Where(manga => manga.Ativo).ToList();
            return Ok(mangasList);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult GetById(Guid id)
        {
            var manga = _context.Mangas.Include(manga => manga.Volumes).SingleOrDefault(manga => manga.Id == id);
            if (manga == null)
            {
                return NotFound();
            }
            return Ok(manga);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult Post(MangaEntity manga)
        {
            _context.Mangas.Add(manga);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetById), new { id = manga.Id }, manga);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult Update(Guid id, MangaEntity mangaUp)
        {
            var manga = _context.Mangas.SingleOrDefault(manga => manga.Id == id);
            if (manga == null)
            {
                return NotFound();
            }

            manga.Update(mangaUp);
            _context.Mangas.Update(manga);
            _context.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult Desativar(Guid id)
        {
            var manga = _context.Mangas.SingleOrDefault(manga => manga.Id == id);
            if (manga == null)
            {
                return NotFound();
            }

            manga.Desativar();
            _context.SaveChanges();
            return NoContent();
        }

        [HttpPut("{id}/reativar")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult Reativar(Guid id)
        {
            var manga = _context.Mangas.SingleOrDefault(manga => manga.Id == id);
            if (manga == null)
            {
                return NotFound();
            }

            manga.Reativar();
            _context.SaveChanges();
            return NoContent();
        }
    }
}
