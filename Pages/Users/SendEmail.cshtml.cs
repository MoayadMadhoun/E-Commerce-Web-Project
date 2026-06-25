using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MyStore.Models;
using System.ComponentModel;

namespace MyStore.Pages.Users
{
    public class SendEmailModel : PageModel
    {
        private readonly IEmailSender _emailSender;
        private readonly UserManager<AppUser> _userManager;

        public SendEmailModel(IEmailSender emailSender, UserManager<AppUser> userManager)
        {
            _emailSender = emailSender;
            _userManager = userManager;
        }

        [BindProperty]
        public List<string> SelectedUserIds { get; set; }

        [BindProperty, DisplayName("Email Subject:")]
        public string EmailSubject { get; set; }

        [BindProperty, DisplayName("Email Body:")]
        public string EmailBody { get; set; }

        public void OnGet()
        {
            if (TempData["SelectedUserIds"] != null)
            {
                SelectedUserIds = TempData["SelectedUserIds"]
                    .ToString()
                    .Split(',')
                    .ToList();
            }
            else
            {
                SelectedUserIds = new List<string>();
            }
        }

        public async Task<IActionResult> OnPost()
        {
            // more performance from foreach
            if (SelectedUserIds == null || !SelectedUserIds.Any())
            {
                ModelState.AddModelError("", "Please select users");
                return Page();
            }

            var users = _userManager.Users
                .Where(u => SelectedUserIds.Contains(u.Id) && u.Email != null)
                .ToList();

            var tasks = users.Select(user =>
                _emailSender.SendEmailAsync(
                    user.Email,
                    EmailSubject,
                    EmailBody
                )
            );

            await Task.WhenAll(tasks);

            return RedirectToPage("Index");
        }
    }
}