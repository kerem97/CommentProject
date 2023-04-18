using CommentProject.DataAccessLayer.Abstract;
using CommentProject.DataAccessLayer.Concrete;
using CommentProject.DataAccessLayer.Repositories;
using CommentProject.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommentProject.DataAccessLayer.EntityFramework
{
    public class EfCommentDal : GenericRepository<Comment>, ICommentDal
    {
        public List<Comment> GetCommentsByTitle(int id)
        {
            var context = new Context();
            return context.Comments.Where(x => x.TitleID == id).ToList();
        }
    }
}
