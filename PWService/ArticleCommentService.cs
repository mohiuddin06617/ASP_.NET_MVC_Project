using PWEntity;
using PWRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PWService
{
    public class ArticleCommentService : Service<ArticleComment>, IArticleCommentService
    {
        private ArticleCommentRepository articleCommentRepository = new ArticleCommentRepository();
        public List<ArticleComment> GetAllComment(int id)
        {
            return articleCommentRepository.GetAllComment(id);
        }
    }
}
