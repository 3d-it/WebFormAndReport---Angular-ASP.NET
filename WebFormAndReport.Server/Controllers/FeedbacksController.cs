using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using WebFormAndReport.Server.Data;
using WebFormAndReport.Server.Models;

[ApiController]
[Route("api/[controller]")]
public class FeedbacksController : ControllerBase
{
    private readonly IConfiguration _config;

    public FeedbacksController(IConfiguration config)
    {
        _config = config;
    }

    [HttpPost]
    public IActionResult PostFeedback([FromBody] Feedback feedback)
    {
        if (feedback == null)
            return BadRequest("Invalid feedback data.");

        var connStr = _config.GetConnectionString("DefaultConnection");

        using var conn = new SqlConnection(connStr);
        conn.Open();

        var cmd = new SqlCommand(
            "INSERT INTO Feedbacks (Name, Email, Product, Message, SubmittedAt) VALUES (@Name, @Email, @Product, @Message, @SubmittedAt)",
            conn);

        cmd.Parameters.AddWithValue("@Name", feedback.Name);
        cmd.Parameters.AddWithValue("@Email", feedback.Email);
        cmd.Parameters.AddWithValue("@Product", feedback.Product);
        cmd.Parameters.AddWithValue("@Message", feedback.Message);
        cmd.Parameters.AddWithValue("@SubmittedAt", DateTime.Now);

        cmd.ExecuteNonQuery();

        return Ok(new { message = "Feedback submitted successfully" });
    }
}

