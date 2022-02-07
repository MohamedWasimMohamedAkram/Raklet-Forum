using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using RakletForums.Data;
using RakletForums.Data.Models;
using RakletForums.Models.ApplicationUser;

namespace RakletForums.Controllers
{
    public class ProfileController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager; //Provided by Microsoft.AspNetCore.Identity
        private readonly IApplicationUser _userService;
        private readonly IUpload _uploadService; //To upload profile image to the cloud

        public ProfileController(UserManager<ApplicationUser> userManager, IApplicationUser userService, IUpload uploadService)
        {
            this._userManager = userManager;
            this._userService = userService;
            this._uploadService = uploadService;
        }

        public IActionResult Detail(string id)
        {
            var user = _userService.GetById(id);
            var userRoles = _userManager.GetRolesAsync(user).Result;

            var model = new ProfileModel
            {
                UserId = user.Id,
                UserName = user.UserName,
                UserRating = user.Rating.ToString(),
                Email = user.Email,
                ProfileImageUrl = user.ProfileImageUrl,
                MemeberSince = user.MemberSince,
                IsAdmin = userRoles.Contains("Admin")
            };

            return View(model);
        }

        public IActionResult Index()
        {
            var profiles = _userService.GetAll()
                .OrderByDescending(user => user.Rating)
                .Select(u => new ProfileModel
                {
                    Email = u.Email,
                    ProfileImageUrl = u.ProfileImageUrl,
                    UserRating = u.Rating.ToString(),
                    MemeberSince = u.MemberSince,
                });

            var model = new ProfileListModel
            {
                //Profiles = profiles
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> UploadProfileImage(IFormFile file)
        {
            var userId = _userManager.GetUserId(User);

            //Connect to Azure Storage Container
            //Get Blob Container

            //Parse the Content Disposition response header
            //Grab the filename

            //Get a reference to a Block Blob
            //On that block blob, upload our file

            //Set the user's profile image to the received URI

            //Redirect to user's profile page
            return null;
        }
    }
}