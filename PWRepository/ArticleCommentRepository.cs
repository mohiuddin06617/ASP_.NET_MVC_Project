using PWEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PWRepository
{
    public class ArticleCommentRepository : Repository<ArticleComment>, IArticleCommentRepository
    {
        private DataAccessContext dataAccessContext = new DataAccessContext();
        public List<ArticleComment> GetAllComment(int id)
        {
            List<ArticleComment> list = dataAccessContext.ArticleComments.Where(ac => ac.articleId == id).ToList();
            return list;
        }
    }
}
