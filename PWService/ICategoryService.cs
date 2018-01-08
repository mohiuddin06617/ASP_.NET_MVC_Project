using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PWEntity;

namespace PWService
{
    public interface ICategoryService : IService<Category>
    {
        List<Category> GetAllCategoryName(int userId);
    }
}
