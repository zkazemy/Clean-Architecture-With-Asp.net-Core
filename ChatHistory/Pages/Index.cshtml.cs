using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Enums;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;

namespace ChatHistory.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
 
        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {

        }

        public string GranularityItem { get; set; }
        public List<SelectListItem> Granularities { get; } = new List<SelectListItem>
        {
            new SelectListItem {Value = ((int) Granularity.Hourly).ToString(), Text = Granularity.Hourly.ToString()},
            new SelectListItem {Value = ((int) Granularity.MinuteByMinute).ToString(), Text = Granularity.MinuteByMinute.ToString()}
        };



    }
}
