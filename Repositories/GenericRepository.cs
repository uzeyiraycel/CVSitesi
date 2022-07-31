using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using Mvc5Cv.Models.Entity;

namespace Mvc5Cv.Repositories
{
    public class GenericRepository<T> where T:class,new() //GenericRepository T türünde sınıfları alır ve new lene bilir. yani düzenlenebilir.
    {
        //Repository design pattern: crud işlemlerinde tekrara düşmemek için kullanırız.
        //generic repository de crud işlemlerin iskeletini oluşturuyoruz. ardından diğer sınıflara genericrepository i kalıtım olarak alıyoruz.

        DbCvEntities db = new DbCvEntities();

        public List<T> List() //Listeleme için iskelet bu olacak. T yerine hangi sınıf üzerinde işlem yapacaksak o sınıf gelecek.
        {
            return db.Set<T>().ToList();
            //geriye değer döndürecek . geriye döndürdüğü değer ise T tablosunu liste biçiminde dönderecek. dönecek değer (ToList()) ile döndürülecek değer (List<T>) aynı olmak zorunda olduğu için public List<T> olarak tanımladık.
        }

        public void Tadd(T p1) //Ekleme için iskelet
        {
            db.Set<T>().Add(p1);
            db.SaveChanges();
            //Burada geriye değer döndürmeyecek direk ekleyecek
        }
        public void TDelete(T p1) //Silme için iskelet
        {
            db.Set<T>().Remove(p1);
            db.SaveChanges();
            //Burada geriye değer döndürmeyecek direk silecek
        }

        public void TUpdate(T p1) //Güncelleme için iskelet
        {
            db.SaveChanges();
            //Burada geriye değer döndürmeyecek direk güncelleyecek.
        }

        public T TGet(int id) //İd değer bulma iskeleti. silmelerde ve güncellemelerde id buldurmak için kullanacağımızdan burda iskelet oluşturduk. get burda getirden gelsin aklına almak yani.
        {
            return db.Set<T>().Find(id);
            //Burada ise gene T tablosu türünde bulduracak ama buldurmayı id üzerinden yaptıracak. yani id yi bulup tüm o id ye ait bilgileri tutacak. geriye T değerlerini döndereceği için de return lü oldu buda List gibi.
        }

        //Find metodu ise diğer bir bulma metodu olarak düşünebiliriz. Yani burada illa id ye göre bulma değilde where dediğimiz için ne olarak aratmak istiyorsak ona göre buldurabiliriz. Bu yöntemi kullanmadım ben bilmek için buraya yazdım.

        //public T Find(Expression<Func<T,bool>> where)
        //{
        //    return db.Set<T>().FirstOrDefault(where);
        //}
    }
}