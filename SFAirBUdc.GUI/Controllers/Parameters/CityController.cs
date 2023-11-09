using SFAirBUdc.Application.Contracts.Contracts.Parameters;
using SFAirBUdc.Application.Contracts.DTO.parameters;
using SFAirBUdc.Application.Implementation.Implementation.Parameters;
using SFAirBUdc.Application.Implementation.Implementation.Parameters.AirbnbUdc.Application.Implementation.Implementation.Parameters;
using SFAirBUdc.GUI.Mappers.Parameters;
using SFAirBUdc.GUI.Models.Parameters;
using System.Diagnostics;
using System.Net;
using System.Web.Mvc;

namespace SFAirBUdc.GUI.Controllers.Parameters
{
    public class CityController : Controller
    {
        private ICityApplication app = new CityImplementationApplication();
        private ICountryApplication countryapp = new CountryImplementationApplication();
        CityMapperGUI mapper = new CityMapperGUI();


        // GET: City
        public ActionResult Index(string filter = "")
        {
            var list = mapper.MapperT1toT2(app.GetAllRecords(filter));
            return View(list);
        }

        // GET: CityModels/Details/5
        public ActionResult Details(int id)
        {
            if (id <= 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CityModel cityModel = mapper.MapperT1toT2(app.GetRecord(id));
            if (cityModel == null)
            {
                return HttpNotFound();
            }
            return View(cityModel);
        }

        // GET: CityModels/Create
        public ActionResult Create()
        {

            CityModel model = new CityModel();
            FillListForView(model);
            return View(model);
        }

        private void FillListForView(CityModel model)
        {
            CountryMapperGUI countryMapper = new CountryMapperGUI();
            model.CountryList = countryMapper.MapperT1toT2(countryapp.GetAllRecords(string.Empty));
        }

        // POST: CityModels/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CityModel cityModel)
        {
            // del objeto country no me tenga en cuenta el Name
            ModelState.Remove("Country.Name");
            if (ModelState.IsValid)
            {
                CityDTO cityDTO = mapper.MapperT2toT1(cityModel);
                app.CreateRecord(cityDTO);
                return RedirectToAction("Index");
            }

            return View(cityModel);
        }

        // GET: CityModels/Edit/5
        public ActionResult Edit(int id)
        {
            if (id <= 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CityModel cityModel = mapper.MapperT1toT2(app.GetRecord(id));
            if (cityModel == null)
            {
                return HttpNotFound();
            }
            // llena la lista de paises
            FillListForView(cityModel);
            return View(cityModel);
        }

        // POST: CityModels/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(CityModel cityModel)
        {
            Debug.WriteLine($"city debug Id: {cityModel.Country.Id}");
            Debug.WriteLine($"city debug Id: {cityModel.Name}");
            ModelState.Remove("Country.Name");
            FillListForView(cityModel);
            if (ModelState.IsValid)
            {
                Debug.WriteLine($"Entre aqui: {cityModel.Country.Id}");

                CityDTO cityDTO = mapper.MapperT2toT1(cityModel);
                app.UpdateRecord(cityDTO);
                return RedirectToAction("Index");
            }
            return View(cityModel);
        }

        // GET: CityModels/Delete/5
        public ActionResult Delete(int id)
        {
            if (id <= 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CityModel cityModel = mapper.MapperT1toT2(app.GetRecord(id));
            if (cityModel == null)
            {
                return HttpNotFound();
            }
            return View(cityModel);
        }

        // POST: CityModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            app.DeleteRecord(id);
            return RedirectToAction("Index");
        }

    }
}
