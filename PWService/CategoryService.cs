using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PWEntity;
using PWRepository;

namespace PWService
{
    public class CategoryService : Service<Category>, ICategoryService
    {
        private CategoryRepository categoryRepository = new CategoryRepository();
        public List<Category> GetAllCategoryName(int userId)
        {
            List<Category> categoryList = categoryRepository.GetAllCategoryName(userId);
            return categoryList;
        }
    }
}
