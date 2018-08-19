using System;
using System.Collections.Generic;

namespace Content.Domain.Model.Article
{
    public class Article
    {
        public Article(string title, string content, IEnumerable<Product> products)
        {
            Id = new ArticleId();
            Status = ArticleStatus.Draft;
            Title = title;
            Content = content;
            Products = new List<Product>(products);
        }

        public ArticleId Id { get; }

        public string Title { get; private set; }

        public string Content { get; private set; }

        public List<Product> Products { get; }

        public ArticleStatus Status { get; private set; }

        public void Publish()
        {
            Status = ArticleStatus.Published;
        }

        public void Update(string title, string content, List<Product> products)
        {
            Title = title;
            Content = content;
            AddProducts(products);
            if (this.Status == ArticleStatus.Published)
                this.Status = ArticleStatus.Draft;
        }

        private void AddProducts(List<Product> products)
        {
            products.ForEach(c =>
            {
                if (this.Products.Count >= 3)
                {
                    throw new Exception("关联的产品个数不能超过3个");
                }
                this.Products.Add(c);
            });
        }
    }

    public enum ArticleStatus
    {
        Draft,
        Published,
        Deleted
    }
}