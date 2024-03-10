using _2FluentValidation.Models;
using _2FluentValidation.Models.DTOs;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace _2FluentValidation.Controllers
{
    public class ProjectionController : Controller
    {
        private readonly IMapper _mapper;

        public ProjectionController(IMapper mapper)
        {
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(EventDateDto eventDateDto)
        {
            EventDate eventDate = _mapper.Map<EventDate>(eventDateDto);
            ViewBag.date = eventDate.Date.ToShortDateString();
            return View();
        }
    }
}
