using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CvMvc.Models.Entity; //modelimi çağırıyoruz

namespace CvMvc.Controllers
{
    [AllowAnonymous]
    public class DefaultController : Controller
    {
        // GET: Default
        DbCvEntities db = new DbCvEntities();

        public DbCvEntities Db { get => db; set => db = value; }

        public ActionResult Index()
        {
            var degerler = db.TblHakkimda.ToList(); // hakkımda tablomu listele
            return View(degerler);
        }
        public PartialViewResult SosyalMedya()
        {
            var sosyalmedya = db.TblSosyalMedya.Where(x => x.Durum == true).ToList();
            return PartialView(sosyalmedya);
        }
        public PartialViewResult Deneyim() //bir sayfada birden fazla parça veya alan kullanmak için kullanılır 
        {
            var deneyimler = db.TblDeneyimlerim.ToList();
            return PartialView(deneyimler);  //deneyimler i döndür
        }
        public PartialViewResult Egitimlerim()
        {
            var egitimler = db.TblEgitimlerim.ToList();
            return PartialView(egitimler);  //egitimler i döndür
        }
        public PartialViewResult Yeteneklerim()
        {
            var yeteneklerim = db.TblYeteneklerim.ToList();
            return PartialView(yeteneklerim);
        }
        public PartialViewResult Hobilerim()
        {
            var hobilerim = db.TblHobilerim.ToList();
            return PartialView(hobilerim);
        }
        public PartialViewResult Sertifikalar()
        {
            var sertifikalar = db.TblSertifikalarım.ToList();
            return PartialView(sertifikalar);
        }
        [HttpGet]
        public PartialViewResult Iletisim()  //aynı isimde iki adet methot tanımladık birinci methodum hhtget yani formum yüklendiği zaman çalışacak
        {
            return PartialView();
        }
        [HttpPost]    //ikinci methdum post olduğu zaman çalışacak eğer tek method üzerinde işlemlerimizi yapmak isteseydik bir kere kaydedecek kaydettiksen sonra sayfa yüklendikten sonra post işlemi uygulanacağından dolayı bir de boş kaydedecek iki defa kaydetmiş olacak
        public PartialViewResult Iletisim(TblIletisim t)    //tbliletisim den t isminde bir parametre türettik
        {
            t.Tarih = DateTime.Parse(DateTime.Now.ToShortDateString()); //t. yaptıktan sonra tbl iletişim tablomuzdaki proplara erişebiliyoruz
            db.TblIletisim.Add(t); //t den gelen değerleri ekle db ye 
            db.SaveChanges();
            return PartialView();
        }
    }
}