using System;
namespace SharedClassesLibrary
{
	public class RentalOrder
	{
        public int RentalOrderID { get; set; }
        public int CustomerID { get; set; }
        public List<RentalOrderItem> RentalItems { get; set; }
        public DateTime RentalStartDate { get; set; }
        public DateTime RentalEndDate { get; set; }
        public decimal TotalCost { get; set; }
        public OrderStatus Status { get; set; }
        public Payment Payment { get; set; }

    }
}

