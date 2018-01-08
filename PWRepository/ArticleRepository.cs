using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PWEntity;
namespace PWRepository
{
    public class ArticleRepository:Repository<Article>,IArticleRepository
    {
        DataAccessContext dataAccess = new DataAccessContext();
        IRepository<Article> repository = new Repository<Article>();
        public List<Article> AllArticleList(int id)
        {
            List<Article> artileList= dataAccess.Articles.Where(a => a.UserId == id).ToList();
            return artileList;
        }
        public List<Article> ArticleDetail(int userId,int id)
        {
            List<Article> artileDetailList = dataAccess.Articles.Where(a => a.UserId == id && a.Id==id).ToList();
            return artileDetailList;
        }
        public int DeleteArtlcle(int id)
        {
            Article article = dataAccess.Articles.Where(a => a.Id == id).FirstOrDefault();
            return repository.Delete(article);

        }
        
    }
}
