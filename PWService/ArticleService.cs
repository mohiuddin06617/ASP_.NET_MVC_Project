using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PWEntity;
using PWRepository;
namespace PWService
{
    public class ArticleService : Service<Article>, IArticleService
    {
        ArticleRepository articleRepo = new ArticleRepository();
        public List<Article> AllArticleList(int id)
        {
            List<Article> articleList = articleRepo.AllArticleList(id);
            return articleList;
        }
        public List<Article> ArticleDetail(int userId, int id)
        {
            List<Article> artileList = articleRepo.ArticleDetail(userId, id);
            return artileList;
        }
        public int DeleteArticle(int id)
        {
           return articleRepo.DeleteArtlcle(id);
        }
    }
}
