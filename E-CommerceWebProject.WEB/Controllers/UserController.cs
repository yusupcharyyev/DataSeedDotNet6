using E_CommerceWebProject.DAL.Repositories.Interfaces.Concrete;
using E_CommerceWebProject.Models.Entities.Concrete;
using E_CommerceWebProject.Models.Enums;
using E_CommerceWebProject.WEB.Models.DTOs;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace E_CommerceWebProject.WEB.Controllers
{
    public class UserController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly IUserRepository _UserRepository;

        public UserController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager, IUserRepository UserRepository)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _UserRepository = UserRepository;
        }
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginDTO loginDTO)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    IdentityUser identityUser = await _userManager.FindByEmailAsync(loginDTO.Mail);

                    User user = _UserRepository.GetDefault(a => a.IdentityId == identityUser.Id);

                    if (identityUser != null)
                    {
                        await _signInManager.SignOutAsync(); 
                        Microsoft.AspNetCore.Identity.SignInResult result = await _signInManager.PasswordSignInAsync(identityUser, loginDTO.Password, true, true);

                        if (result.Succeeded && user.Statu != Statu.Passive)
                        {
                            string role = (await _userManager.GetRolesAsync(identityUser)).FirstOrDefault();
                            if (role == "Customer")
                            {
                                return RedirectToAction("Index", "Customer", new { area = role });
                            }
                        }
                        else
                        {
                            ModelState.AddModelError("Error", "Hesabınız Aktif Duruma getirilmemiş veya girilen bilgiler hatalı");
                        }
                    }
                }
            }
            catch (Exception)
            {
                ModelState.AddModelError("Error", "Lütfen bilgileri doğru giriniz");
            }

            return View(loginDTO);
        }
    }
}
