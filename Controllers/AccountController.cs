using AudioBooksApp.Data;
using AudioBooksApp.Data.Static;
using AudioBooksApp.Data.ViewModels;
using AudioBooksApp.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net.Mail;
using System.Net;
using Microsoft.AspNetCore.Authorization;

namespace eTickets.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly AppDbContext _context;
        public AccountController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, AppDbContext context)
        {
            _userManager= userManager;
            _signInManager= signInManager;
            _context= context;
        }

        [Authorize(Roles = UserRoles.Admin)]
        public async Task<IActionResult> Users()
        {
            var users = await _context.Users.ToListAsync();
            return View(users);
        }

        public IActionResult Login()
        {
            var response = new LoginVM();
            return View(response);
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginVM loginVM)
        {
            if (!ModelState.IsValid) return View(loginVM);

            var user = await _userManager.FindByEmailAsync(loginVM.EmailAddress);
            if (user != null)
            {
                var passwordCheck = await _userManager.CheckPasswordAsync(user, loginVM.Password);
                if (passwordCheck)
                {
                    var result = await _signInManager.PasswordSignInAsync(user, loginVM.Password, false, false);
                    if (result.Succeeded)
                    {
                        return RedirectToAction("Index", "Home");
                    }
                }
                TempData["Error"] = "Wrong credentials. Please, try again!";
                return View(loginVM);
            }

            TempData["Error"] = "Wrong credentials. Please, try again!";
            return View(loginVM);
        }


        public IActionResult Register()
        {
            var response = new RegisterVM(); 
            return View(response);
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterVM registerVM)
        {
            if (!ModelState.IsValid) return View(registerVM);

            var user = await _userManager.FindByEmailAsync(registerVM.EmailAddress);
            if (user != null)
            {
                TempData["Error"] = "This email address is already in use";
                return View(registerVM);
            }

            var newUser = new ApplicationUser()
            {
                FullName = registerVM.FullName,
                Email = registerVM.EmailAddress,
                UserName = GenerateUsername(registerVM.EmailAddress)
            };
            var newUserResponse = await _userManager.CreateAsync(newUser, registerVM.Password);

            if (newUserResponse.Succeeded)
            {
                await _userManager.AddToRoleAsync(newUser, UserRoles.User);
                string toAddress = registerVM.EmailAddress;
                string subject = "Welcome to our website!";
                string body = "Dear " + registerVM.FullName + ",\n\nThank you for signing up on our website!";
                SendEmail(toAddress, subject, body);
                
            }
            return View("RegisterCompleted");

        }

        public static string GenerateUsername(string emailAddress)
        {
            int index = emailAddress.IndexOf('@');

            if (index != -1)
            {
                string username = emailAddress.Substring(0, index);
                return username;
            }

            return null; // În cazul în care adresa de email nu conține caracterul '@'
        }

        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }


        public void SendEmail(string toAddress, string subject, string body)
        {
           
            // Set the SMTP server details
            SmtpClient client = new SmtpClient();
            client.Host = "smtp.gmail.com";
            client.Port = 587;
            client.EnableSsl = true;
            client.UseDefaultCredentials = false;
            client.Credentials = new NetworkCredential("tudorcristian.gheorghita@ulbsibiu.ro", "jqmifsfdshkupzlu");

            // Create a message to send
            MailMessage message = new MailMessage();
            message.From = new MailAddress("tudorcristian.gheorghita@ulbsibiu.ro");
            message.To.Add(toAddress);
            message.Subject = subject;
            message.Body = body;

            // Send the message
            client.Send(message);
        }

        public IActionResult AccessDenied(string ReturnUrl)
        {
            return View();
        }

    }
}
