// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
#nullable disable

using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Hosting;
using MyStore.Models;
using MyStore.Services;

namespace MyStore.Areas.Identity.Pages.Account.Manage
{
    public class IndexModel : PageModel
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly IUploudService _uploud;
        public string ProfileImagePath { get; set; }

        public IndexModel(
            UserManager<AppUser> userManager,
            SignInManager<AppUser> signInManager,
            IUploudService uploud
            )
        {
            _userManager = userManager;
            _signInManager = signInManager;
            this._uploud = uploud;
        }

        /// <summary>
        ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
        ///     directly from your code. This API may change or be removed in future releases.
        /// </summary>
        public string Username { get; set; }

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
            [Display(Name ="Full Name")]
            public string FullName { get; set; }

            /// <summary>
            ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
            ///     directly from your code. This API may change or be removed in future releases.
            /// </summary>
            [Phone]
            [Display(Name = "Phone number")]
            public string PhoneNumber { get; set; }

            [Display(Name = "Profile image")]
            public IFormFile ProfileImageUrl { get; set; }
            //public string ProfileImagePath { get; internal set; }
        }

        private async Task LoadAsync(AppUser user)
        {
            var userName = await _userManager.GetUserNameAsync(user);
            var phoneNumber = await _userManager.GetPhoneNumberAsync(user);
            var fullName = user.FullName;

            Username = userName;
            ProfileImagePath = user.ProfileImageUrl;

            Input = new InputModel
            {
                PhoneNumber = phoneNumber,
                FullName = fullName
            };
        }
        public AppUser user { get; set; }
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
            user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            if (!ModelState.IsValid)
            {
                await LoadAsync(user);
                return Page();
            }

            var phoneNumber = await _userManager.GetPhoneNumberAsync(user);
            if (Input.PhoneNumber != phoneNumber)
            {
                var setPhoneResult = await _userManager.SetPhoneNumberAsync(user, Input.PhoneNumber);
                if (!setPhoneResult.Succeeded)
                {
                    StatusMessage = "Unexpected error when trying to set phone number.";
                    return RedirectToPage();
                }
            }

            var userProfilePhoto = Input.ProfileImageUrl;

            //if(userProfilePhoto == null)
            //{


            //ProfileImagePath = user.ProfileImageUrl;
            //Input.ProfileImageUrl = user.ProfileImagePath;
            //ModelState.AddModelError("Input.ProfileImageUrl", "Please choose an image");
            //return Page();
            //}


            if (Input.ProfileImageUrl != null)
            {
                try
                {
                    var oldImagePath = user.ProfileImageUrl;

                    user.ProfileImageUrl = _uploud.UploudFile(Input.ProfileImageUrl, "account");

                    // حذف الصورة القديمة
                    if (!string.IsNullOrEmpty(oldImagePath))
                    {
                        var fullPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", oldImagePath);
                        
                        if (System.IO.File.Exists(fullPath))
                        {
                            System.IO.File.Delete(fullPath);
                        }
                    }
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", ex.Message);
                    return Page();
                }
            }

            if (Input.FullName != user.FullName)
            {
                user.FullName = Input.FullName;
            }

            await _userManager.UpdateAsync(user);
            await _signInManager.RefreshSignInAsync(user);
            StatusMessage = "Your profile has been updated";
            return RedirectToPage();
        }
    }
}
