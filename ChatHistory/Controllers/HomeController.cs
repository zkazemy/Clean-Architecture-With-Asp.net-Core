using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Service;
using Domain.Entities;
using Domain.Enums;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ChatHistory.Controllers
{
    public class HomeController : Controller
    {
        private IEventService _eventService;

        public HomeController(IEventService eventService)
        {
            _eventService = eventService;
        }
        public IActionResult Index()
        {
            return View("Index");
        }
        
        [HttpGet]
        public IActionResult ShowHistory([FromQuery]Granularity id)
        {
            switch (id)
            {
                case Granularity.MinuteByMinute:
                    var  minuteByMinutesHistory= _eventService.GetEventHistoryByMinute();
                    ViewBag.MinuteByMinuteData = minuteByMinutesHistory;
                    return View("MinuteByMinuteHistory");
                    break;
                case Granularity.Hourly:
                    Dictionary<string, List<string>> hourlyHistory = _eventService.GetEventHistoryHourly();
                    ViewBag.HourlyData = hourlyHistory;
                    return View("HourlyHistory");
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(id), id, null);
            }

            return null;
        }
    }
  
}
