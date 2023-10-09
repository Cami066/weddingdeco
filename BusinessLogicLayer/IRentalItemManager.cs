using System;
using SharedClassesLibrary;

namespace BusinessLogicLayer
{
    public interface IRentalItemManager
    {
        List<RentalItemDTO> GetAllRentalItems(string category);
        List<string> GetAllCategories();
        RentalItemDTO GetRentalItemById(int itemID);
        List<DateTime> GetAvailableDatesForRentalItem(int itemId, DateTime startDate, DateTime endDate);
        List<DateTime> GetUnavailableDatesForRentalItem(int itemID, DateTime today, DateTime dateTime);
    }
}

