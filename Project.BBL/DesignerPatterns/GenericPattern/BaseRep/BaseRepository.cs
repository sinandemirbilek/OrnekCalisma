using Project.BBL.DesignerPatterns.GenericPattern.IntRep;
using Project.BBL.DesignerPatterns.SingletonPattern;
using Project.DAL.Context;
using Project.ENTITIES.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Project.BBL.DesignerPatterns.GenericPattern.BaseRep
{
    public abstract class BaseRepository<T> : IRepository<T> where T : BaseEntity
    {

       protected MyContext _db;

        public BaseRepository()
        {
            _db = DBTool.DBInstance;
        }

         protected void Save()
        {
            _db.SaveChanges();
        }

        public void Add(T item)
        {
            _db.Set<T>().Add(item);
            Save();

        }

        public void AddRange(List<T> list)
        {
            _db.Set<T>().AddRange(list);
            Save();
        }

        public bool Any(Expression<Func<T, bool>> exp)
        {
            return _db.Set<T>().Any(exp);
        }

        public void Delete(T item)
        {
            item.Status = ENTITIES.Enums.DataStatus.Deleted;
            item.DeletedDate = DateTime.Now;
            Save();

        }

        public void DeleteRange(List<T> list)
        {
            foreach (T item in list)
            {
                Delete(item);
            }

        }

        public void Destroy(T item)
        {
            _db.Set<T>().Remove(item);
            Save();
        }

        public void DestroyRange(List<T> list)
        {
            _db.Set<T>().RemoveRange(list);
            Save();
        }

        public T Find(int id)
        {
            return _db.Set<T>().Find(id);

        }

        public T FirstOrDefault(Expression<Func<T, bool>> exp)
        {
            return _db.Set<T>().FirstOrDefault(exp);



        }

        public List<T> GetActives()
        {
            return Where(x => x.Status != ENTITIES.Enums.DataStatus.Deleted);

        }

        public List<T> GetAll()
        {
            return _db.Set<T>().ToList();

        }

        public List<T> GetDeleteds()
        {
            return Where(x => x.Status == ENTITIES.Enums.DataStatus.Deleted);


        }

        public List<T> GetFirstDatas(int number)
        {
            return _db.Set<T>().OrderBy(x => x.CreatedDate).Take(number).ToList();

        }

        public List<T> GetLastDatas(int number)
        {

            return _db.Set<T>().OrderByDescending(x => x.CreatedDate).Take(number).ToList();

        }

        public List<T> GetUpdateds()
        {
            return Where(x => x.Status == ENTITIES.Enums.DataStatus.Updated);

        }

        public object Select(Expression<Func<T, object>> exp)
        {
            return _db.Set<T>().Select(exp).ToList();

        }

        public void SetActive(T item)
        {
            item.ModifiedDate = null;
            item.DeletedDate = null;
            item.Status = ENTITIES.Enums.DataStatus.Inserted;
            Save();

        }

        public void SetActiveRange(List<T> list)
        {
            foreach (T item in list)
            {

                SetActive(item);
            }
        }

        public void Update(T item)
        {
            item.Status = ENTITIES.Enums.DataStatus.Updated;
            item.ModifiedDate = DateTime.Now;
            T guncellenecek = Find(item.ID);
            _db.Entry(guncellenecek).CurrentValues.SetValues(item);
            Save();

        }

        public void UpdateRange(List<T> list)
        {
            foreach (T item in list)
            {
                Update(item);

            }

        }

        public List<T> Where(Expression<Func<T, bool>> exp)
        {
            return _db.Set<T>().Where(exp).ToList();


        }
    }
}
