﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using NuGet.Protocol.Plugins;
using SosialMediaProject.Business.Exceptions;
using SosialMediaProject.Business.Services.Interfaces;
using SosialMediaProject.Core.Models;

namespace SosialMediaProject.MVC.Areas.Manage.Controllers
{
	[Area("manage")]
	public class PostController : Controller
	{
		private readonly IPostService _postService;

		public PostController(IPostService postService)
		{
			_postService = postService;
		}
		public async Task<IActionResult> Index()
		{
			return View(await _postService.GetAll());
		}
		[HttpGet]
		public IActionResult Create()
		{
			return View();
		}
		[ValidateAntiForgeryToken]
		[HttpPost]
		public async Task<IActionResult> Create(Post post)
		{
			if (!ModelState.IsValid) return View(post);
			try
			{
				await _postService.Create(post);
			}
			catch (InvalidNotFoundException ex)
			{
				return View("error");

			}
			catch (InvalidImageContentTypeException ex)
			{
				ModelState.AddModelError(ex.PropertyName, ex.Message);
				return View(post);

			}
			catch (InvalidImageSizeException ex)
			{
				ModelState.AddModelError(ex.PropertyName, ex.Message);
				return View(post);
			}
			catch (InvalidImageException ex)
			{
				ModelState.AddModelError(ex.PropertyName, ex.Message);
				return View(post);

			}
			catch (InvalidVideoContentTypeException ex)
			{
				ModelState.AddModelError(ex.PropertyName, ex.Message);
				return View(post);

			}
			catch (InvalidVideoSizeException ex)
			{
				ModelState.AddModelError(ex.PropertyName, ex.Message);
				return View(post);
			}
			catch (InvalidVideoException ex)
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
		[HttpGet]
		public async Task<IActionResult> Update(int id)
		{
			if (id == null) return View("error");
			var existPost = await _postService.GetById(x => x.Id == id);
			if (existPost == null) return View("error");
			return View(existPost);
		}
		[ValidateAntiForgeryToken]
		[HttpPost]
		public async Task<IActionResult> Update(Post post)
		{
			if (!ModelState.IsValid) return View(post);
			try
			{
				await _postService.Update(post);
			}
			catch (InvalidNotFoundException ex)
			{
				return View("error");

			}
			catch (InvalidImageContentTypeException ex)
			{
				ModelState.AddModelError(ex.PropertyName, ex.Message);
				return View(post);

			}
			catch (InvalidImageSizeException ex)
			{
				ModelState.AddModelError(ex.PropertyName, ex.Message);
				return View(post);
			}
			catch (InvalidImageException ex)
			{
				ModelState.AddModelError(ex.PropertyName, ex.Message);
				return View(post);

			}
			catch (InvalidVideoContentTypeException ex)
			{
				ModelState.AddModelError(ex.PropertyName, ex.Message);
				return View(post);

			}
			catch (InvalidVideoSizeException ex)
			{
				ModelState.AddModelError(ex.PropertyName, ex.Message);
				return View(post);
			}
			catch (InvalidVideoException ex)
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
		[HttpGet]
		public async Task<IActionResult> Delete(int id)
		{
			if (id == null) return View("error");
			var existPost = await _postService.GetById(x => x.Id == id && x.IsDeleted == false);
			if (existPost == null) return View("error");
			return View(existPost);
		}
		[ValidateAntiForgeryToken]
		[HttpPost]
		public async Task<IActionResult> Delete(Post post)
		{
			
			try
			{
				await _postService.Delete(post.Id);
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
