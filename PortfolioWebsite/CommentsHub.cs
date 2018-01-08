using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PWService;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;
using PWEntity;

namespace PortfolioWebsite
{
    public class CommentsHub : Hub
    {
         ArticleCommentService articleCommentService = new ArticleCommentService();

        public void AddNewComment(string commenterName,string email,string comment,int articleId)
        {
            Clients.All.addingNewCommentsToPage(commenterName, email,comment,articleId);
        }

        [HubMethodName("getAllComment")]
        public List<ArticleComment> GetAllComment(int id)
        { 
            List<ArticleComment> commentList = articleCommentService.GetAll();
            //Clients.All.commentList(commentList);
            return commentList;
        }
    }
}