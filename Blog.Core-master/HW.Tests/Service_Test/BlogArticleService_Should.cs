using HW.IServices;
using HW.Model.Models;
using Xunit;
using System;
using System.Linq;
using Autofac;

namespace HW.Tests.Service_Test
{
    public class BlogArticleService_Should
    {

        private readonly IBlogArticleServices blogArticleServices;
        readonly DI_Test dI_Test = new();


        public BlogArticleService_Should()
        {
            //mockBlogRep.Setup(r => r.Query());

            var container = dI_Test.DICollections();

            blogArticleServices = container.Resolve<IBlogArticleServices>();

        }


        [Fact]
        public void BlogArticleServices_Test()
        {
            Assert.NotNull(blogArticleServices);
        }


        [Fact]
        public async void Get_Blogs_Test()
        {
            var data = await blogArticleServices.GetBlogs();

            Assert.True(data.Count==0);
        }

        [Fact]
        public async void Add_Blog_Test()
        {
            BlogArticle blogArticle = new ()
            {
                bCreateTime = DateTime.Now,
                bUpdateTime = DateTime.Now,
                btitle = "xuint test title",
                bcontent = "xuint test content",
                bsubmitter = "xuint test submitter",
            };

            var BId = await blogArticleServices.Add(blogArticle);

            Assert.True(BId > 0);
        }

        [Fact]
        public async void Delete_Blog_Test()
        {
            Add_Blog_Test();

            var deleteModel = (await blogArticleServices.Query(d => d.btitle == "xuint test title")).FirstOrDefault();

            Assert.NotNull(deleteModel);

            var IsDel = await blogArticleServices.Delete(deleteModel);

            Assert.True(IsDel);
        }
    }
}
