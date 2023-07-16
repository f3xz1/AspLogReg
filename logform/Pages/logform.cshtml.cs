using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace logform.Pages
{
    public class logformModel : PageModel
    {
        [BindProperty]
        public string Email { get; set; }
        [BindProperty]
        public string Password { get; set; }
        public void OnGet()
        {

        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (ModelState.IsValid)
            {
                Console.WriteLine(Email);
                Console.WriteLine(Password);

                using (AspLogRegContext db = new())
                {
                    User user = await db.Users.Where(x=>x.Email == Email).FirstOrDefaultAsync();
                    if(user!= null && user.Password == Password)
                    {
                        return RedirectToPage("/Privacy");
                    }
                }

                return RedirectToPage("/Index"); 
            }

            return Page();
        }
    }
}
