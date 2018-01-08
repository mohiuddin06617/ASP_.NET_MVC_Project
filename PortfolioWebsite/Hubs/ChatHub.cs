using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Web;

using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;
using PWService;
using PWEntity;

namespace PortfolioWebsite.Hubs
{
    public class ChatHub : Hub
    {
        ArticleCommentService articleCommentService=new ArticleCommentService();

        public void Hello()
        {
            Clients.All.hello();
        }
        public void Send(string name, string message)
        {
            
            // Call the addNewMessageToPage method to update clients.
            Clients.All.addNewMessageToPage(name, message);
        }
        [HubMethodName("getAllComment")]
        public List<ArticleComment> GetAllComment(int articleId)
        {
           List<ArticleComment> commentList= articleCommentService.GetAll();
           //Clients.All.commentList(commentList);
           return commentList;
        }
        /*[HubMethodName("getAllComment")]
        public string GetAllComment()
        {
            List<ArticleComment> commentList = articleCommentService.GetAll(4);
            //Clients.All.commentList(commentList);
            return "Its Working!";
        }*/
    }
}