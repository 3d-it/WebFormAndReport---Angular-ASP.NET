using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using WebFormAndReport.Server.Models;

[ApiController]
[Route("api/[controller]")]
public class ProductReviewsController : ControllerBase
{
    private readonly IConfiguration _config;
    public ProductReviewsController(IConfiguration config)
    {
        _config = config;
    }

    [HttpGet]
    public IActionResult GetReport()
    {
        var list = new List<ProductReview>();
        var connStr = _config.GetConnectionString("DefaultConnection");

        using var conn = new SqlConnection(connStr);
        using var cmd = new SqlCommand("SELECT * FROM vProductReviews", conn);
        conn.Open();

        using var reader = cmd.ExecuteReader();
        while (reader.Read())
        {
            list.Add(new ProductReview
            {
                Product = reader["Product"].ToString(),
                GreatReviews = Convert.ToInt32(reader["GreatReviews"]),
                BadReviews = Convert.ToInt32(reader["BadReviews"])
            });
        }
        return Ok(list);
    }
}
