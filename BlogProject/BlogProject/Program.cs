using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlogProject.Models;

namespace BlogProject
{
    public class Program
    {
        public static void Main(string[] args)
        {
            using Context myContext = new Context();
            myContext.Posts.Add(new Post
            {
                PostId = 1,
                PostTitle = "Pair Programming",
                PostCategory = new List<Category>()
                {
                    new Category()
                    {
                        CategoryId = 1,
                        CategoryContent = "Programming"
                    }
                },
                PostComment = new List<Comment>()
               {
                   new Comment()
                   {
                       CommentId = 1,
                       CommentCategory = "read",
                       CommentBody = "That was good :)"
                   }
               }
            }
            ); 
        }
    }

}
