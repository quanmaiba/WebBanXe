using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebBanXe.Context;
using WebBanXe.Models;

namespace WebBanXe.Controllers
{
    public class HangXesController : Controller
    {
        private readonly WebContext _context;

        public HangXesController(WebContext context)
        {
            _context = context;
        }

        // GET: HangXes
        public async Task<IActionResult> Index()
        {
            return View(await _context.HangXes.ToListAsync());
        }

        public IActionResult GetDongXe()
        {
            var classes = new List<DongXe>();

            try
            {
                classes = (from c in _context.DongXes
                           select c).ToList();
            }
            catch (Exception ex)
            {

            }

            return new JsonResult(new { response = classes, status = 1 });  //
        }


        public JsonResult Gets()
        {
            try
            {
                var draw = HttpContext.Request.Form["draw"].FirstOrDefault();
                // Skiping number of Rows count  
                var start = Request.Form["start"].FirstOrDefault();
                // Paging Length 10,20  
                var length = Request.Form["length"].FirstOrDefault();
                // Sort Column Name  
                var sortColumn = Request.Form["columns[" + Request.Form["order[0][column]"].FirstOrDefault() + "][name]"].FirstOrDefault();
                // Sort Column Direction ( asc ,desc)  
                var sortColumnDirection = Request.Form["order[0][dir]"].FirstOrDefault();
                // Search Value from (Search box)  
                var searchValue = Request.Form["search[value]"].FirstOrDefault().ToLower();

                //Paging Size (10,20,50,100)  
                int pageSize = length != null ? Convert.ToInt32(length) : 0;
                int skip = start != null ? Convert.ToInt32(start) : 0;
                int recordsTotal = 0;

                var hangxe = _context.HangXes.ToList();

                //Sorting  
                if (!(string.IsNullOrEmpty(sortColumn) && string.IsNullOrEmpty(sortColumnDirection)))
                {
                    var prop = GetProperty(sortColumn);
                    if (sortColumnDirection == "asc")
                    {
                        hangxe = hangxe.OrderBy(prop.GetValue).ToList();
                    }
                    else
                    {
                        hangxe = hangxe.OrderByDescending(prop.GetValue).ToList();
                    }
                }
                //Search  
                if (!string.IsNullOrEmpty(searchValue))
                {
                    hangxe = (from e in _context.HangXes
                              where e.TenHangXe.ToLower().Contains(searchValue)
                              select e).ToList();
                }

                //total number of rows count   
                recordsTotal = hangxe.Count();
                //Paging   
                var data = hangxe.Skip(skip).Take(pageSize).ToList();
                //Returning Json Data  
                return Json(new { draw = draw, recordsFiltered = recordsTotal, recordsTotal = recordsTotal, data = data });

            }
            catch (Exception)
            {
                throw;
            }
        }

        private PropertyInfo GetProperty(string name)
        {
            var properties = typeof(HangXe).GetProperties();
            PropertyInfo prop = null;
            foreach (var item in properties)
            {
                if (item.Name.ToLower().Equals(name.ToLower()))
                {
                    prop = item;
                    break;
                }
            }
            return prop;
        }

        // GET: HangXes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hangXe = await _context.HangXes
                .FirstOrDefaultAsync(m => m.HangXeId == id);
            if (hangXe == null)
            {
                return NotFound();
            }

            return View(hangXe);
        }

        // GET: HangXes/Create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Save([FromBody] HangXe model)
        {
            try
            {
                if (model != null)
                {                 
                    if (ModelState.IsValid)
                    {
                        if (model.HangXeId == 0)
                        {
                            _context.Add(model);
                        }
                        else
                        {
                            _context.Update(model);
                        }                      
                         var result = _context.SaveChanges();

                        if (result > 0)
                        {
                            return new JsonResult(new { 
                                status = 1 ,
                                message = "Thanh Cong"
                            
                            });
                        }
                     
                    }
                }
                return new JsonResult(new
                {
                    status = -1,
                    message = "That Bai"

                });

            }
            catch (Exception ex)
            {
                return new JsonResult(new
                {
                    status = -1,
                    message = "Tao That Bai"

                });
            }
            return new JsonResult(new
            {
                status = -1,
                message = "Tao That Bai"

            });
        }

        // POST: HangXes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(HangXe hangXe)
        {
            if (ModelState.IsValid)
            {
                var files = HttpContext.Request.Form.Files;
                foreach (var Image in files)
                {
                    if (Image != null && Image.Length > 0)
                    {
                        var file = Image;
                        MemoryStream ms = new MemoryStream();
                        file.OpenReadStream().CopyTo(ms);
                        //Models.User.UserModels imageEntity = new Models.User.UserModels()
                        //{
                        //    Img = Convert.ToBase64String(ms.ToArray()),
                        //};
                        //datamax = imageEntity.Img;
                        //hangXe.IMG = Convert.ToBase64String(ms.ToArray());
                    }
                }
                _context.Add(hangXe);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(hangXe);
        }

        // GET: HangXes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new JsonResult(new
                {
                    status = -1,
                    message = "Khong tim Thay"

                });
            }

            var hangXe = await _context.HangXes.FindAsync(id);
            if (hangXe == null)
            {
                return new JsonResult(new
                {
                    status = -1,
                    message = "Khong tim Thay"

                });
            }
            return new JsonResult(new
            {
                response = hangXe,
                status = 1
             
            });
        }

        // GET: HangXes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new JsonResult(new
                {
                    status = -1,
                    message = "Xoa That Bai"

                });
            }
            var hangXe = await _context.HangXes.FindAsync(id);
            _context.HangXes.Remove(hangXe);
            var result = await _context.SaveChangesAsync();

            if (result > 0)
            {
                return new JsonResult(new
                {
                    status = 1,
                    message = "Xoa Thanh Cong"

                });
            }
            return new JsonResult(new
            {
                status = -1,
                message = "Xoa That Bai"

            });
        }

        private bool HangXeExists(int id)
        {
            return _context.HangXes.Any(e => e.HangXeId == id);
        }
    }
}
