using evolution_gym.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace evolution_gym.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        DataDataContext db = new DataDataContext();

        public ActionResult Index()
        {
            List<IsciMain> isci = new List<IsciMain>();
            ViewBag.isci = db.IsciMains.ToList();

            List<Vezife> vezife = new List<Vezife>();
            ViewBag.vezife = db.Vezifes.ToList();

            List<Filial> filial = db.Filials.ToList();
            ViewBag.filial = db.Filials.ToList();
            return View();
        }

        public ActionResult insertisci(Isci newisci)
        {
            db.Iscis.InsertOnSubmit(newisci);
            db.SubmitChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Deleteisci(int id)
        {
            db.Iscis.DeleteOnSubmit(db.Iscis.SingleOrDefault(x => x.IsciId == id));
            db.SubmitChanges();
            return RedirectToAction("Index");
        }

        

        public ActionResult editisci(int id)
        {
            List<Vezife> vezife = new List<Vezife>();
            ViewBag.vezife = db.Vezifes.ToList();

            List<Filial> filial = db.Filials.ToList();
            ViewBag.filial = db.Filials.ToList();

            

            List<IsciBildiri> iscibildiri = new List<IsciBildiri>();
            ViewBag.iscibildiri = db.IsciBildiris.ToList();

            ViewBag.isi = db.Iscis.SingleOrDefault(x => x.IsciId == id);
            return View();
        }
        public ActionResult updateisci(int id, Isci newisci)
        {
            Isci oldisci = db.Iscis.SingleOrDefault(x => x.IsciId == id);
            oldisci.IsciAd = newisci.IsciAd;
            oldisci.IsciSoyad = newisci.IsciSoyad;
            oldisci.IsciVezifeId = newisci.IsciVezifeId;
            oldisci.IsciFilialId = newisci.IsciFilialId;
            oldisci.IsciIseBaslamaTarixi = newisci.IsciIseBaslamaTarixi;
            oldisci.IsciResmiMaas = newisci.IsciResmiMaas;
            oldisci.IsciMotivasiyaMaas = newisci.IsciMotivasiyaMaas;
            db.SubmitChanges();
            return RedirectToAction("Index");
        }


        public ActionResult telebe()
        {
            List<TelebeMain> telebe = new List<TelebeMain>();
            ViewBag.telebe = db.TelebeMains.ToList();

            List<Filial> filial = db.Filials.ToList();
            ViewBag.filial = db.Filials.ToList();

            List<Trainer> trainer = db.Trainers.ToList();
            ViewBag.trainer = db.Trainers.ToList();

            return View();
        }

        public ActionResult inserttelebe(Telebe newtelebe)
        {
            db.Telebes.InsertOnSubmit(newtelebe);
            db.SubmitChanges();
            return RedirectToAction("telebe");
        }

        public ActionResult Deletetelebe(int id)
        {
            db.Telebes.DeleteOnSubmit(db.Telebes.SingleOrDefault(x => x.Telebeİd == id));
            db.SubmitChanges();
            return RedirectToAction("telebe");
        }

        public ActionResult edittelebe(int id)
        {

            List<Filial> filial = db.Filials.ToList();
            ViewBag.filial = db.Filials.ToList();

            List<Trainer> trainer = db.Trainers.ToList();
            ViewBag.trainer = db.Trainers.ToList();

            List<Bildiri> bildiris = new List<Bildiri>();
            ViewBag.bildiris = db.Bildiris.ToList();


            ViewBag.tel = db.Telebes.SingleOrDefault(x => x.Telebeİd == id);
            return View();
        }

        public ActionResult updatetelebe(int id, Telebe newtelebe)
        {
            Telebe oldtelebe = db.Telebes.SingleOrDefault(x => x.Telebeİd == id);
            oldtelebe.TelebeAd = newtelebe.TelebeAd;
            oldtelebe.TelebeSoyad = newtelebe.TelebeSoyad;
            oldtelebe.TelebeFilialId = newtelebe.TelebeFilialId;
            oldtelebe.TelebeTrainerId = newtelebe.TelebeTrainerId;
            oldtelebe.TelebeMesqeBaslamaTarixi = newtelebe.TelebeMesqeBaslamaTarixi;
            oldtelebe.TelebeAyliqOdenis = newtelebe.TelebeAyliqOdenis;
            db.SubmitChanges();
            return RedirectToAction("telebe");
        }


        public ActionResult comunal()
        {
            List<ComunalMain> comunal = new List<ComunalMain>();
            ViewBag.comunal = db.ComunalMains.ToList();

            List<Filial> filial = db.Filials.ToList();
            ViewBag.filial = db.Filials.ToList();

            return View();
        }

        public ActionResult insertcomunal(Comunal newcomunal)
        {
            db.Comunals.InsertOnSubmit(newcomunal);
            db.SubmitChanges();
            return RedirectToAction("comunal");
        }

        public ActionResult Deletecomunal(int id)
        {
            db.Comunals.DeleteOnSubmit(db.Comunals.SingleOrDefault(x => x.ComunalId == id));
            db.SubmitChanges();
            return RedirectToAction("comunal");
        }

        public ActionResult editcomunal(int id)
        {

            List<Filial> filial = db.Filials.ToList();
            ViewBag.filial = db.Filials.ToList();

            ViewBag.com = db.Comunals.SingleOrDefault(x => x.ComunalId == id);
            return View();
        }

        public ActionResult updatecomunal(int id, Comunal newcomunal)
        {
            Comunal oldcomunal = db.Comunals.SingleOrDefault(x => x.ComunalId == id);
            oldcomunal.ComunalAd = newcomunal.ComunalAd;
            oldcomunal.ComunalTarix = newcomunal.ComunalTarix;
            oldcomunal.ComunalFilialId = newcomunal.ComunalFilialId;
            oldcomunal.ComunalMiqdar = newcomunal.ComunalMiqdar;
            db.SubmitChanges();
            return RedirectToAction("comunal");
        }

        public ActionResult arenda()
        {
            List<ArendaMain> arenda = new List<ArendaMain>();
            ViewBag.arenda = db.ArendaMains.ToList();

            List<Filial> filial = db.Filials.ToList();
            ViewBag.filial = db.Filials.ToList();

           
            return View();
        }

        public ActionResult insertarenda(Arenda newarenda)
        {
            db.Arendas.InsertOnSubmit(newarenda);
            db.SubmitChanges();
            return RedirectToAction("arenda");
        }

        public ActionResult Deletearenda(int id)
        {
            db.Arendas.DeleteOnSubmit(db.Arendas.SingleOrDefault(x => x.ArendaId == id));
            db.SubmitChanges();
            return RedirectToAction("arenda");
        }


        public ActionResult editarenda(int id)
        {

            List<Filial> filial = db.Filials.ToList();
            ViewBag.filial = db.Filials.ToList();


            ViewBag.are = db.Arendas.SingleOrDefault(x => x.ArendaId == id);
            return View();
        }

        public ActionResult updatearenda(int id, Arenda newarenda)
        {
            Arenda oldarenda = db.Arendas.SingleOrDefault(x => x.ArendaId == id);
            oldarenda.ArendaFilialId = newarenda.ArendaFilialId;
            oldarenda.ArendaOdenisTarixi = newarenda.ArendaOdenisTarixi;
            oldarenda.ArendaAyliqOdenis = newarenda.ArendaAyliqOdenis;
            db.SubmitChanges();
            return RedirectToAction("arenda");
        }

        public ActionResult telebebildiris()
        {
            List<Bildiri> bildiris = new List<Bildiri>();
            ViewBag.bildiris = db.Bildiris.ToList();
            //var zahir = db.Bildiris.ToList();
            return View();
        }
        public new ActionResult View()
        {
            List<Bildiri> bildiris = new List<Bildiri>();
            ViewBag.bildiris = db.Bildiris.ToList();
            return PartialView();
        }
        
        public ActionResult iscibildiris()
        {
            List<IsciBildiri> iscibildiri = new List<IsciBildiri>();
            ViewBag.iscibildiri = db.IsciBildiris.ToList();
            return View();
        }
        
        public ActionResult viewisci()
        {
            List<IsciBildiri> iscibildiri = new List<IsciBildiri>();
            ViewBag.iscibildiri = db.IsciBildiris.ToList();
            return PartialView();
                
        }

        
    }
}

