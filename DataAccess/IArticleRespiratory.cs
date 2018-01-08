using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public interface IArticleRespiratory
    {
        List<Article> GetAll();
        Article Get(int id);
        int Insert(Article article);
        int Update(Article article);
        int Delete(int id);
    }
}
