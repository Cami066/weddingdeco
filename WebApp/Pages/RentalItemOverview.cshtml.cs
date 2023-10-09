using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using BusinessLogicLayer;
using SharedClassesLibrary;

namespace WebApp.Pages
{
    public class RentalItemOverviewModel : PageModel
    {
        private readonly IRentalItemManager _rentalItemManager;

        public RentalItemOverviewModel(IRentalItemManager rentalItemManager)
        {
            _rentalItemManager = rentalItemManager;
        }

        public List<RentalItemDTO> RentalItems { get; set; } = new List<RentalItemDTO>();
        public List<string> Categories { get; set; }

        public void OnGet(string category)
        {
            RentalItems = _rentalItemManager.GetAllRentalItems(category);
            Categories = _rentalItemManager.GetAllCategories();
        }
    }
}
