using System;
using SharedClassesLibrary;

namespace DataAccessLayer
{
    public interface IRentalItemRepository
    {
        List<RentalOrder> GetRentalOrdersByItemId(int itemId);
    }
}

