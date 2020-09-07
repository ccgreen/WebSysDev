using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebSysDev.Data;
using WebSysDev.Models;

namespace WebSysDev.Pages.Rooms
{
    public class IndexModel : PageModel
    {
        private readonly WebSysDev.Data.ApplicationDbContext _context;

        public IndexModel(WebSysDev.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Room> Room { get;set; }

        public async Task OnGetAsync()
        {
            Room = await _context.Room.ToListAsync();
        }
    }
}
