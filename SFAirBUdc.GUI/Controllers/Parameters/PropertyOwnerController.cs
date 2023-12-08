using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Diagnostics;
using System.Net;
using System.Web.Mvc;
using SFAirBUdc.Application.Contracts.Contracts.Parameters;
using SFAirBUdc.Application.Contracts.DTO.parameters;
using SFAirBUdc.GUI.Mappers;
using SFAirBUdc.GUI.Models;
using SFAirBUdc.GUI.Models.Parameters;
using SFAirBUdc.Repository.Contracts.DbModel.Parameters;
using SFAirBUdc.Repository.Implementatios.DataModel;

namespace SFAirBUdc.GUI.Controllers.Parameters
{
    public class PropertyOwnerController : Controller
    {
        IPropertyOwnerApplication app;
        PropertyOwnerMapperGUI mapper = new PropertyOwnerMapperGUI();

        public PropertyOwnerController(IPropertyOwnerApplication repository)
        {
            this.app = repository;
        }

        // GET: PropertyOwner
        public ActionResult Index(string filter = "")
        {
            var list = mapper.MapperT1toT2(app.GetAllRecords(filter));
            return View(list);
        }

        // GET: PropertyOwner/Details/5
        public ActionResult Details(long? id)
        {
            if (id <= 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PropertyOwnerModel cityModel = mapper.MapperT1toT2(app.GetRecord((int)id));
            if (cityModel == null)
            {
                return HttpNotFound();
            }
            return View(cityModel);
        }

        // GET: PropertyOwner/Create
        public ActionResult Create()
        {
            CityModel model = new CityModel();
            return View(model);
        }

        // POST: PropertyOwner/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(PropertyOwnerModel propertyOwner)
        {
            if (ModelState.IsValid)
            {
                if (ModelState.IsValid)
                {
                    PropertyOwnerDTO record = mapper.MapperT2toT1(propertyOwner);
                    app.CreateRecord(record);
                    return RedirectToAction("Index");
                }

                return View(propertyOwner);
            }

            return View(propertyOwner);
        }

        // GET: PropertyOwner/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id <= 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PropertyOwnerModel record = mapper.MapperT1toT2(app.GetRecord((int)id));
            if (record == null)
            {
                return HttpNotFound();
            }
            // llena la lista de paises
            return View(record);
        }

        // POST: PropertyOwner/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,FirstName,FamilyName,Email,Cellphone,Photo")] PropertyOwnerModel propertyOwner)
        {
            if (ModelState.IsValid)
            {
                PropertyOwnerDTO record = mapper.MapperT2toT1(propertyOwner);
                app.UpdateRecord(record);
                return RedirectToAction("Index");
            }
            return View(propertyOwner);
        }

        // GET: PropertyOwner/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id <= 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PropertyOwnerModel record = mapper.MapperT1toT2(app.GetRecord((int)id));
            if (record == null)
            {
                return HttpNotFound();
            }
            return View(record);
        }

        // POST: PropertyOwner/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            app.DeleteRecord((int)id);
            return RedirectToAction("Index");
        }

       
    }
}
