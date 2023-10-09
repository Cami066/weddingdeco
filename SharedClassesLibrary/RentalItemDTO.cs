using System;
namespace SharedClassesLibrary
{
    public class RentalItemDTO
    {
        public int ItemID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal RentalPrice { get; set; }
        public string Category { get; set; }
        public bool Availability { get; set; }
        public string ImageUrl { get; set; }
    }
}

