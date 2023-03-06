// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
#nullable disable

using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using AirBNB.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AirBNB.Areas.Identity.Pages.Account.Manage
{
    public class IndexModel : PageModel
    {
        private readonly UserManager<AplicationUser> _userManager;
        private readonly SignInManager<AplicationUser> _signInManager;

        public IndexModel(
            UserManager<AplicationUser> userManager,
            SignInManager<AplicationUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        /// <summary>
        ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
        ///     directly from your code. This API may change or be removed in future releases.
        /// </summary>

        /// <summary>
        ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
        ///     directly from your code. This API may change or be removed in future releases.
        /// </summary>
        [TempData]
        public string StatusMessage { get; set; }

        /// <summary>
        ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
        ///     directly from your code. This API may change or be removed in future releases.
        /// </summary>
        [BindProperty]
        public InputModel Input { get; set; }

        /// <summary>
        ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
        ///     directly from your code. This API may change or be removed in future releases.
        /// </summary>
        public class InputModel
        {
            /// <summary>
            ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
            ///     directly from your code. This API may change or be removed in future releases.
            /// </summary>
           	[Required]
            //[MaxLength(11),MinLength(11)]
            [RegularExpression("^1[0125][0-9]{8}$", ErrorMessage = "enter a valid phone number")]

            public int Phone_Number { get; set; }
            [Required]
            [MinLength(3), MaxLength(15)]
            public string First_Name { get; set; }
            [Required]
            [MinLength(3), MaxLength(15)]
            public string Last_Name { get; set; }
            [Required]
            [EmailAddress]
            public string Email { get; set; }
            [Required]
            [MaxLength(20)]
            public string City { get; set; }

        }
        private async Task LoadAsync(AplicationUser user)
        {

            int Phone_Number = user.Phone_Number;
            var Email = user.Email;
            var city = user.City;
            var fname = user.First_Name;
            var lname = user.Last_Name;
            Input = new InputModel
            {
                Phone_Number = Phone_Number,
                First_Name = fname,
                Last_Name = lname,
                Email = Email,
                City = city,

            };

        }

        public async Task<IActionResult> OnGetAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            await LoadAsync(user);
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            if (!ModelState.IsValid)
            {
                await LoadAsync(user);
                return Page();
            }

            int Phone_Number = user.Phone_Number;
            var Email = user.Email;
            var city = user.City;
            var fname = user.First_Name;
            var lname = user.Last_Name;
            if (Input.Phone_Number != Phone_Number)
            {
                user.Phone_Number = Input.Phone_Number;
                await _userManager.UpdateAsync(user);
            }
            if (Input.First_Name != fname)
            {
                user.First_Name = Input.First_Name;
                await _userManager.UpdateAsync(user);
            }
            if (Input.Last_Name != lname)
            {
                user.Last_Name = Input.Last_Name;
                await _userManager.UpdateAsync(user);
            }
            if (Input.Email != Email)
            {
                user.Email = Input.Email;
                await _userManager.UpdateAsync(user);
            }
            if (Input.City != city)
            {
                user.City = Input.City;
                await _userManager.UpdateAsync(user);
            }


            await _signInManager.RefreshSignInAsync(user);
            StatusMessage = "Your profile has been updated";
            return RedirectToPage();
        }
    }
}
