namespace WebFormAndReport.Server.Models
{
    public class ProductReview
    {
        public string Product { get; set; } = string.Empty;
        public int? GreatReviews { get; set; }
        public int? BadReviews { get; set; }
    }
}

