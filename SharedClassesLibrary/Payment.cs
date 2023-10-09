using System;
namespace SharedClassesLibrary
{
	public class Payment
	{
        public int PaymentID { get; set; }
        public int OrderID { get; set; }
        public decimal Amount { get; set; }
        public PaymentMethod PaymentMethod { get; set; }
        public DateTime PaymentDate { get; set; }
        public string TransactionID { get; set; }
        public int CartID { get; set; }
        public int CustomerID { get; set; }
        public List<CartItem> Items { get; set; }
    }
}

