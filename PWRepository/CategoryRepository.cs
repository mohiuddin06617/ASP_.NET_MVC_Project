using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PWEntity;
namespace PWRepository
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        DataAccessContext dataAccessContext = new DataAccessContext();
        public List<Category> GetAllCategoryName(int userId)
        {
            List<Category> categoryList = dataAccessContext.Categories.Where(c => c.UserId == userId).ToList();
            return categoryList;
        }
    }
}
