using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using SalesManagement.Entity;
using SalesManagement.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Threading.Tasks;

namespace SalesManagement.Pages.Admin
{
    public class DesignationModel : PageModel
    {
        private readonly ILogger<DesignationModel> _logger;
        private readonly IConfiguration _configuration;
        public DesignationModel(ILogger<DesignationModel> logger, IConfiguration configuration)
        {
            _logger = logger;
            _configuration = configuration;
        }

        public void OnGet()
        {
            ViewData["ApiUrl"] = _configuration.GetValue<string>("WebAPIBaseUrl"); 
        }

        public JsonResult SaveDesignation()
        {
            Designation designation = new Designation();

            return new JsonResult(designation);
        }
    }
}
