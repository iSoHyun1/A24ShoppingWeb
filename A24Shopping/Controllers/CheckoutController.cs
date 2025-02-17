using A24Shopping.Models;
using A24Shopping.Repository;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace A24Shopping.Controllers
{
    
    public class CheckoutController : Controller
	{
        private readonly DataContext _dataContext;

        public CheckoutController(DataContext context)
        {
            _dataContext = context;
        }

        public async Task<IActionResult> Checkout()
        {
            // Lấy email của người dùng từ Claims
            var userEmail = User.FindFirstValue(ClaimTypes.Email);
            if(userEmail == null)
            {
                return RedirectToAction("Login", "Account");
            }
            else
            {
                // Tạo mã đơn hàng duy nhất
                var ordercode = Guid.NewGuid().ToString();
                // Tạo đối tượng đơn hàng mới và thiết lập các thuộc tính
                var orderItem = new OrderModel();
                orderItem.OrderCode = ordercode;
                orderItem.UserName = userEmail;
                orderItem.Status = 1;
                orderItem.CreateDate = DateTime.Now;
                _dataContext.Add(orderItem);
                _dataContext.SaveChanges();
                // Lấy giỏ hàng từ phiên làm việc của người dùng
                List<CartItemModel> cartItems = HttpContext.Session.GetJson<List<CartItemModel>>("Cart") ?? new List<CartItemModel>();
                // Duyệt qua từng mặt hàng trong giỏ hàng và tạo chi tiết đơn hàng
                foreach (var cart in cartItems) 
                {
                    var orderdetails = new OrderDetails();
                    orderdetails.UserName = userEmail;
                    orderdetails.OrderCode = ordercode;
                    orderdetails.ProductId = cart.ProductId;
                    orderdetails.Price = cart.Price;
                    orderdetails.Quantity = cart.Quantity;
                    _dataContext.Add(orderdetails);
                    _dataContext.SaveChanges();

                }
                // Xóa giỏ hàng khỏi phiên làm việc của người dùng
                HttpContext.Session.Remove("Cart");
				TempData["success"] = "Checkout thành công, vui lòng chờ duyệt đơn hàng";
                return RedirectToAction("Index", "Cart");
            }
            return View();
        }
    }
}
