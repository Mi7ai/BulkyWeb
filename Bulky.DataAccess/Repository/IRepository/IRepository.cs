using System;
using System.Linq.Expressions;

namespace Bulky.DataAccess.Repository.IRepository
{
    public interface IRepository<T> where T : class
    {
        //T - will be a Category
        /* this repository will try to have all the operations that we will need when performing CRUD on Category */

        //get all categories
        IEnumerable<T> GetCategories();

        //get one category
        T Get(Expression<Func<T, bool>> filter);

        //add category
        void Add(T entity);

        //update category
        //no implementation because if you use any other entity the update process might be different or you might want to update only few values
        //this method will be created in the entity interface
        //T Update(T entity);

        //delete category
        void Remove(T entity);

        //delete a range of categories
        void RemoveRange(IEnumerable<T> entities);
    }
}

