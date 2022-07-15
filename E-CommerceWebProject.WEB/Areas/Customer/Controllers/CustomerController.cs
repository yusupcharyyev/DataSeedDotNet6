using E_CommerceWebProject.DAL.Repositories.Interfaces.Concrete;
using E_CommerceWebProject.WEB.Areas.Customer.Models.DTOs;
using Microsoft.AspNetCore.Mvc;
using E_CommerceWebProject.Models.Enums;
using E_CommerceWebProject.Models.Entities.Concrete;
using Microsoft.AspNetCore.Identity;

namespace E_CommerceWebProject.WEB.Areas.Customer.Controllers
{
    [Area("Customer")]
    [Route("Customer/[controller]")]
    public class CustomerController : Controller
    {
        private readonly IProductRepository _productRepository;
        private readonly UserManager<IdentityUser> _userManager;

        public CustomerController(IProductRepository productRepository, UserManager<IdentityUser> userManager)
        {
           _productRepository = productRepository;
            _userManager = userManager;
        }
        public async Task<IActionResult> Index()
        {
            IdentityUser identityUser = await _userManager.GetUserAsync(User);
            string role = (await _userManager.GetRolesAsync(identityUser)).FirstOrDefault();
            List<GetAllProductDTO> getAllProductDTOs = _productRepository.GetByDefaults(

                selector: a => new GetAllProductDTO
                {
                    ProductID = a.ID,
                    Name = a.Name,
                    Code = a.Code,
                    Price = a.Price,
                    DiscountPrice = a.Price,
                    DiscountPercent = (double)a.DiscountPercent,
                    UserID = a.UserID,
                    ProductColors = a.ProductColors,
                    UserRole=role
                },
                expression: a => a.Statu != Statu.Passive
                );
            return View(getAllProductDTOs);
        }
    }
}
