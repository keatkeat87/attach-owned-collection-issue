using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Project.Entity;

namespace Project.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public void OnGet(
            [FromServices] ApplicationDbContext db
        )
        {
            // var distributor = db.Distributors.AsTracking().First(); // work perfect.
            var distributor = db.Distributors.AsNoTracking().First();
            //db.Entry(distributor).State = EntityState.Unchanged;  // SaveChanges doesn't generate sql delete query
            db.Attach(distributor); // error when SaveChanges
            distributor.ShippingCenters = new List<StreetAddress> {
                new StreetAddress {
                    City = "22",
                    Street = "22"
                }
            };
            distributor.ShippingCenter = new StreetAddress
            {
                City = "22",
                Street = "22"
            };
            db.SaveChanges();
        }
    }
}
