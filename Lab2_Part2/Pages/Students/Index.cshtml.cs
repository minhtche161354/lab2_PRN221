using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Lab2_Part2.Data;
using Lab2_Part2.Models;

namespace Lab2_Part2.Pages.Students
{
    public class IndexModel : PageModel
    {
        private readonly Lab2_Part2.Data.SchoolContext _context;
        private readonly IConfiguration _configuration;

        public IndexModel(Lab2_Part2.Data.SchoolContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }
        public string NameSort { get; set; }
        public string DateSort { get; set; }
        public string CurrentFilter { get; set; }
        public string CurrentSort { get; set; }
        public PaginatedList<Student> Students { get; set; }

        public async Task OnGetAsync(string sortOrder, string currentFilter, string searchString, int? pageIndex)
        {
            CurrentSort = sortOrder;
            NameSort = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            DateSort = sortOrder == "Date" ? "date_desc" : "Date";
            if(searchString != null)
            {
                pageIndex = 1;
            }
            else
            {
                searchString = currentFilter;
            }
            IQueryable<Student> stuIQ = from s in _context.Students select s;
            if (!String.IsNullOrEmpty(searchString))
            {
                stuIQ = stuIQ.Where(s => s.LastName.Contains(searchString)||s.FirstMidName.Contains(searchString));
            }
            switch (sortOrder)
            {
                case "name_desc":
                    {
                        stuIQ = stuIQ.OrderByDescending(s => s.LastName);
                        break;
                    }
                case "Date":
                    {
                        stuIQ = stuIQ.OrderBy(x => x.EnrollmentDate);
                        break;
                    }
                case "date_desc":
                    {
                        stuIQ = stuIQ.OrderByDescending(x => x.EnrollmentDate);
                        break;
                    }
                    default: 
                    {
                        stuIQ = stuIQ.OrderBy(s => s.LastName);
                        break;
                    }
            }

            var pageSize = _configuration.GetValue("PageSize", 4);
            Students = await PaginatedList<Student>.CreateAsync(stuIQ.AsNoTracking(),pageIndex??1, pageSize);
        }
    }
}
