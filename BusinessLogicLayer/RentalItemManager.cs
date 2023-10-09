using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;
using SharedClassesLibrary;

namespace BusinessLogicLayer
{
    public class RentalItemManager : IRentalItemManager
    {
        private RentalItemRepository rentalItemRepository;

        public RentalItemManager()
        {
            rentalItemRepository = new RentalItemRepository();
        }

        public List<RentalItemDTO> GetAllRentalItems(string category)
        {
            return rentalItemRepository.GetAllRentalItems(category);
        }

        public List<string> GetAllCategories()
        {
            return rentalItemRepository.GetAllCategories();
        }

        public RentalItemDTO GetRentalItemById(int itemId)
        {
            return rentalItemRepository.GetRentalItemById(itemId);

        }


        public List<DateTime> GetAvailableDatesForRentalItem(int itemId, DateTime startDate, DateTime endDate)
        {
            List<RentalOrder> rentalOrders = rentalItemRepository.GetRentalOrdersByItemId(itemId);

            List<DateTime> unavailableDates = new List<DateTime>();

            foreach (RentalOrder order in rentalOrders)
            {
                if (IsDateRangeOverlapping(startDate, endDate, order.RentalStartDate, order.RentalEndDate))
                {
                    
                    DateTime overlapStart = startDate > order.RentalStartDate ? startDate : order.RentalStartDate;
                    DateTime overlapEnd = endDate < order.RentalEndDate ? endDate : order.RentalEndDate;

                    for (DateTime date = overlapStart.Date; date <= overlapEnd.Date; date = date.AddDays(1))
                    {
                        unavailableDates.Add(date);
                    }
                }
            }

            List<DateTime> availableDates = new List<DateTime>();
            for (DateTime date = startDate.Date; date <= endDate.Date; date = date.AddDays(1))
            {
                if (!unavailableDates.Contains(date))
                {
                    availableDates.Add(date);
                }
            }

            return availableDates;
        }


        private bool IsDateRangeOverlapping(DateTime start1, DateTime end1, DateTime start2, DateTime end2)
        {
            return start1 <= end2 && start2 <= end1;
        }

        private List<RentalOrder> GetRentalOrdersByItemId(int itemId)
        {
            return rentalItemRepository.GetRentalOrdersByItemId(itemId);
        }
        public List<DateTime> GetUnavailableDatesForRentalItem(int itemId, DateTime startDate, DateTime endDate)
        {
            List<RentalOrder> rentalOrders = rentalItemRepository.GetRentalOrdersByItemId(itemId);

            List<DateTime> unavailableDates = new List<DateTime>();

            foreach (RentalOrder order in rentalOrders)
            {
                if (IsDateRangeOverlapping(startDate, endDate, order.RentalStartDate, order.RentalEndDate))
                {
                   
                    DateTime overlapStart = startDate > order.RentalStartDate ? startDate : order.RentalStartDate;
                    DateTime overlapEnd = endDate < order.RentalEndDate ? endDate : order.RentalEndDate;

                    for (DateTime date = overlapStart.Date; date <= overlapEnd.Date; date = date.AddDays(1))
                    {
                        unavailableDates.Add(date);
                    }
                }
            }

            return unavailableDates;
        }

    }
}
