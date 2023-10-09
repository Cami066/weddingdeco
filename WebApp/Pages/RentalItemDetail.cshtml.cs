using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SharedClassesLibrary;
using BusinessLogicLayer;

namespace WebApp.Pages
{
    public class RentalItemDetailModel : PageModel
    {
        private readonly IRentalItemManager _rentalItemManager;

        public RentalItemDetailModel(IRentalItemManager rentalItemManager)
        {
            _rentalItemManager = rentalItemManager;
        }

        public RentalItemDTO RentalItem { get; set; }

        public List<DateTime> UnavailableDates { get; set; }

        public List<DateTime> AvailableDates { get; set; }

        public IActionResult OnGet(int ItemID)
        {
            RentalItem = _rentalItemManager.GetRentalItemById(ItemID);

            if (RentalItem == null)
            {
                return NotFound();
            }

            // Calculate available dates.
            AvailableDates = _rentalItemManager.GetAvailableDatesForRentalItem(ItemID, DateTime.Today, DateTime.Today.AddMonths(1));

            // Initialize UnavailableDates here with appropriate logic to fetch unavailable dates.
            UnavailableDates = _rentalItemManager.GetUnavailableDatesForRentalItem(ItemID, DateTime.Today, DateTime.Today.AddMonths(1));

            return Page();
        }
    }
}
