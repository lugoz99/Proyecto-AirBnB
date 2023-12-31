﻿using SFAirBUdc.Application.Contracts.Contracts.Parameters;
using SFAirBUdc.Application.Contracts.DTO.parameters;
using SFAirBUdc.GUI.Mappers.Parameters;
using SFAirBUdc.GUI.Models.Parameters;
using System;
using System.Diagnostics;
using System.Net;
using System.Web.Mvc;

namespace SFAirBUdc.GUI.Controllers.Parameters
{
    public class CountryController : Controller
    {
        private ICountryApplication app;

        CountryMapperGUI mapper = new CountryMapperGUI();

        public CountryController(ICountryApplication _repository)
        {
           this.app = _repository;
        }

        // GET: CountryModels
        public ActionResult Index(string filter = "")
        {
            var list = mapper.MapperT1toT2(app.GetAllRecords(filter));
            return View(list);
        }

        // GET: CountryModels/Details/5
        public ActionResult Details(int id)
        {
            if (id <= 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CountryModel countryModel = mapper.MapperT1toT2(app.GetRecord(id));
            if (countryModel == null)
            {
                return HttpNotFound();
            }
            return View(countryModel);
        }

        // GET: CountryModels/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CountryModels/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name")] CountryModel countryModel)
        {
            System.Diagnostics.Trace.WriteLine($"Id: {countryModel.Id}, Name: {countryModel.Name}");
            Debug.WriteLine($"Id: {countryModel.Id}, Name: {countryModel.Name}");
            if (ModelState.IsValid)
            {
                CountryDTO countryDTO = mapper.MapperT2toT1(countryModel);
                Debug.WriteLine($"Id: {countryModel.Id}, Country dto: {countryDTO.Name}");
                app.CreateRecord(countryDTO);
                return RedirectToAction("Index");
            }

            return View(countryModel);
        }

        // GET: CountryModels/Edit/5
        public ActionResult Edit(int id)
        {
            if (id <= 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CountryModel countryModel = mapper.MapperT1toT2(app.GetRecord(id));
            if (countryModel == null)
            {
                return HttpNotFound();
            }
            return View(countryModel);
        }

        // POST: CountryModels/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name")] CountryModel countryModel)
        {
            if (ModelState.IsValid)
            {
                CountryDTO countryDTO = mapper.MapperT2toT1(countryModel);
                app.UpdateRecord(countryDTO);
                return RedirectToAction("Index");
            }
            return View(countryModel);
        }

        // GET: CountryModels/Delete/5
        public ActionResult Delete(int id)
        {
            if (id <= 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CountryModel countryModel = mapper.MapperT1toT2(app.GetRecord(id));
            if (countryModel == null)
            {
                return HttpNotFound();
            }
            return View(countryModel);
        }

        // POST: CountryModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            app.DeleteRecord(id);
            return RedirectToAction("Index");
        }

    }
}
