using BibliotecaDaDudu.API.Entities;
using BibliotecaDaDudu.API.Persistence;
using Microsoft.AspNetCore.Mvc;

namespace BibliotecaDaDudu.API.Controllers
{
    [Route("api/manga/{mangaID}/volume")]
    [ApiController]
    public class VolumeController : Controller
    {
        private readonly BibibliotecaDaDuduDbContext _context;

        public VolumeController(BibibliotecaDaDuduDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult GetAll(Guid mangaID)
        {
            var volumesList = _context.Volumes.Where(volume => volume.MangaId == mangaID).ToList();
            return Ok(volumesList);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult GetById(Guid id)
        {
            var volume = _context.Volumes.SingleOrDefault(volume => volume.Id == id);
            if (volume == null)
            {
                return NotFound();
            }
            return Ok(volume);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult Post(Guid mangaID, VolumeEntity volume)
        {
            volume.MangaId = mangaID;

            var manga = _context.Mangas.Any(manga => manga.Id == volume.MangaId);
            if(!manga)
            {
                return NotFound();
            }   

            _context.Volumes.Add(volume);
            _context.SaveChanges();

            return CreatedAtAction(nameof(GetById), new { id = volume.Id, mangaId = volume.MangaId }, volume);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult Update(Guid id, VolumeEntity volumeUpdate)
        {

            var volume = _context.Volumes.SingleOrDefault(volume => volume.Id == id);
            if (volume == null)
            {
                return NotFound();
            }

            _context.Volumes.Update(volumeUpdate);
            _context.SaveChanges();
            return NoContent();
        }

        //[HttpDelete("{id}")]
        //[ProducesResponseType(StatusCodes.Status200OK)]
        //public IActionResult Desativar(Guid id)
        //{
        //    var volume = _context.volumes.SingleOrDefault(volume => volume.Id == id);
        //    if (volume == null)
        //    {
        //        return NotFound();
        //    }

        //    volume.Desativar();
        //    return NoContent();
        //}
    }
}
