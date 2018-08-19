using System;
using System.Collections.Generic;
using Content.Domain.Model.Article;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Content.Test.Domain.Model.Article
{
    [TestClass]
    public class ArticleTest
    {
        ArticleId id1 = new ArticleId(new Guid("dddddddddddddddddddddddddddddddd"));
        private readonly string title1 = "title1";
        private readonly string title2 = "title2";
        private readonly string content1 = "content1";
        private readonly string content2 = "content2";
        private List<Product> products1 = new List<Product>();
        private List<Product> products2;
        private Content.Domain.Model.Article.Article article;

        [TestInitialize]
        public void Initialize()
        {
            article = new Content.Domain.Model.Article.Article(title1, content1, products1);
        }

        [TestMethod]
        public void Update_should_right_when_article_products_count_0_and_add_products_count_3()
        {
            products2 = new List<Product>()
            {
                new Product("code1","name1"),
                new Product("code2","name2"),
                new Product("code3","name3"),
            };

            article.Update(title2, content2, products2);

            Assert.AreEqual(title2, article.Title);
            Assert.AreEqual(content2, article.Content);
            Assert.AreEqual(ArticleStatus.Draft, article.Status);
            Assert.AreEqual(products2.Count, article.Products.Count);
            Assert.AreSame(products2[2].Code, article.Products[2].Code);
        }

        [TestMethod]
        public void Update_should_throw_expection_when_add_products_count_4()
        {
            products2 = new List<Product>()
            {
                new Product("code1","name1"),
                new Product("code2","name2"),
                new Product("code3","name3"),
                new Product("code4","name4"),
            };

            try
            {
                article.Update(title2, content2, products2);
                Assert.Fail();
            }
            catch (Exception e)
            {
                Assert.AreEqual("关联的产品个数不能超过3个", e.Message);
            }
        }

        [TestMethod]
        public void Update_should_throw_expection_when_article_products_count_1_and_add_products_count_3()
        {
            ;
            article.Products.Add(new Product("code", "name"));
            products2 = new List<Product>()
            {
                new Product("code1","name1"),
                new Product("code2","name2"),
                new Product("code3","name3")
            };

            try
            {
                article.Update(title2, content2, products2);
                Assert.Fail();
            }
            catch (Exception e)
            {
                Assert.AreEqual("关联的产品个数不能超过3个", e.Message);
            }
        }
    }
}
