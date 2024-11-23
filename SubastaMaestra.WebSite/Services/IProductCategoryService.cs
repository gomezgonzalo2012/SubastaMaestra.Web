using SubastaMaestra.Models.DTOs.Product;


namespace SubastaMaestra.WebSite.Services
{
    public interface IProductCategoryService
    {

        Task<List<CategoryDTO>> GetCategoriesAsync();

    }
}
