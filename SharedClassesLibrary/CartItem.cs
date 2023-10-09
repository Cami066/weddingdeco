using System;
namespace SharedClassesLibrary
{
	public class CartItem
	{
        public int CartItemID { get; set; }
        public int Quantity { get; set; }
        public DateTime RentalStartDate { get; set; }
        public DateTime RentalEndDate { get; set; }
    }
}

