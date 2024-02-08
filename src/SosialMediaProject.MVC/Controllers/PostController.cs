using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SosialMediaProject.Business.Exceptions;
using SosialMediaProject.Business.Services.Interfaces;
using SosialMediaProject.Core.Models;

namespace SosialMediaProject.MVC.Controllers
{
    public class PostController : Controller
    {
        private readonly IPostService _postService;

        public PostController(IPostService postService)
        {
            _postService = postService;
        }
        [Authorize]
        public async Task<IActionResult> Index()
        {
            return View(await _postService.GetAll());
        }
        [Authorize(Roles = "Member")]
        [HttpGet]
        public IActionResult CreateImage()
        {

            return View();
        }
        [Authorize(Roles = "Member")]
        [ValidateAntiForgeryToken]
        [HttpPost]
        public async Task<IActionResult> CreateImage(Post post)
        {
            if (!ModelState.IsValid) return View(post);
            try
            {
                await _postService.CreateImage(post);
            }
            catch (InvalidNotFoundException ex)
            {
                return View("error");

            }
            catch (InvalidFileContentTypeException ex)
            {
                ModelState.AddModelError(ex.PropertyName, ex.Message);
                return View(post);

            }
            catch (InvalidFileSizeException ex)
            {
                ModelState.AddModelError(ex.PropertyName, ex.Message);
                return View(post);
            }
            catch (InvalidFileException ex)
            {
                ModelState.AddModelError(ex.PropertyName, ex.Message);
                return View(post);

            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View(post);

            }
            return RedirectToAction(nameof(Index));
        }
        [Authorize(Roles = "Member")]
        [HttpGet]
        public IActionResult CreateVideo()
        {
            return View();
        }
        [Authorize(Roles = "Member")]
        [ValidateAntiForgeryToken]
        [HttpPost]
        public async Task<IActionResult> CreateVideo(Post post)
        {
            if (!ModelState.IsValid) return View(post);
            try
            {
                await _postService.CreateVideo(post);
            }
            catch (InvalidNotFoundException ex)
            {
                return View("error");

            }
            catch (InvalidFileContentTypeException ex)
            {
                ModelState.AddModelError(ex.PropertyName, ex.Message);
                return View(post);

            }
            catch (InvalidFileSizeException ex)
            {
                ModelState.AddModelError(ex.PropertyName, ex.Message);
                return View(post);
            }
            catch (InvalidFileException ex)
            {
                ModelState.AddModelError(ex.PropertyName, ex.Message);
                return View(post);

            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View(post);

            }
            return RedirectToAction(nameof(Index));
        }
        
        [Authorize(Roles = "Member")]
        [HttpGet]
        public async Task<IActionResult> DeleteImage(int id)
        {
            if (id == null) return View("error");
            var existPost = await _postService.GetById(x => x.Id == id && x.IsDeleted == false);
            if (existPost == null) return View("error");
            return View(existPost);
        }
        [Authorize(Roles = "Member")]
        [ValidateAntiForgeryToken]
        [HttpPost]
        public async Task<IActionResult> DeleteImage(Post post)
        {

            try
            {
                await _postService.DeleteImage(post.Id);
            }
            catch (InvalidNotFoundException ex)
            {
                return View("error");

            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View(post);

            }
            return RedirectToAction(nameof(Index));
        }
        [Authorize(Roles = "Member")]
		[HttpGet]
		public async Task<IActionResult> DeleteVideo(int id)
		{
			if (id == null) return View("error");
			var existPost = await _postService.GetById(x => x.Id == id && x.IsDeleted == false);
			if (existPost == null) return View("error");
			return View(existPost);
		}
        [Authorize(Roles = "Member")]
        [ValidateAntiForgeryToken]
        [HttpPost]
        public async Task<IActionResult> DeleteVideo(Post post)
        {

            try
            {
                await _postService.DeleteVideo(post.Id);
            }
            catch (InvalidNotFoundException ex)
            {
                return View("error");

            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View(post);

            }
            return RedirectToAction(nameof(Index));
        }
       
        [Authorize(Roles ="SuperAdmin")]
        [HttpGet]
        public async Task<IActionResult> SoftDelete(int id)
        {
            try
            {
                await _postService.SoftDelete(id);
            }
            catch (InvalidNotFoundException ex)
            {
                return View("error");

            }
            catch (Exception ex)
            {
                return View("error");

            }
            return RedirectToAction(nameof(Index));

        }
    }
}
