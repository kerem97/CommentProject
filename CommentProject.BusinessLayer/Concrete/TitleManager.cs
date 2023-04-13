using CommentProject.BusinessLayer.Abstract;
using CommentProject.DataAccessLayer.Abstract;
using CommentProject.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CommentProject.BusinessLayer.Concrete
{
    public class TitleManager : ITitleService
    {
        private readonly ITitleDal _titleDal;

        public TitleManager(ITitleDal titleDal)
        {
            _titleDal = titleDal;
        }

        public void TDelete(Title t)
        {
            _titleDal.Delete(t);
        }

        public Title TGetById(int id)
        {
            return _titleDal.GetById(id);
        }

        public List<Title> TGetList()
        {
            return _titleDal.GetList();
        }

        public List<Title> TGetListByFilter(Expression<Func<Title, bool>> filter)
        {
            return _titleDal.GetListByFilter(filter);
        }

        public void TInsert(Title t)
        {
            _titleDal.Insert(t);
        }

        public void TUpdate(Title t)
        {
            _titleDal.Update(t);
        }
    }
}
