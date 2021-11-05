namespace HansAfriqueApi.Entities
{
    public class BasketItem
    {
        public int id { get; set; }
        public string Name { get; set; }
        public string Brand { get; set; }
        public string Vehicle { get; set; }
        public string Supplier { get; set; }
        public decimal Price { get; set; }
        public string PictureULR { get; set; }
        public string PartCategory { get; set; }
        public string PartCode { get; set; }
        public string VehicleModel { get; set; }
        public string PartNumber { get; set; }
    }
}