namespace HansAfriqueApi.Dto
{
    public class PicturesDto
    {
        public int id { get; set; }
        public string Url { get; set; }
        public string IsMain { get; set; }
        public int Productid { get; set; }
        public ProductDto ProductDto { get; set; }
    }
}