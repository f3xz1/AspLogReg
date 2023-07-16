using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Reflection.Metadata.Ecma335;

namespace logform.Pages
{
    public class regformModel : PageModel
    {
        [BindProperty]
        public string Name { get; set; }
        [BindProperty]
        public string Surname { get; set; }
        [BindProperty]
        public string Email { get; set; }
        [BindProperty]
        public string Password1 { get; set; }
        [BindProperty]
        public string Password2 { get; set; }
        
        

        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {

            if (ModelState.IsValid)
            {
                Console.WriteLine(Email);
                Console.WriteLine(Name);
                Console.WriteLine(Surname);
                Console.WriteLine(Password1);
                Console.WriteLine(Password2);
                if(Password1!= Password2)
                {

                    User user = new()
                    {
                        Email = Email,
                        Name = Name,
                        Surname = Surname,
                        Password = Password1
                    };

                    try
                    {
                        using (AspLogRegContext db = new())
                        {
                            db.Users.AddAsync(user);
                        }
                    }
                    catch(Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                        return RedirectToPage("/Error");
                    }
                }
            }

            return Page();
        }
    }
}

