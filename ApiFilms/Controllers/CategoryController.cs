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
    public class CategoryController : ControllerBase
    {
        private readonly IRespositoryCategory _ctRepo;
        private readonly IMapper _mapper;

        public CategoryController(IRespositoryCategory ctRepo, IMapper mapper)
        {
            _ctRepo = ctRepo;
            _mapper = mapper;
        }
        
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult GetCategories()
        {
            var listCategories = _ctRepo.GetCategories();
            
            var listCategoriesDTO = new List<CategoryDTO>();

            foreach (var list in listCategories)
            {
                listCategoriesDTO.Add(_mapper.Map<CategoryDTO>(list));
            }
            return Ok(listCategoriesDTO);
        }
        
        [HttpGet("{categoryId:int}", Name = "GetCategory")] //there can be only one get method
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GetCategory(int categoryId)
        {
            var itemCategory = _ctRepo.GetCategory(categoryId);

            if (itemCategory == null)
            {
                return NotFound();
            }
            
            var itemCategoryDTO = _mapper.Map<CategoryDTO>(itemCategory); //map the object to the DTO
            
            return Ok(itemCategoryDTO);
        }
        
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public IActionResult CreateCategory([FromBody] CreateCategoryDTO createCategoryDTO) //Receives DTO because the client side only manages the DTO
        {
            if (!ModelState.IsValid == null)
            {
                return BadRequest();
            }

            if (createCategoryDTO == null)
            {
                return BadRequest();
            }

            if (_ctRepo.ExistsCategory(createCategoryDTO.Name))
            {
                ModelState.AddModelError("", "Category already exists");
                return StatusCode(404, ModelState);
            }
            
            var category = _mapper.Map<Category>(createCategoryDTO); //maps from categoryDTO to category

            if (!_ctRepo.CreateCategory(category))
            {
                ModelState.AddModelError("", $"Something went wrong saving the category {category.Name}");
                return StatusCode(404, ModelState);
            }
            
            return CreatedAtRoute("GetCategory", new {categoryId = category.Id}, category);
        }
    }
}
