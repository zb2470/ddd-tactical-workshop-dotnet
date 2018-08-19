﻿using System.Collections.Generic;
using Content.Domain.Model.Article;

namespace Content.Application
{
    public class ArticleApplicationService
    {
        private readonly IArticleRepository _articleRepository;

        public ArticleApplicationService(IArticleRepository articleRepository)
        {
            _articleRepository = articleRepository;
        }


        public void CreateArticle(Article article)
        {
            _articleRepository.Save(article);
        }

        public void Publish(ArticleId articleId)
        {
            var article = _articleRepository.FindById(articleId);
            article.Publish();
            _articleRepository.Save(article);
        }

        public List<Article> GetArticles()
        {
            return _articleRepository.FindAll();
        }

        public Article GetArticle(ArticleId articleId)
        {
            return _articleRepository.FindById(articleId);
        }

        public void UpdateArticle(ArticleId articleId, string title, string content, List<Product> products)
        {
            Article article = _articleRepository.FindById(articleId);
            article.Update(title, content, products);
            _articleRepository.Save(article);
        }
    }
}