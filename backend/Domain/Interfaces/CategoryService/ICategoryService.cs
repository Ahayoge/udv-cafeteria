using UDV_Benefits.Domain.Errors;
using UDV_Benefits.Domain.Models;

namespace UDV_Benefits.Domain.Interfaces.CategoryService
{
    public interface ICategoryService
    {
        public Task<ValueResult<Category>> GetCategoryByNameAsync(string categoryName);
    }
}
