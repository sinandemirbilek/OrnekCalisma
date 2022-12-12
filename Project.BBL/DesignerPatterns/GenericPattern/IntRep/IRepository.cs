using Project.ENTITIES.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Project.BBL.DesignerPatterns.GenericPattern.IntRep
{
     public interface IRepository<T> where T: BaseEntity
    {
        //List Commands
        List<T> GetAll();
        List<T> GetUpdateds();
        List<T> GetDeleteds();
        List<T> GetActives();


        //Modify Commands

        void Add(T item);
        void AddRange(List<T> list);

        void Delete(T item);

        void DeleteRange(List<T> list);

        void Update(T item);
        void UpdateRange(List<T> list);
        void Destroy(T item);
        void DestroyRange(List<T> list);

        void SetActive(T item);
        void SetActiveRange(List<T> list);

        //Linq Expressions

        List<T> Where(Expression<Func<T, bool>> exp);
        bool Any(Expression<Func<T, bool>> exp);

        T FirstOrDefault(Expression<Func<T, bool>> exp);

        object Select(Expression<Func<T, object>> exp);

        //Find

        T Find(int id);

        //GetLastDatas

        List<T> GetLastDatas(int number);

        //GetFirstDatas
        List<T> GetFirstDatas(int number);

        
        


        
    }
}
