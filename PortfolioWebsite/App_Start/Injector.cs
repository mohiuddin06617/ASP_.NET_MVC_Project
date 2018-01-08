using Injection;
using Injection.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PWService;
using PortfolioWebsite.Controllers;
using System.Web.Mvc;

namespace PortfolioWebsite.App_Start
{
    public class Injector
    {
        public static IInjectionContainer Container { get; set; }
        static Injector()
        {
            Container = new Container();
        }
        public static void Configure()
        {
            Container.Register<IArticleService,ArticleService>().Singleton();
            Container.Register<ArticleController, ArticleController>();

            Container.Register<IArticleCommentService, ArticleCommentService>().Singleton();
            Container.Register<ArticleController, ArticleController>();

            Container.Register<ICategoryService, CategoryService>().Singleton();
            Container.Register<CategoryController, CategoryController>();


            Container.Register<IUserDetailService, UserDetailService>().Singleton();
            Container.Register<UserController, UserController>();
            ControllerBuilder.Current.SetControllerFactory(new InjectorControllerFactory());


        }
    }
}