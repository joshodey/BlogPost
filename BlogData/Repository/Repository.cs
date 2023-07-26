using AutoMapper;
using BlogData.Context;
using BlogData.Domain;
using BlogData.DTO;
using BlogData.IReposiroty;

namespace BlogData.Repository
{
    public class BlogPostRepository : IRepository<BlogPostDTO>
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public BlogPostRepository(YourDatabaseContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<BlogPostDTO>> GetAllAsync()
        {
            var posts = await _context.posts.ToListAsync();
            return _mapper.Map<IEnumerable<BlogPostDTO>>(posts);
        }

        public async Task<BlogPostDTO> GetByIdAsync(string id)
        {
            var blogPost = await _context.posts.FirstOrDefaultAsync(post => post.BlogId == id);
            return _mapper.Map<BlogPostDTO>(blogPost);
        }

        public async Task<BlogPostDTO> AddAsync(BlogPostDTO entity)
        {
            var blogPost = _mapper.Map<BlogPost>(entity);
            _context.posts.Add(blogPost);
            await _context.SaveChangesAsync();
            return _mapper.Map<BlogPostDTO>(blogPost);
        }

        public async Task<BlogPostDTO> UpdateAsync(BlogPostDTO entity)
        {
            var existingPost = await _context.posts.FirstOrDefaultAsync(post => post.BlogId == entity.BlogId);
            if (existingPost == null)
                return null;

            _mapper.Map(entity, existingPost);

            _context.posts.Update(existingPost);
            await _context.SaveChangesAsync();

            return _mapper.Map<BlogPostDTO>(existingPost);
        }

        public async Task<bool> DeleteAsync(string id)
        {
            var blogPost = await _context.posts.FirstOrDefaultAsync(post => post.BlogId == id);
            if (blogPost == null)
                return false;

            _context.posts.Remove(blogPost);
            await _context.SaveChangesAsync();
            return true;
        }
    }

}
