using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using SosialMediaProject.Business.Exceptions;
using SosialMediaProject.Business.Extensions;
using SosialMediaProject.Business.Services.Interfaces;
using SosialMediaProject.Core.Models;
using SosialMediaProject.Core.Repositories.Interfaces;
using SosialMediaProject.Data.Repositories.Implementations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace SosialMediaProject.Business.Services.Implementations
{
	public class PostService : IPostService
	{
		private readonly IPostRepository _postRepository;
		private readonly IWebHostEnvironment _env;
		private readonly UserManager<AppUser> _userManager;
		private readonly IHttpContextAccessor _httpContextAccessor;
		public PostService(IPostRepository postRepository, IWebHostEnvironment env,UserManager<AppUser> userManager,IHttpContextAccessor httpContextAccessor)
		{
			_userManager = userManager;
			_postRepository = postRepository;
			_env = env;
			_httpContextAccessor = httpContextAccessor;
		}
		public async Task<List<Post>> GetAll(Expression<Func<Post, bool>>? expression = null, params string[]? includes)
		{
			return await _postRepository.GetAllWhereAsync(expression, includes).ToListAsync();
		}

		public async Task<Post> GetById(Expression<Func<Post, bool>>? expression = null, params string[]? includes)
		{
			return await _postRepository.GetByIdAsync(expression, includes);
		}
        public async Task CreateImage(Post post)
        {
            if (post is null) throw new InvalidNotFoundException();
            AppUser appUser = null;

            if (_httpContextAccessor.HttpContext.User.Identity.IsAuthenticated)
            {
                appUser = await _userManager.FindByNameAsync(_httpContextAccessor.HttpContext.User.Identity.Name);
                post.AppUserId = appUser.Id;

            }

            if (post.Image != null)
            {
                if (post.Image.ContentType != "image/jpeg" && post.Image.ContentType != "image/png")
                {
                    throw new InvalidFileContentTypeException("Image", "Image ContentType must be .png or .jpeg ");
                }
                if (post.Image.Length > 2097152 )
                {
                    throw new InvalidFileSizeException("Image", "ImageSize must be lower than 2 MB");
                }
                post.ImageUrl = Helper.SaveFile(_env.WebRootPath, "uploads/posts", post.Image);
            }
            else
            {
                throw new InvalidFileException("Image", "Image is required");
            }

            post.CreatedDate = DateTime.UtcNow.AddHours(4);
            await _postRepository.CreateAsync(post);
            await _postRepository.CommitAsync();
        }

        public async Task CreateVideo(Post post)
        {
            if (post is null) throw new InvalidNotFoundException();
            AppUser appUser = null;

            if (_httpContextAccessor.HttpContext.User.Identity.IsAuthenticated)
            {
                appUser = await _userManager.FindByNameAsync(_httpContextAccessor.HttpContext.User.Identity.Name);
                post.AppUserId = appUser.Id;

            }

            if (post.Video != null)
            {
                if (post.Video.ContentType != "video/mpeg" && post.Video.ContentType != "video/mp4")
                {
                    throw new InvalidFileContentTypeException("Video", "Video ContentType must be .mpeg or .mp4 ");
                }
                if (post.Video.Length > 1073741824)
                {
                    throw new InvalidFileSizeException("Video", "VideoSize must be lower than 1 GB");
                }
                post.VideoUrl = Helper.SaveFile(_env.WebRootPath, "uploads/posts", post.Video);
            }
            else
            {
                throw new InvalidFileException("Video", "Video is required");
            }

            post.CreatedDate = DateTime.UtcNow.AddHours(4);
            await _postRepository.CreateAsync(post);
            await _postRepository.CommitAsync();
        }
      
		public async Task DeleteImage(int id)
		{
			if (id == null) throw new InvalidNotFoundException();
			
			var existPost = await _postRepository.GetByIdAsync(x => x.Id == id);
			if (existPost == null) throw new InvalidNotFoundException();
			Helper.DeleteFile(_env.WebRootPath, "uploads/posts", existPost.ImageUrl);
           
            existPost.DeletedDate = DateTime.UtcNow.AddHours(4);
            _postRepository.Delete(existPost);
			await _postRepository.CommitAsync();

		}
		public async Task DeleteVideo(int id)
		{
			if (id == null) throw new InvalidNotFoundException();

			var existPost = await _postRepository.GetByIdAsync(x => x.Id == id);
			if (existPost == null) throw new InvalidNotFoundException();
	
			Helper.DeleteFile(_env.WebRootPath, "uploads/posts", existPost.VideoUrl);
			existPost.DeletedDate = DateTime.UtcNow.AddHours(4);
			_postRepository.Delete(existPost);
			await _postRepository.CommitAsync();

		}

		public async Task SoftDelete(int id)
		{
			if (id == null) throw new InvalidNotFoundException();
			var existPost = await _postRepository.GetByIdAsync(x => x.Id == id);
			if (existPost == null) throw new InvalidNotFoundException();
            existPost.UpdatedDate = DateTime.UtcNow.AddHours(4);
            existPost.IsDeleted = !existPost.IsDeleted;
			await _postRepository.CommitAsync();
		}

   

        //public async Task Update(Post post)
        //{
        //	if (post == null) throw new InvalidNotFoundException();

        //	var existPost = await _postRepository.GetByIdAsync(x => x.Id == post.Id);
        //	if (existPost == null) throw new InvalidNotFoundException();
        //	if (post.Image != null)
        //	{
        //		if (post.Image.ContentType != "image/jpeg" && post.Image.ContentType != "image/png")
        //		{
        //			throw new InvalidImageContentTypeException("Image", "Image ContentType must be .png or .jpeg");
        //		}
        //		if (post.Image.Length > 1048576)
        //		{
        //			throw new InvalidImageSizeException("Image", "ImageSize must be lower than 1048576 ");
        //		}
        //		Helper.DeleteFile(_env.WebRootPath, "uploads/posts", existPost.ImageUrl);				
        //		existPost.ImageUrl = Helper.SaveFile(_env.WebRootPath, "uploads/posts", post.Image);
        //	}
        //	else
        //	{
        //		throw new InvalidImageException("Image", "Image is required");
        //	}
        //	if (post.Video != null)
        //	{
        //		if (post.Video.ContentType != "video/mpeg" && post.Video.ContentType != "video/mp4")
        //		{
        //			throw new InvalidVideoContentTypeException("Video", "Video ContentType must be .png or .jpeg");
        //		}
        //		if (post.Video.Length > 1073741824)
        //		{
        //			throw new InvalidVideoSizeException("Video", "Videosize must be lower than 1073741824 ");
        //		}
        //		Helper.DeleteFile(_env.WebRootPath, "uploads/posts", existPost.VideoUrl);
        //		existPost.VideoUrl = Helper.SaveFile(_env.WebRootPath, "uploads/posts", post.Video);
        //	}
        //	else
        //	{
        //		throw new InvalidVideoException("Video", "Video is required");
        //	}

        //	existPost.Context = post.Context;

        //	existPost.UpdatedDate = DateTime.UtcNow.AddHours(4);
        //	await _postRepository.CommitAsync();
        //}
    }
}
