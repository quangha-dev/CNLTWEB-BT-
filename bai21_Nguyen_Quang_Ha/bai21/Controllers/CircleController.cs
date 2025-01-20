using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace bai21.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CircleController : ControllerBase
    {

        [HttpGet("cv_dt")]
        public IActionResult TinhChuViDienTichDuongKinh(double rr) // rr là bán kính
        {
            if (rr <= 0)
            {
                return BadRequest("Bán kính phải dương");
            }

            double cv = 3.14 * 2 * rr;  // Chu vi
            double dt = 3.14 * rr * rr; // Diện tích
            double dk = 2 * rr;         // Đường kính

            var jsonStr = new
            {
                dien_tich = dt,
                chu_vi = cv,
                duong_kinh = dk
            };

            return Ok(jsonStr);
        }
    }
}