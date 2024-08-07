using DataAccess;
using Infrastructure.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CBTDWeb.Pages.Manufacturers
{
    public class UpsertModel : PageModel
    {
        private readonly UnitOfWork _UnitOfWork;
        [BindProperty]  //synchronizes form fields with values in code behind
        public Manufacturer? objManufacturer { get; set; }

        public UpsertModel(UnitOfWork unitOfWork)  //dependency injection
        {
            _UnitOfWork = unitOfWork;
        }

        public IActionResult OnGet(int? id)

        {
            objManufacturer = new Manufacturer();

            //am I in edit mode?
            if (id != 0)
            {
                objManufacturer = _UnitOfWork.Manufacturer.GetById(id);
            }

            if (objManufacturer == null)  //nothing found in DB
            {
                return NotFound();   //built in page
            }

            //assuming I'm in create mode
            return Page();
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            //if this is a new category
            if (objManufacturer.Id == 0)
            {
                _UnitOfWork.Manufacturer.Add(objManufacturer);
                TempData["success"] = "Manufaturer added Successfully";
            }
            //if category exists
            else
            {
                _UnitOfWork.Manufacturer.Update(objManufacturer);
                TempData["success"] = "Manufacturer updated Successfully";
            }
            _UnitOfWork.Commit();

            return RedirectToPage("./Index");
        }


    }
}