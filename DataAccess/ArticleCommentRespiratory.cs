using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
   public class ArticleCommentRespiratory : IArticleCommentRespiratory
    {
        private DataAccessContext dataAccessContext;
        public ArticleCommentRespiratory()
        {
            this.dataAccessContext=new DataAccessContext();
        }

        public List<ArticleComment> GetAll(int articleId)
        {
            return this.dataAccessContext.ArticleComments.Where(ac => ac.articleId == articleId).ToList();
        }

        public ArticleComment Get(int id)
        {
            return this.dataAccessContext.ArticleComments.SingleOrDefault(ac => ac.articleId == id);
        }

        public int Insert(ArticleComment articleComment)
        {
            this.dataAccessContext.ArticleComments.Add(articleComment);
            return this.dataAccessContext.SaveChanges();
        }

        public int Update(ArticleComment articleComment)
        {
            ArticleComment articleCommentToUpdate = this.dataAccessContext.ArticleComments.SingleOrDefault(ac => ac.articleId == articleComment.articleId);
            articleCommentToUpdate.comment = articleComment.comment;
            articleCommentToUpdate.commenterEmail = articleComment.commenterEmail;
            articleCommentToUpdate.commenterName = articleComment.commenterName;

            return this.dataAccessContext.SaveChanges();
        }

        public int Delete(int id)
        {
           ArticleComment articleCommentToDelete = this.dataAccessContext.ArticleComments.SingleOrDefault(ac => ac.articleId == id);
            this.dataAccessContext.ArticleComments.Remove(articleCommentToDelete);

            return this.dataAccessContext.SaveChanges();
        }
    }
}
