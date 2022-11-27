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
    public class UploadModel : PageModel
    {
        private readonly ILogger<UploadModel> _logger;
        private readonly IConfiguration _configuration;

        private string fullPath = System.AppDomain.CurrentDomain.BaseDirectory.ToString() + "uploads";
        public UploadModel(ILogger<UploadModel> logger, IConfiguration configuration)
        {
            _logger = logger;
            _configuration = configuration;
        }
        [BindProperty]
        public FileUpload fileUpload { get; set; }
        public void OnGet()
        {
            ViewData["SuccessMessage"] = "";
        }
        public async Task<IActionResult> OnPostUploadAsync(FileUpload fileUpload)
        {
            //Creating upload folder  
            if (!Directory.Exists(fullPath))
            {
                Directory.CreateDirectory(fullPath);
            }
            var formFile = fileUpload.FormFile;
            Guid guid = Guid.NewGuid();
            var filename = formFile.FileName;
            var filePath = Path.Combine(fullPath, guid.ToString() + "."+ Path.GetExtension(filename));

            using (var stream = System.IO.File.Create(filePath))
            {
                formFile.CopyToAsync(stream);
            }
            List<FileUploadStaging> stagingValues = System.IO.File.ReadAllLines(filePath)
                                           .Skip(1)
                                           .Select(v => FileUploadStaging.FromCsv(v))
                                           .ToList();

            if(stagingValues.Count > 0)
            {
                var apiUrl = _configuration.GetValue<string>("WebAPIBaseUrl");
                FileUploadEntity uploadRequest = new FileUploadEntity();
                uploadRequest.FileName = formFile.FileName;
                uploadRequest.LocalFilePath = filePath;
                uploadRequest.UploadedBy = 1;
                uploadRequest.IsProcessed = false;
                uploadRequest.ErrorMessage = "";
                uploadRequest.StagingFileDetails = stagingValues;


                // post request 
                using (var client = new HttpClient())
                {
                    var response = await client.PostAsync(apiUrl + "FileUpload/InsertFileUpload", uploadRequest, new JsonMediaTypeFormatter()).ConfigureAwait(false);

                    response.EnsureSuccessStatusCode();

                    await response.Content.ReadAsStringAsync().ContinueWith((Task<string> x) =>
                    {
                        if (x.IsFaulted)
                            throw x.Exception;

                        var result = x.Result;
                        if (result.Contains("Success"))
                        {
                            ViewData["SuccessMessage"] = formFile.FileName.ToString() + " file uploaded!!";
                        }
                        else
                        {
                            ViewData["SuccessMessage"] = formFile.FileName.ToString() + " file upload Failed!!";
                        }

                    });
                }
            }
            else
            {
                ViewData["SuccessMessage"] = formFile.FileName.ToString() + " file uploaded Failed. No records Found!!";
            }
            
            return Page();
        }

        public static DataTable ConvertCSVtoDataTable(string strFilePath)
        {
            DataTable dt = new DataTable();
            using (StreamReader sr = new StreamReader(strFilePath))
            {
                string[] headers = sr.ReadLine().Split(',');
                foreach (string header in headers)
                {
                    dt.Columns.Add(header);
                }
                while (!sr.EndOfStream)
                {
                    string[] rows = sr.ReadLine().Split(',');
                    DataRow dr = dt.NewRow();
                    for (int i = 0; i < headers.Length; i++)
                    {
                        dr[i] = rows[i];
                    }
                    dt.Rows.Add(dr);
                }

            }
            return dt;
        }
    }

    public class FileUpload
    {
        [Required]
        [Display(Name = "File")]
        public IFormFile FormFile { get; set; }
        public string SuccessMessage { get; set; }
    }
}
