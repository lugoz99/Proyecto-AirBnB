using SFAirBUdc.Application.Contracts.Contracts.Parameters;
using SFAirBUdc.Application.Contracts.DTO.parameters;
using SFAirBUdc.GUI.Mappers.Parameters;
using SFAirBUdc.GUI.Models.Parameters;
using System.Net;
using System.Web.Mvc;

namespace SFAirBUdc.GUI.Controllers
{
    public class CustomerController : Controller
    {
        private readonly ICustomerApplication _app;
        CustomerMapperGui mapper = new CustomerMapperGui();


        public CustomerController(ICustomerApplication app)
        {
            this._app = app; 
        }

        // GET: Customer
        public ActionResult Index(string filter = "")
        {
            var list = mapper.MapperT1toT2(_app.GetAllRecords(filter));
            return View(list);
        }

        // GET: Customer/Details/5
        public ActionResult Details(int? id)
        {
            if (id <= 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CustomerModel record = mapper.MapperT1toT2(_app.GetRecord((int)id));
            if (record == null)
            {
                return HttpNotFound();
            }
            return View(record);
        }

        // GET: Customer/Create
        public ActionResult Create()
        {
            CustomerModel model = new CustomerModel();

            return View(model);
        }

        // POST: Customer/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,FirstName,FamilyName,Cellphone,Email,Photo")] CustomerModel customerModel)
        {
            if (ModelState.IsValid)
            {
                CustomerDTO record = mapper.MapperT2toT1(customerModel);
                _app.CreateRecord(record);
                return RedirectToAction("Index");
            }

            return View(customerModel);
        }

        // GET: Customer/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CustomerDTO customerModel = _app.GetRecord((int)id);  

            if (customerModel == null)
            {
                return HttpNotFound();
            }
            return View(mapper.MapperT1toT2(customerModel) );
        }

        // POST: Customer/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,FirstName,FamilyName,Cellphone,Email,Photo")] CustomerModel customerModel)
        {
            if (ModelState.IsValid)
            {

                CustomerDTO record = mapper.MapperT2toT1(customerModel);
                _app.UpdateRecord(record);
                return RedirectToAction("Index");
            }
            return View(customerModel);
        }

        // GET: Customer/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id <= 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CustomerModel record = mapper.MapperT1toT2(_app.GetRecord((int)id));
            if (record == null)
            {
                return HttpNotFound();
            }
            return View(record);
        }

        // POST: Customer/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            _app.DeleteRecord((int)id);
            return RedirectToAction("Index");
        }

     
    }
}
