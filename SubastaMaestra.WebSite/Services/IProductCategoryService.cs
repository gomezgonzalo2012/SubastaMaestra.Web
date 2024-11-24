using SubastaMaestra.Entities.Core;


namespace SubastaMaestra.WebSite.Services
{
    public interface IProductCategoryService
    {

        Task<List<ProductCategory>> GetCategoriesAsync();

    }
}
