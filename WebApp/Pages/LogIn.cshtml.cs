using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using SharedClassesLibrary;
using DataAccessLayer;
using BusinessLogicLayer;

namespace WebApp.Pages
{
    public class LoginModel : PageModel
    {
        
        public LoginModel()
        {
          
        }

        //[BindProperty]
        //[Required]
        //[EmailAddress]
        //public string? Email { get; set; }

        //[BindProperty]
        //[Required]
        //[DataType(DataType.Password)]
        //public string Password { get; set; }

        //[TempData]
        //public string ErrorMessage { get; set; }

        public void OnGet()
        {
        }

       
    }
}
