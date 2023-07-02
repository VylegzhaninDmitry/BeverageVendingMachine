using AutoMapper;
using BeverageVendingMachine.DTOs;
using BeverageVendingMachine.Models.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BeverageVendingMachine.Controllers
{
    public class AdminController : Controller
    {
        private readonly ApplicationContext _context;
        private readonly IMapper _mapper;

        public AdminController(ApplicationContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [Route("admin")]
        [HttpGet]
        public IActionResult Admin(string key) {
            if(string.IsNullOrEmpty(key) || key != "qwe")
            {
                return View("Index");
            }

            return View();
        }

        [ProducesResponseType(typeof(Beverage), 200)]
        [HttpPost]
        public async Task<IActionResult> AddBeverage([FromBody] CreateBeverageDto dto)
        {

            var beverage = new Beverage
            {
                BeverageCount = dto.BeverageCount,
                Image = dto.Image,
                Name = dto.Name,
                Price = dto.Price,
            };


            _context.Add(beverage);
            await _context.SaveChangesAsync();

            return Json(beverage);
        }

        [ProducesResponseType(typeof(Beverage), 200)]
        [HttpGet]
        public async Task<IActionResult> GetBeverageById(int id)
        {
            var entity = await _context.Set<Beverage>().FindAsync(id);
            await _context.SaveChangesAsync();

            return entity is not null ? Json(entity) : Json("Ошибка");
        }

        [ProducesResponseType(typeof(List<Beverage>), 200)]
        [HttpGet]
        public async Task<IActionResult> GetBeverages()
        {
            var beverages = await _context.Set<Beverage>().ToListAsync();

            return Json(beverages);
        }


        [ProducesResponseType(typeof(bool), 200)]
        [HttpGet]
        public async Task<IActionResult> DeleteBeverage(int id)
        {
            var entity = await _context.Set<Beverage>().FindAsync(id);
            if (entity is null)
            {
                return Json(false);
            }
            _context.Set<Beverage>().Remove(entity);
            await _context.SaveChangesAsync();

            return Json(true);
        }

        [ProducesResponseType(typeof(Beverage), 200)]
        [HttpPost]
        public async Task<IActionResult> UpdateBeverage([FromBody] UpdateBeverageDto dto)
        {
            var beverage = _mapper.Map<Beverage>(dto);
            var entity = _context.Set<Beverage>().Update(beverage);
            await _context.SaveChangesAsync();

            return Json(entity.Entity);
        }
    }
}
