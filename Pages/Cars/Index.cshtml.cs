﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Proiect.Data;
using Proiect.Models;

namespace Proiect.Pages.Cars
{
    public class IndexModel : PageModel
    {
        private readonly Proiect.Data.ProiectContext _context;

        public IndexModel(Proiect.Data.ProiectContext context)
        {
            _context = context;
        }

        public IList<Car> Car { get; set; }
        public CarData CarD { get; set; }
        public int CarID { get; set; }
        public int CategoryID { get; set; }

        public async Task OnGetAsync(int ? id, int? categoryID)
        {
            CarD = new CarData();

            CarD.Cars = await _context.Car.Include(b => b.Producer).Include(b => b.CarCategories).ThenInclude(b => b.Category).AsNoTracking().OrderBy(b => b.Model).ToListAsync();
            
            if (id != null)
            {
                CarID = id.Value;
                Car car = CarD.Cars.Where(i => i.ID == id.Value).Single();
                CarD.Categories = car.CarCategories.Select(s => s.Category);
            }
        }
    }
}
