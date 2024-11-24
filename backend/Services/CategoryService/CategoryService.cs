using Microsoft.EntityFrameworkCore;
using UDV_Benefits.Domain.Errors;
using UDV_Benefits.Domain.Interfaces.CategoryService;
using UDV_Benefits.Domain.Models;
using UDV_Benefits.Infrastructure.Data;

namespace UDV_Benefits.Services.CategoryService
{
    public class CategoryService : ICategoryService
    {
        private readonly AppDbContext _dbContext;

        public CategoryService(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<ValueResult<Category>> GetCategoryByNameAsync(string categoryName)
        {
            var category = await _dbContext.Categories
                .FirstOrDefaultAsync(c => c.Name == categoryName);
            if (category == null)
                return CategoryErrors.CategoryDoesntExist;
            return category;
        }
    }
}
