using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Microsoft.Reporting.WebForms;
using SFAirBUdc.Application.Contracts.Contracts.Parameters;
using SFAirBUdc.Application.Contracts.DTO.parameters;
using SFAirBUdc.Application.Implementation.Implementation.Parameters;
using SFAirBUdc.GUI.Mappers;
using SFAirBUdc.GUI.Mappers.Parameters;
using SFAirBUdc.GUI.Models.Parameters;
using SFAirBUdc.GUI.Models.ReportModels;

namespace SFAirBUdc.GUI.Controllers.Parameters
{
    public class PropertyController : Controller
    {
        private IPropertyApplication app;
        private ICityApplication cityApp;
        private IPropertyOwnerApplication propertyOwnerApp;
        private ICountryApplication countryApp;

        PropertyMapperGui mapper = new PropertyMapperGui();

        public PropertyController(IPropertyApplication app, ICityApplication cityApp, IPropertyOwnerApplication propertyOwnerApp,ICountryApplication country)
        {
            this.app = app;
            this.cityApp = cityApp;
            this.propertyOwnerApp = propertyOwnerApp;
            this.countryApp = country;
        }
        // GET: Property
        public ActionResult Index(string filter = "")
        {
            var list = mapper.MapperT1toT2(app.GetAllRecords(filter));
            return View(list);
        }

        // GET: Property/Details/5
        public ActionResult Details(int id)
        {
            if (id <= 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PropertyModel propertyModel = mapper.MapperT1toT2(app.GetRecord(id));
            if (propertyModel == null)
            {
                return HttpNotFound();
            }
            return View(propertyModel);
        }

        // GET: Property/Create
        public ActionResult Create()
        {
            PropertyModel model = new PropertyModel();
            FillListForView(model);

            return View(model);
        }

        private void FillListForView(PropertyModel model)
        {
            CityMapperGUI cityMapper = new CityMapperGUI();
            model.CityList = cityMapper.MapperT1toT2(cityApp.GetAllRecords(string.Empty));

            PropertyOwnerMapperGUI propertyOwnerMapper = new PropertyOwnerMapperGUI();
            model.PropertyOwnerList = propertyOwnerMapper.MapperT1toT2(propertyOwnerApp.GetAllRecords(string.Empty));
        }
        // POST: Property/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(PropertyModel propertyModel)
        {
            if (propertyModel == null || propertyModel.CityList == null || !propertyModel.CityList.Any()
                || propertyModel.PropertyOwnerList == null || !propertyModel.PropertyOwnerList.Any())
            {
                if(propertyModel == null)
                {
                    propertyModel = new PropertyModel();
                }
                FillListForView(propertyModel);
            }
            var selectedCity = propertyModel.CityList?.FirstOrDefault(c => c.Id == propertyModel.City?.Id);

            if (selectedCity != null)
            {
                int value = selectedCity.Id;
                CityDTO citycountry = cityApp.GetRecord(value);
                CountryDTO country = countryApp.GetRecord(citycountry.Country.Id);
                propertyModel.City.Country = new CountryMapperGUI().MapperT1toT2(country);
            }

            ModelState.Remove("City.Name");
            ModelState.Remove("City.Country");
            ModelState.Remove("PropertyOwner.FirstName");
            ModelState.Remove("PropertyOwner.FamilyName");
            ModelState.Remove("PropertyOwner.Email");
            ModelState.Remove("PropertyOwner.Cellphone");
            ModelState.Remove("PropertyOwner.Photo");

            if (ModelState.IsValid)
            {
                PropertyDTO propertyDTO = mapper.MapperT2toT1(propertyModel);
                app.CreateRecord(propertyDTO);
                return RedirectToAction("Index");
            }
            return View(propertyModel);
        }


        // GET: Property/Edit/5
        public ActionResult Edit(int id)
        {
            if (id <= 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PropertyModel propertyModel = mapper.MapperT1toT2(app.GetRecord(id));
            if (propertyModel == null)
            {
                return HttpNotFound();
            }
            FillListForView(propertyModel);
            return View(propertyModel);
        }

        // POST: Property/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,PropertyAddress,CustomerAmount,Price,Latitude,Longitude,CheckinData,CheckoutData,Details,Pets,Freezer,LaundryService")] PropertyModel propertyModel)
        {
            if (ModelState.IsValid)
            {
                PropertyDTO propertyDTO = mapper.MapperT2toT1(propertyModel);
                app.UpdateRecord(propertyDTO);
                return RedirectToAction("Index");
            }
            return View(propertyModel);
        }

        // GET: Property/Delete/5
        public ActionResult Delete(int id)
        {
            if (id <= 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PropertyModel propertyModel = mapper.MapperT1toT2(app.GetRecord(id));
            if (propertyModel == null)
            {
                return HttpNotFound();
            }
            return View(propertyModel);
        }

        // POST: Property/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            app.DeleteRecord(id);
            return RedirectToAction("Index");
        }


        public ActionResult GenerateReport(string format = "PDF")
        {
            // traer todas las ciudades
            var list = app.GetAllRecords(string.Empty);
            CityMapperGUI cityMapperGUI = new CityMapperGUI();
            List<PropertiesByCityReportModel> recordsList = new List<PropertiesByCityReportModel>();

            // para cada ciudad que esta en la lista, la convierto a un objeto de tipo CitiesByCountryReportModel
            foreach (var city in list)
            {
                recordsList.Add(
                    new PropertiesByCityReportModel()
                    {
                        Id = city.Id.ToString(),
                        Details = city.Details,
                        CityId = city.City.Id.ToString(),
                        Name = city.City.Name,
                    });
            }

            string reportPath = Server.MapPath("~/Reports/RdlcFiles/propertiesByCustomerReport.rdlc");
            //List<string> dataSets = new List<string> { "CustomerList" };
            // el local report nos permite renderizar el reporte , es decir, convertirlo a un formato que se pueda mostrar en el navegador
            LocalReport lr = new LocalReport();

            lr.ReportPath = reportPath;
            lr.EnableHyperlinks = true;

            Warning[] warnings;
            string[] streams;
            byte[] renderedBytes;
            string mimeType, encoding, fileNameExtension;

            ReportDataSource datasource = new ReportDataSource("propertiesByCustomerDataSet", recordsList);
            lr.DataSources.Add(datasource);


            renderedBytes = lr.Render(
            format,
            string.Empty,
            out mimeType,
            out encoding,
            out fileNameExtension,
            out streams,
            out warnings
            );
            // renderizo el reporte Y se muestra en el navegador
            return File(renderedBytes, mimeType);
        }

    }
}
