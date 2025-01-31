using ApiFilms.Models;
using ApiFilms.Models.Dtos;
using ApiFilms.Repository.IRepository;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiFilms.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FilmsController : ControllerBase
    {
        private readonly IRespositoryFilm _flRepo;
        private readonly IMapper _mapper;

        public FilmsController(IRespositoryFilm flRepo, IMapper mapper)
        {
            _flRepo = flRepo;
            _mapper = mapper;
        }
        
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult GetFilms()
        {
            var listFilms = _flRepo.GetFilms();
            
            var listFilmsDTO = new List<FilmDTO>();

            foreach (var list in listFilms)
            {
                listFilmsDTO.Add(_mapper.Map<FilmDTO>(list));
            }
            return Ok(listFilmsDTO);
        }
        
        [HttpGet("{filmId:int}", Name = "GetFilm")] //there can be only one get method
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GetFilm(int filmId)
        {
            var itemFilm = _flRepo.GetFilm(filmId);

            if (itemFilm == null)
            {
                return NotFound();
            }
            
            var itemFilmDTO = _mapper.Map<FilmDTO>(itemFilm); //map the object to the DTO
            
            return Ok(itemFilmDTO);
        }
        
        [HttpPost]
        [ProducesResponseType(201, Type = typeof(FilmDTO))]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public IActionResult CreateFilm([FromBody] CreateFilmDTO createFilmDTO) //Receives DTO because the client side only manages the DTO
        {
            if (!ModelState.IsValid == null)
            {
                return BadRequest();
            }

            if (createFilmDTO == null)
            {
                return BadRequest();
            }

            if (_flRepo.ExistsFilm(createFilmDTO.Name))
            {
                ModelState.AddModelError("", "Film already exists");
                return StatusCode(404, ModelState);
            }
            
            var film = _mapper.Map<Film>(createFilmDTO); //maps from filmDTO to film

            if (!_flRepo.CreateFilm(film))
            {
                ModelState.AddModelError("", $"Something went wrong saving the film {film.Name}");
                return StatusCode(404, ModelState);
            }
            
            return CreatedAtRoute("GetFilm", new {filmId = film.Id}, film);
        }
        
        [HttpPatch("{filmId:int}", Name = "UpdatePatchFilm")] //patch is used to update the data
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        //FromBody means that the attribute is taken from the body of the HTTP request
        public IActionResult UpdatePatchFilm(int filmId, [FromBody] FilmDTO filmDTO) //Receives DTO because the client side only manages the DTO
        {
            if (!ModelState.IsValid == null)
            {
                return BadRequest();
            }

            if (filmDTO == null || filmId != filmDTO.Id)
            {
                return BadRequest();
            }
            
            var existingFilm = _flRepo.GetFilm(filmId);
            if (existingFilm == null)
            {
                return NotFound($"Film with id {filmId} not found");
            }
            
            var film = _mapper.Map<Film>(filmDTO); //maps from filmDTO to film

            if (!_flRepo.UpdateFilm(film))
            {
                ModelState.AddModelError("", $"Something went wrong updating the film {film.Name}");
                return StatusCode(500, ModelState);
            }
            
            return NoContent(); //NoContent is returned when an update fails
        }
        
        [HttpDelete("{filmId:int}", Name = "DeleteFilm")] //patch is used to update the data
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        //FromBody means that the attribute is taken from the body of the HTTP request
        public IActionResult DeleteFilm(int filmId) //Receives DTO because the client side only manages the DTO
        {
            if (!_flRepo.ExistsFilm(filmId))
                return NotFound($"film with id {filmId} not found");
            
            var film = _flRepo.GetFilm(filmId);

            if (!_flRepo.DeleteFilm(filmId))
            {
                ModelState.AddModelError("", $"Something went wrong deleting the film {film.Name}");
                return StatusCode(500, ModelState);
            }
            
            return NoContent(); //NoContent is returned when an update fails
        }

        [HttpGet("GetFilmsInCategory{categoryId:int}", Name = "GetFilmsByCategory")]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult GetFilmsByCategory(int categoryId)
        {
            var filmsList = _flRepo.GetFilmsInCategory(categoryId);
            if (filmsList == null)
                return NotFound();
            
            var filmsListDTO = new List<FilmDTO>();
            foreach (var film in filmsList)
            {
                filmsListDTO.Add(_mapper.Map<FilmDTO>(film));
            }
            
            return Ok(filmsListDTO);
        }
        
        [HttpGet("Browse")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult Browse(string filmName)
        {
            try
            {
                var result = _flRepo.SearchFilm(filmName);
                if (result == null)
                    return NotFound();
                else
                {
                    return Ok(result);
                }
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }
    }
}
