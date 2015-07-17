using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Homework001.Models;

namespace Homework001.Controllers
{
    public class ContractController : Controller
    {
        private 客戶聯絡人Repository repo = RepositoryHelper.Get客戶聯絡人Repository();

        // GET: Contract
        public ActionResult Index()
        {
            var 客戶聯絡人 = repo.All().Include(客 => 客.客戶資料);

            return View(客戶聯絡人.ToList());
        }

        // GET: Contract/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            客戶聯絡人 客戶聯絡人 = repo.Find(id.Value);

            if (客戶聯絡人 == null)
            {
                return HttpNotFound();
            }
            return View(客戶聯絡人);
        }

        // GET: Contract/Create
        public ActionResult Create()
        {
            ViewBag.客戶Id = new SelectList(repo.All(), "Id", "客戶名稱");
            return View();
        }

        // POST: Contract/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,客戶Id,職稱,姓名,Email,手機,電話")] 客戶聯絡人 contract)
        {
            if (ModelState.IsValid)
            {
                repo.Add(contract);
                repo.UnitOfWork.Commit();

                return RedirectToAction("Index");
            }

            ViewBag.客戶Id = new SelectList(repo.All(), "Id", "客戶名稱", contract.客戶Id);
            return View(contract);
        }

        // GET: Contract/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            客戶聯絡人 客戶聯絡人 = repo.Find(id.Value);
            if (客戶聯絡人 == null)
            {
                return HttpNotFound();
            }
            ViewBag.客戶Id = new SelectList(repo.All(), "Id", "客戶名稱", 客戶聯絡人.客戶Id);
            return View(客戶聯絡人);
        }

        // POST: Contract/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,客戶Id,職稱,姓名,Email,手機,電話")] 客戶聯絡人 contract)
        {
            if (ModelState.IsValid)
            {
                repo.UnitOfWork.Context.Entry(contract).State = EntityState.Modified;
                repo.UnitOfWork.Commit();

                return RedirectToAction("Index");
            }
            ViewBag.客戶Id = new SelectList(repo.All(), "Id", "客戶名稱", contract.客戶Id);
            return View(contract);
        }

        // GET: Contract/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            客戶聯絡人 客戶聯絡人 = repo.Find(id.Value);
            if (客戶聯絡人 == null)
            {
                return HttpNotFound();
            }
            return View(客戶聯絡人);
        }

        // POST: Contract/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            客戶聯絡人 contract = repo.Find(id);
            repo.Delete(contract);
            repo.UnitOfWork.Commit();

            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                repo.UnitOfWork.Context.Dispose();
            }
            base.Dispose(disposing);
        }


        //TODO: 檢查同一客戶之聯絡人 Email是否重覆。
        //private bool IsEmailDuplicated(客戶聯絡人 contract)
        //{
        //    if (db.客戶聯絡人.Count(c => (c.客戶Id == contract.客戶Id && c.Email == contract.Email)) >= 1)
        //    {
        //        ModelState.AddModelError("Email", "該客戶聯絡人，Email已存在，不可重複");
        //        return false;
        //    }

        //    return true;
        //}
    }
}
