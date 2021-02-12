using Aspose.Words;
using DataRepository.Models.ELD.Prod1;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EndorsementDemoAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HighlightBookmarksController : ControllerBase
    {
        private readonly ELD_PRODUCTION_31Context _context;

        public HighlightBookmarksController(ELD_PRODUCTION_31Context context)
        {
            _context = context;
        }

        
        //[HttpGet("[action]")]
        //public IActionResult HighlightBlank(string id)
        //{
        //    try
        //    {
        //        var outputNextHighlight = highlightNextBlank(id);
        //        return Ok(highlight);
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine(ex.Message);
        //    }
        //}

        //private void highlightNextBlank(int id)
        //{
        //    var undFormVersion = _context.UndFormVersion.Find(id);
        //    var getFilePath = undFormVersion.FileName.ToString();
        //    string newFilePath = "C:\\Users\\nsiddiqui\\source\\repos\\EndorsementDemo\\EndorsementDemoUI\\src\\assets\\";
        //    string newFileName = "Endrosement.docx";

        //    Document endorsement = new Document(getFilePath);


        //    endorsement.Save(newFilePath + newFileName, SaveFormat.Docx);
        //}
    }
}
