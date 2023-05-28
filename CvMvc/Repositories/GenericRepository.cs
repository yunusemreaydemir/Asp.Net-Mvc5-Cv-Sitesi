using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.Mvc;
using CvMvc.Models.Entity;

namespace CvMvc.Repositories
{
    public class GenericRepository<T> where T : class, new()  //t türettik
    {
        DbCvEntities db = new DbCvEntities(); //entity framework komutları ile generic yapı kurma 
        public List<T> List() //listeleme framework komutu
        {
            return db.Set<T>().ToList(); //bana geriye t den gelen değeri liste olarak döndür, t bütün tablolarımız olabilir
        }
        public void TAdd(T p) //ekleme framework komutu
        {
            db.Set<T>().Add(p);
            db.SaveChanges();
        }
        public void TDelete(T p) //silme framework komutu
        {
            db.Set<T>().Remove(p);
            db.SaveChanges();
        }
        public T TGet(int id)
        {
            return db.Set<T>().Find(id);
        }
        public void TUpdate(T p) // T den gelen p parametresi türettik 
        {
            db.SaveChanges();
        }
        public T Find(Expression<Func<T, bool>> where)
        {
            return db.Set<T>().FirstOrDefault(where);
        }
    }
}
