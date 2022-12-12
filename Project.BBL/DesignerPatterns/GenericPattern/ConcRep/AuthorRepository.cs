using Project.BBL.DesignerPatterns.GenericPattern.BaseRep;
using Project.ENTITIES.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.BBL.DesignerPatterns.GenericPattern.ConcRep
{
    public class AuthorRepository:BaseRepository<Author>
    {
       public void AddWithBooks(List<Article> articles, Author author)
        {
            _db.Authors.Add(author);
            _db.Articles.AddRange(articles);
            Save();


        }

    }
}
