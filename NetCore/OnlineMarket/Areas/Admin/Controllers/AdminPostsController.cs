using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using AspNetCoreHero.ToastNotification.Abstractions;
using ClosedXML.Excel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using OnlineMarket.Helper;
using OnlineMarket.Models;
using PagedList.Core;

namespace OnlineMarket.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AdminPostsController : Controller
    {
        private readonly OnlineShopContext _context;
        public INotyfService _notyfService { get; }
        public AdminPostsController(OnlineShopContext context, INotyfService notifyfService)
        {
            _context = context;
            _notyfService = notifyfService;
        }

        // GET: Admin/AdminPosts
        public IActionResult Index(int? page)
        {

            
            var collection = _context.Posts.AsNoTracking().ToList();
            foreach(var item in collection)
            {
                if(item.CreateDate == null)
                {
                    item.CreateDate = DateTime.Now;
                    _context.Update(item);
                    _context.SaveChanges();
                  
                }
            }

            var pageNumber = page == null || page <= 0 ? 1 : page.Value;
            var pageSize = 20;
            var lsPosts = _context.Posts.AsNoTracking().OrderByDescending(x => x.PostId);
            PagedList<Post> models = new PagedList<Post>(lsPosts, pageNumber, pageSize);
            ViewBag.CurrentPage = pageNumber;
            return View(models);
        }
        public IActionResult ExportExcel()
        {
            using (var workbook = new XLWorkbook())
            {
                var ws = workbook.Worksheets.Add("Post");
                ws.Range("A1:E1").Merge();
                ws.Cell(1, 1).Value = "Report";
                ws.Cell(1, 1).Style.Font.Bold = true;
                ws.Cell(1, 1).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                ws.Cell(1, 1).Style.Font.FontSize = 30;


                // header
                ws.Cell(4,1).Value = "PostID";
                ws.Cell(4,2).Value = "Title";
                ws.Cell(4,3).Value = "Thumb";
                ws.Cell(4,4).Value = "CreateDate";
                ws.Cell(4,5).Value = "Alias";
                ws.Range("A4:E4").Style.Fill.BackgroundColor = XLColor.Alizarin;

                // Connection
                System.Data.DataTable dt = new System.Data.DataTable();
                SqlConnection con = new SqlConnection("Server=.;Database=BookStore;Integrated Security=true;");
                SqlDataAdapter ad = new SqlDataAdapter("select * from Posts",con);
                ad.Fill(dt);
                int i = 5;
                foreach (System.Data.DataRow row in dt.Rows) 
                {
                    ws.Cell(i, 1).Value = row[0].ToString();
                    ws.Cell(i, 2).Value = row[1].ToString();
                    ws.Cell(i, 3).Value = row[2].ToString();
                    ws.Cell(i, 4).Value = row[3].ToString();
                    ws.Cell(i, 5).Value = row[4].ToString();
                    i++;
                }
                i--;
                ws.Cells("A4:E" + 1).Style.Border.BottomBorder = XLBorderStyleValues.Thin;
                ws.Cells("A4:E" + 1).Style.Border.TopBorder = XLBorderStyleValues.Thin;
                ws.Cells("A4:E" + 1).Style.Border.LeftBorder = XLBorderStyleValues.Thin;
                ws.Cells("A4:E" + 1).Style.Border.RightBorder = XLBorderStyleValues.Thin;


                using(var stream = new MemoryStream())
                {
                    workbook.SaveAs(stream);
                    var content = stream.ToArray();
                    return File(
                        content,
                        "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",
                        "Post.xlsx"
                        );
                }

            }
        }
        // GET: Admin/AdminPosts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var post = await _context.Posts
                .FirstOrDefaultAsync(m => m.PostId == id);
            if (post == null)
            {
                return NotFound();
            }

            return View(post);
        }

        // GET: Admin/AdminPosts/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/AdminPosts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PostId,Title,Scontents,Contents,Thumb,Published,Alias,CreateDate,Author,AccountId,Tags,CartId,IsHot,IsNewFeed,MetaKey,MetaDesc,Views")] Post post, Microsoft.AspNetCore.Http.IFormFile fThumb)
        {
            if (ModelState.IsValid)
            {
                if (fThumb != null)
                {
                    string extension = Path.GetExtension(fThumb.FileName);
                    string image = Utilities.SEOUrl(post.Title) + extension;
                    post.Thumb = await Utilities.UploadFile(fThumb, @"news", image.ToLower());

                }
                if (string.IsNullOrEmpty(post.Thumb))
                {
                    post.Thumb = "default.jpg";
                }

                post.Alias = Utilities.SEOUrl(post.Title);
                post.CreateDate = DateTime.Now;

                _context.Add(post);
                await _context.SaveChangesAsync();
                _notyfService.Success("Tạo bài thành công");
                return RedirectToAction(nameof(Index));
            }
            return View(post);
        }

        // GET: Admin/AdminPosts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var post = await _context.Posts.FindAsync(id);
            if (post == null)
            {
                return NotFound();
            }
            return View(post);
        }

        // POST: Admin/AdminPosts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PostId,Title,Scontents,Contents,Thumb,Published,Alias,CreateDate,Author,AccountId,Tags,CartId,IsHot,IsNewFeed,MetaKey,MetaDesc,Views")] Post post, Microsoft.AspNetCore.Http.IFormFile fThumb)
        {
            if (id != post.PostId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    if (fThumb != null)
                    {
                        string extension = Path.GetExtension(fThumb.FileName);
                        string image = Utilities.SEOUrl(post.Title) + extension;
                        post.Thumb = await Utilities.UploadFile(fThumb, @"news", image.ToLower());

                    }
                    if (string.IsNullOrEmpty(post.Thumb))
                    {
                        post.Thumb = "default.jpg";
                    }

                    post.Alias = Utilities.SEOUrl(post.Title);

                    _context.Update(post);
                    await _context.SaveChangesAsync();
                    _notyfService.Success("Chỉnh sửa bài thành công");
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PostExists(post.PostId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(post);
        }

        // GET: Admin/AdminPosts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var post = await _context.Posts
                .FirstOrDefaultAsync(m => m.PostId == id);
            if (post == null)
            {
                return NotFound();
            }

            return View(post);
        }

        // POST: Admin/AdminPosts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var post = await _context.Posts.FindAsync(id);
            _context.Posts.Remove(post);
            await _context.SaveChangesAsync();
            _notyfService.Success("Xóa bài đăng thành công");
            return RedirectToAction(nameof(Index));
        }

        private bool PostExists(int id)
        {
            return _context.Posts.Any(e => e.PostId == id);
        }
    }
}
