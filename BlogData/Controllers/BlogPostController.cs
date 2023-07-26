using BlogData.DTO;
using BlogData.IReposiroty;
using Microsoft.AspNetCore.Mvc;

namespace BlogData.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogPostController : ControllerBase
    {
        private readonly IRepository<BlogPostDTO> _repository;

        public BlogPostController(IRepository<BlogPostDTO> repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllBlogPosts()
        {
            var blogPosts = await _repository.GetAllAsync();
            return Ok(blogPosts);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetBlogPostById(string id)
        {
            var blogPost = await _repository.GetByIdAsync(id);
            if (blogPost == null)
                return NotFound();

            return Ok(blogPost);
        }

        [HttpPost]
        public async Task<IActionResult> CreateBlogPost(BlogPostDTO blogPost)
        {
            var createdPost = await _repository.AddAsync(blogPost);
            return CreatedAtAction(nameof(GetBlogPostById), new { id = createdPost.BlogId }, createdPost);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateBlogPost(string id, BlogPostDTO blogPost)
        {
            var existingPost = await _repository.GetByIdAsync(id);
            if (existingPost == null)
                return NotFound();

            blogPost.BlogId = id; // Ensure the correct ID is used
            await _repository.UpdateAsync(blogPost);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBlogPost(string id)
        {
            var deleted = await _repository.DeleteAsync(id);
            if (!deleted)
                return NotFound();

            return NoContent();
        }
    }

}
