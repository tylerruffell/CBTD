using DataAccess;
using Infrastructure.Interfaces;
using Infrastructure.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CBTDWeb.Pages.Categories
{
    public class IndexModel : PageModel
    {
        private readonly UnitOfWork _UnitOfWork;  //local instance of the database service

        public List<Category> objCategoryList;  //our UI front end will support looping through and displaying Categories retrieved from the database and stored in a List

        public IndexModel(UnitOfWork unitOfWork)  //dependency injection of the database service
        {
            _UnitOfWork = unitOfWork;
            objCategoryList = new List<Category>();
        }

        public IActionResult OnGet()
        /*Here are some common implementations of IActionResult:
		ViewResult: Represents a view result, which renders a view to generate an HTML response to the client.
		JsonResult: Represents a JSON result, which serializes data into JSON format and sends it to the client.
		RedirectResult: This represents a redirection result, which redirects the client to a different URL.
		ContentResult: Represents a content result, which sends raw content (such as text or HTML) to the client.
		FileResult: Represents a file result, which sends a file to the client for download.
		*/

        {
            objCategoryList = _UnitOfWork.Category.GetAll().ToList();
            return Page();
        }

    }
}