using SFAirBUdc.Application.Contracts.Contracts.Parameters;
using SFAirBUdc.Application.Contracts.DTO.parameters;
using SFAirBUdc.GUI.Mappers;
using SFAirBUdc.GUI.Mappers.Parameters;
using SFAirBUdc.GUI.Models.Parameters;
using SFAirBUdc.Repository.Contracts.DbModel.Parameters;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using Microsoft.Reporting.WebForms;
using SFAirBUdc.GUI.Models.ReportModels;
using System.Collections.Generic;
using SFAirBUdc.Repository.Implementatios.DataModel;
using System;

namespace SFAirBUdc.GUI.Controllers.Parameters
{
    public class ReservationController : Controller
    {
        IReservationApplication app;
        IPropertyApplication property;
        ICityApplication city;
        ICustomerApplication customer;
        ReservationMapperGui mapper = new ReservationMapperGui();

        public ReservationController(
            IReservationApplication reservation,
            IPropertyApplication property,
            ICityApplication city,
            ICustomerApplication customer)
        {
            app = reservation;
            this.property = property;
            this.city = city;
            this.customer = customer;
        }

        // GET: Reservation
        public ActionResult Index()
        {
            var list = mapper.MapperT1toT2(app.GellAllRecord());
            return View(list);
        }

        // GET: Reservation/Details/5
        public ActionResult Details(int id)
        {
            if (id <= 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ReservationModel reservationModel = mapper.MapperT1toT2(app.GetRecord(id));
            if (reservationModel == null)
            {
                return HttpNotFound();
            }
            return View(reservationModel);
        }

        // GET: Reservation/Create
        public ActionResult Create()
        {
            ReservationModel model = new ReservationModel();
            FillListForView(model);
            return View(model);
        }

        private void FillListForView(ReservationModel model)
        {
            CustomerMapperGui customerMapper = new CustomerMapperGui();
            model.CustomerList = customerMapper.MapperT1toT2(customer.GetAllRecords(string.Empty));
            PropertyMapperGui propertyMapper = new PropertyMapperGui();
            model.PropertyList = propertyMapper.MapperT1toT2(property.GetAllRecords(string.Empty));
        }

        // POST: Reservation/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ReservationModel reservationModel)
        {


            if (reservationModel == null || reservationModel.CustomerList == null || !reservationModel.CustomerList.Any()
                || reservationModel.PropertyList == null || !reservationModel.PropertyList.Any())
            {
                if (reservationModel == null)
                {
                    reservationModel = new ReservationModel();
                }
                FillListForView(reservationModel);
            }

            var selectedProperty = reservationModel.PropertyList?.FirstOrDefault(c => c.Id == reservationModel.Property?.Id);
            if (selectedProperty != null)
            {
                int value = selectedProperty.Id;
                PropertyDTO property = this.property.GetRecord(value);
                CityDTO ciudad = new CityMapperGUI().MapperT2toT1(selectedProperty.City);
                PropertyOwnerDTO propertyOwner = new PropertyOwnerMapperGUI().MapperT2toT1(selectedProperty.PropertyOwner);
                reservationModel.Property.City = new CityMapperGUI().MapperT1toT2(ciudad);
                reservationModel.Property.PropertyOwner = new PropertyOwnerMapperGUI().MapperT1toT2(propertyOwner);
            }
            ModelState.Remove("Property.PropertyAddress");
            ModelState.Remove("Property.CustomerAmount");
            ModelState.Remove("Property.Price");
            ModelState.Remove("Property.CityId");
            ModelState.Remove("Property.OwnerId");
            ModelState.Remove("Property.Latitude");
            ModelState.Remove("Property.Longitude");
            ModelState.Remove("Property.CheckinData");
            ModelState.Remove("Property.CheckoutData");
            ModelState.Remove("Property.Details");
            ModelState.Remove("Property.Pets");
            ModelState.Remove("Property.Freezer");
            ModelState.Remove("Property.LaundryService");

            ModelState.Remove("Customer.FirstName");
            ModelState.Remove("Customer.FamilyName");
            ModelState.Remove("CustomerEmail");
            ModelState.Remove("Customer.Cellphone");
            ModelState.Remove("Customer.Photo");

            ReservationModel modeloactual = new ReservationModel()
            {
                Id = reservationModel.Id,
                EnterDate = reservationModel.EnterDate,
                OutDate = reservationModel.OutDate,
                Price = reservationModel.Price,
                Property = reservationModel.Property,
                Customer = reservationModel.Customer
            };
            
            //if (ModelState.IsValid)
            //{
                ReservationDTO record = mapper.MapperT2toT1(modeloactual);
                app.CreateRecord(record);
                return RedirectToAction("Index");
            //}

            //return View(reservationModel);
         }


        // GET: Reservation/Edit/5
        public ActionResult Edit(int id)
        {
            if (id <= 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ReservationModel reservationModel = mapper.MapperT1toT2(app.GetRecord(id));
            if (reservationModel == null)
            {
                return HttpNotFound();
            }
            FillListForView(reservationModel);
            return View(reservationModel);
        }

        // POST: Reservation/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ReservationModel reservationModel)
        {
            FillListForView(reservationModel);
            var selectedProperty = reservationModel.PropertyList?.FirstOrDefault(c => c.Id == reservationModel.Property?.Id);
            if (selectedProperty != null)
            {
                int value = selectedProperty.Id;
                PropertyDTO property = this.property.GetRecord(value);
                CityDTO ciudad = new CityMapperGUI().MapperT2toT1(selectedProperty.City);
                PropertyOwnerDTO propertyOwner = new PropertyOwnerMapperGUI().MapperT2toT1(selectedProperty.PropertyOwner);
                reservationModel.Property.City = new CityMapperGUI().MapperT1toT2(ciudad);
                reservationModel.Property.PropertyOwner = new PropertyOwnerMapperGUI().MapperT1toT2(propertyOwner);
            }
            ModelState.Remove("Property.PropertyAddress");
            ModelState.Remove("Property.CustomerAmount");
            ModelState.Remove("Property.Price");
            ModelState.Remove("Property.CityId");
            ModelState.Remove("Property.OwnerId");
            ModelState.Remove("Property.Latitude");
            ModelState.Remove("Property.Longitude");
            ModelState.Remove("Property.CheckinData");
            ModelState.Remove("Property.CheckoutData");
            ModelState.Remove("Property.Details");
            ModelState.Remove("Property.Pets");
            ModelState.Remove("Property.Freezer");
            ModelState.Remove("Property.LaundryService");

            ModelState.Remove("Customer.FirstName");
            ModelState.Remove("Customer.FamilyName");
            ModelState.Remove("CustomerEmail");
            ModelState.Remove("Customer.Cellphone");
            ModelState.Remove("Customer.Photo");
            //if (ModelState.IsValid)
            //{
                ReservationDTO record = mapper.MapperT2toT1(reservationModel);
                app.UpdateRecord(record);
                return RedirectToAction("Index");
            //}
            //return View(reservationModel);
        }

        // GET: Reservation/Delete/5
        public ActionResult Delete(int id)
        {
            if (id <= 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ReservationModel reservationModel = mapper.MapperT1toT2(app.GetRecord(id));
            if (reservationModel == null)
            {
                return HttpNotFound();
            }
            return View(reservationModel);
        }

        // POST: Reservation/Delete/5
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
            var list = app.GellAllRecord();
            CityMapperGUI cityMapperGUI = new CityMapperGUI();
            List<PropertiesByReservationModel> recordsList = new List<PropertiesByReservationModel>();

            
            foreach (var property in list)
            {
                recordsList.Add(
                    new PropertiesByReservationModel
                    {
                        Id = property.Id.ToString(),
                        Price = property.Price.ToString(),
                        CustomerId = property.Customer.Id.ToString(),
                        FirstName = property.Customer.FirstName,
                        Address = property.Property.PropertyAddress,
                    });
            }
            string reportPath = Server.MapPath("~/Reports/RdlcFiles/ReservationByCustomReport.rdlc");
            //List<string> dataSets = new List<string> { "CustomerList" };
            // el local report nos permite renderizar el reporte , es decir, convertirlo a un formato que se pueda mostrar en el navegador
            LocalReport lr = new LocalReport();

            lr.ReportPath = reportPath;
            lr.EnableHyperlinks = true;

            Warning[] warnings;
            string[] streams;
            byte[] renderedBytes;
            string mimeType, encoding, fileNameExtension;

            ReportDataSource datasource = new ReportDataSource("ReservationByCustomer", recordsList);
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
