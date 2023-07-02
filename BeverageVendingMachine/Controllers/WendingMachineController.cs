using AutoMapper;
using BeverageVendingMachine.DTOs;
using BeverageVendingMachine.Models.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Drawing;

namespace BeverageVendingMachine.Controllers
{
    public class WendingMachineController : Controller
    {
        private readonly ApplicationContext _context;
        private readonly IMapper _mapper;

        public WendingMachineController(ApplicationContext context, IMapper mapper) 
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var entities = await _context.Beverages.ToListAsync();
            var list = new List<BeverageDto>();
            foreach (var entity in entities)
            {
                var dto = _mapper.Map<BeverageDto>(entity);
                dto.Image = "data:image/png;base64," + dto.Image;
                list.Add(dto);

            }

            return View(list);
        }

        [HttpPost]
        public async Task<IActionResult> RemoveBeverage([FromBody] BeverageCountDto dto)
        {
            var entity = await _context.Beverages.FirstOrDefaultAsync(i => i.Id == dto.Id);
            if (entity == null) { return View("Error"); }
            entity.BeverageCount -= dto.BeverageCount;
            _context.SaveChanges();

            var entities = await _context.Beverages.ToListAsync();
            var list = new List<BeverageDto>();
            foreach (var item in entities)
            {
                list.Add(_mapper.Map<BeverageDto>(item));
            }

            return Json(list);
        }
    }
}
