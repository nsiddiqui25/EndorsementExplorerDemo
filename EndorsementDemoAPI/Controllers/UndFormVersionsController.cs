﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DataRepository.Models.ELD.Prod1;
using Aspose.Words;
using System.IO;
using GroupDocs.Viewer;
using GroupDocs.Viewer.Options;
using System.Drawing;
using System.Text;

namespace EndorsementDemoAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UndFormVersionsController : ControllerBase
    {
        private readonly ELD_PRODUCTION_31Context _context;
        private const string newFilePath = "C:\\Users\\nsiddiqui\\source\\repos\\EndorsementDemo\\EndorsementDemoUI\\src\\assets\\";

        public UndFormVersionsController(ELD_PRODUCTION_31Context context)
        {
            _context = context;
        }

        // GET: api/UndFormVersions
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UndFormVersion>>> GetUndFormVersion()
        {
            return await _context.UndFormVersion.ToListAsync();
        }

        // GET: api/UndFormVersions/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UndFormVersion>> GetUndFormVersion(int id)
        {
            var undFormVersion = await _context.UndFormVersion.FindAsync(id);

            if (undFormVersion == null)
            {
                return NotFound();
            }
            //SaveEndorsementDocumentForPreview(id);
            //HighlightFirstEndorsementForPreview(id);
            //HighlightNextEndorsementDocumentForPreview(id);
            return undFormVersion;
        }

        // GET: api/UndFormVersions/5
        // check in Postman for Bookmark Names
        [HttpGet("pdf/{id}")]
        public async Task<IActionResult> GetUndFormVersionPdf(int id)
        {
            var undFormVersion = await _context.UndFormVersion.FindAsync(id);

            if (undFormVersion == null)
            {
                return NotFound();
            }

            // SaveEndorsementDocumentForPreview(id);
            // var fileName = HighlightNextEndorsementDocumentForPreview(id);
            var getFilePath = undFormVersion.FileName.ToString();

            Document endorsement = new Document(getFilePath);
            DocumentBuilder builder = new DocumentBuilder(endorsement);
            BookmarkCollection bookmarks = endorsement.Range.Bookmarks;

            foreach (var bookmark in bookmarks)
            {
                if (bookmark.Name.StartsWith(undFormVersion.FormVersionNo.Substring(0,6)))
                {
                    builder.MoveToBookmark(bookmark.Name);
                    builder.Font.HighlightColor = Color.Yellow;
                    builder.Write("Blank " + bookmark.Name.Substring(bookmark.Name.Length - 2) + " ");
                }
            }
            //endorsement.Save(newFilePath + newFileName, SaveFormat.Docx);
            using var stream = new MemoryStream();
            endorsement.Save(stream, SaveFormat.Pdf);
            var bytes = stream.ToArray();

            return File(bytes, "application/pdf");
        }

        [HttpGet("bookmarks/{id}")]
        public IEnumerable<string> GetBookmarkNames(int id)
        {
            var undFormVersion = _context.UndFormVersion.Find(id);
            var getFilePath = undFormVersion.FileName.ToString();

            //string newFileName = "EndrosementBlankPreview.pdf";

            Document endorsement = new Document(getFilePath);
            DocumentBuilder builder = new DocumentBuilder(endorsement);
            BookmarkCollection bookmarks = endorsement.Range.Bookmarks;

            var bookmarkNames = bookmarks.Select(b => b.Name);

            return bookmarkNames;
        }

        [HttpGet("highlight/{id}")]
        public IActionResult HighlightBookmarkNames(int id)
        {
            HighlightEndorsementForPreview(id);
            //HighlightNextEndorsementDocumentForPreview(id, bookmarkIndex);
            return Ok();
        }        

        //[HttpGet("[action]")]
        //public IActionResult GetNextHighlight(int id)
        //{
        //    //var undFormVersion = await _context.UndFormVersion.FindAsync(id);

        //    //if (undFormVersion == null)
        //    //{
        //    //    return NotFound();
        //    //}            
        //    HighlightNextEndorsementDocumentForPreview(id);
        //    return Ok();
        //}

        //[HttpGet("{action}")]
        //public IActionResult HighlightNextBlank(int id)
        //{
        //    HighlightNextEndorsementDocumentForPreview(id);
        //    return Ok();
        //}

        private void SaveEndorsementDocumentForPreview(int id)
        {
            var undFormVersion = _context.UndFormVersion.Find(id);
            var getFilePath = undFormVersion.FileName.ToString();
            string newFileName = "Endrosement.doc";

            Document endorsement = new Document(getFilePath);
            endorsement.Save(newFilePath + newFileName, SaveFormat.Doc);
        }

        #region Aspose Highlight
        private string HighlightNextEndorsementDocumentForPreview(int id, int bookmarkIndex)
        {
            var undFormVersion = _context.UndFormVersion.Find(id);
            var getFilePath = undFormVersion.FileName.ToString();

            string newFileName = "EndrosementBlankPreview.pdf";

            Document endorsement = new Document(getFilePath);
            DocumentBuilder builder = new DocumentBuilder(endorsement);

            // Highlights bookmark by passing bookmark name as a string.  
                // Debug GetBookmarkNames(formVersionId) to get collection of bookmark names from Endorsement Doc
            Bookmark bookmark = endorsement.Range.Bookmarks[bookmarkIndex];
            builder.MoveToBookmark(bookmark.Name);
            builder.Font.HighlightColor = Color.Yellow;
            builder.Writeln(bookmark.Name);

            //// Finds, highlights, and labels all bookmarks on a document by their names
            //BookmarkCollection bookmarks = endorsement.Range.Bookmarks;
            //foreach (var bm in bookmarks)
            //{
            //    builder.MoveToBookmark(bm.Name);
            //    builder.Font.HighlightColor = Color.Yellow;
            //    builder.Writeln(bm.Name);
            //}

            //PrintAllBookmarkInfo(bookmarks);

            var savedFileName = newFilePath + newFileName;
            endorsement.Save(savedFileName, SaveFormat.Pdf);
            return savedFileName;
        }

        private string HighlightEndorsementForPreview(int id)
        {
            var undFormVersion = _context.UndFormVersion.Find(id);
            var getFilePath = undFormVersion.FileName.ToString();

            string newFileName = "EndrosementBlankPreview.pdf";

            Document endorsement = new Document(getFilePath);
            DocumentBuilder builder = new DocumentBuilder(endorsement);
            BookmarkCollection bookmarks = endorsement.Range.Bookmarks;

            foreach (var bookmark in bookmarks)
            {
                if ((bookmark.Name == "insured_name1") || (bookmark.Name == "policy_period1") || (bookmark.Name == "policy_number1") || (bookmark.Name == "effective_date1"))
                {
                    builder.MoveToBookmark(bookmark.Name);
                    builder.Font.HighlightColor = Color.Yellow;
                    builder.Writeln(bookmark.Name);
                }
            }
            var savedFileName = newFilePath + newFileName;
            endorsement.Save(savedFileName, SaveFormat.Pdf);
            return savedFileName;
        }

        private string HighlightNextEndorsementForPreview(int id, string bookmarkName)
        {
            var undFormVersion = _context.UndFormVersion.Find(id);
            var getFilePath = undFormVersion.FileName.ToString();

            string newFileName = "EndrosementBlankPreview.pdf";

            Document endorsement = new Document(getFilePath);
            DocumentBuilder builder = new DocumentBuilder(endorsement);
            Bookmark firstBbookmark = endorsement.Range.Bookmarks[bookmarkName];

            builder.MoveToBookmark(firstBbookmark.Name);
            builder.Font.HighlightColor = Color.Yellow;
            builder.Writeln(firstBbookmark.Name);

            var savedFileName = newFilePath + newFileName;
            endorsement.Save(savedFileName, SaveFormat.Pdf);
            return savedFileName;
        }

        // Use an iterator and a visitor to print info of every bookmark in the collection.
        private static void PrintAllBookmarkInfo(BookmarkCollection bookmarks)
        {
            BookmarkInfoPrinter bookmarkVisitor = new BookmarkInfoPrinter();

            // Get each bookmark in the collection to accept a visitor that will print its contents.
            using (IEnumerator<Bookmark> enumerator = bookmarks.GetEnumerator())
            {
                while (enumerator.MoveNext())
                {
                    Bookmark currentBookmark = enumerator.Current;

                    if (currentBookmark != null)
                    {
                        currentBookmark.BookmarkStart.Accept(bookmarkVisitor);
                        currentBookmark.BookmarkEnd.Accept(bookmarkVisitor);

                        Console.WriteLine(currentBookmark.BookmarkStart.GetText());
                    }
                }
            }
        }

        // Prints contents of every visited bookmark to the console.
        public class BookmarkInfoPrinter : DocumentVisitor
        {
            public override VisitorAction VisitBookmarkStart(BookmarkStart bookmarkStart)
            {
                Console.WriteLine($"BookmarkStart name: \"{bookmarkStart.Name}\", Contents: \"{bookmarkStart.Bookmark.Text}\"");
                return VisitorAction.Continue;
            }

            public override VisitorAction VisitBookmarkEnd(BookmarkEnd bookmarkEnd)
            {
                Console.WriteLine($"BookmarkEnd name: \"{bookmarkEnd.Name}\"");
                return VisitorAction.Continue;
            }
        }
        #endregion        

        #region GroupDoc.Viewer Code
        //Stream stream = GetPageStream();
        //string uSubString = "_____________";
        ////Stream stream = GetPageStream();
        //// convert stream to string
        //StreamReader reader = new StreamReader(stream);
        //string text = reader.ReadToEnd();

        ////int index = text.IndexOf(uSubString, 0);

        //string subStringPositions = "";
        //int position = 0;

        //if (text.IndexOf(uSubString, position) == -1)
        //{
        //    //Console.WriteLine("Your sub-string was not found in your string.\n");
        //    //return;
        //}
        //if (String.IsNullOrEmpty(uSubString))
        //    throw new ArgumentException("the string to find may not be empty", uSubString);
        //List<int> indexes1 = new List<int>();
        //for (int index1 = 0; ; index1 += uSubString.Length)
        //{
        //    index1 = text.IndexOf(uSubString, index1);
        //    indexes1.Add(index1);
        //}
        ////List<int> indexes = "fooStringfooBar".AllIndexesOf("foo");
        //while (position < text.Length)
        //{
        //    position += text.IndexOf(uSubString, position);
        //    subStringPositions += Convert.ToString(position) + ", ";
        //}
        //File(stream, "text/html");

        //private Stream GetPageStream()
        //{
        //    MemoryStream outputStream = new MemoryStream();

        //    //string fileName = "sample.pdf";
        //    string fileName = "sample.docx";
        //    FileType fileType = FileType.FromExtension(Path.GetExtension(fileName));

        //    using (Viewer viewer = new Viewer(() => GetSourceFileStream(fileName), () => new GroupDocs.Viewer.Options.LoadOptions(fileType)))
        //    {
        //        HtmlViewOptions Options = HtmlViewOptions.ForEmbeddedResources(
        //            (pageNumber) => outputStream,
        //            (pageNumber, pageStream) => { });
        //        viewer.View(Options);
        //    }

        //    outputStream.Position = 0;

        //    return outputStream;
        //}

        //private Stream GetSourceFileStream(string fileName) =>
        //    new MemoryStream(GetSourceFileBytesFromDb(fileName));

        ////TODO: Pull the data from the DB
        //private byte[] GetSourceFileBytesFromDb(string fileName) =>
        //    System.IO.File.ReadAllBytes(fileName);


        // PUT: api/UndFormVersions/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        #endregion

        [HttpPut("{id}")]
        public async Task<IActionResult> PutUndFormVersion(int id, UndFormVersion undFormVersion)
        {
            if (id != undFormVersion.FormVersionId)
            {
                return BadRequest();
            }

            _context.Entry(undFormVersion).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UndFormVersionExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/UndFormVersions
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<UndFormVersion>> PostUndFormVersion(UndFormVersion undFormVersion)
        {
            _context.UndFormVersion.Add(undFormVersion);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUndFormVersion", new { id = undFormVersion.FormVersionId }, undFormVersion);
        }

        // DELETE: api/UndFormVersions/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUndFormVersion(int id)
        {
            var undFormVersion = await _context.UndFormVersion.FindAsync(id);
            if (undFormVersion == null)
            {
                return NotFound();
            }

            _context.UndFormVersion.Remove(undFormVersion);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool UndFormVersionExists(int id)
        {
            return _context.UndFormVersion.Any(e => e.FormVersionId == id);
        }
    }
}
