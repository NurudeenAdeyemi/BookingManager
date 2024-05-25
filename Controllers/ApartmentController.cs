using BookingManager.Enums;
using BookingManager.Models;
using BookingManager.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BookingManager.Controllers
{
    public class ApartmentController : Controller
    {
        IWebHostEnvironment _webHostEnvironment;
        readonly IApartmentService _apartmentService;
        public ApartmentController(IWebHostEnvironment webHostEnvironment, IApartmentService apartmentService)
        {
            _webHostEnvironment = webHostEnvironment;
            _apartmentService = apartmentService;
        }

        public IActionResult Index()
        {
            var apartments = _apartmentService.GetApartments();
            return View(apartments);
        }

        public IActionResult Details(int id)
        {
            var apartment = _apartmentService.GetApartment(id);
            return View(apartment);
        }

        public IActionResult AddApartment()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddApartment(ApartmentRequestModel model)
        {
            if (ModelState.IsValid)
            {
                // Handle file uploads
                string primaryImageUrl = await SaveFileAsync(model.PrimaryImageUrl);
                var imageUrls = new List<string>();

                if (model.Images != null)
                {
                    foreach (var image in model.Images)
                    {
                        string imageUrl = await SaveFileAsync(image);
                        imageUrls.Add(imageUrl);
                    }
                }

                // Map ApartmentRequestModel to ApartmentDTO
                var apartmentDto = new ApartmentDTO
                {
                    CompanyName = model.CompanyName,
                    Name = model.Name,
                    Description = model.Description,
                    Guests = model.Guests,
                    BedRooms = model.BedRooms,
                    NumberOfRooms = model.NumberOfRooms,
                    Price = model.Price,
                    City = model.City,
                    State = model.State,
                    Country = model.Country,
                    PrimaryImageUrl = primaryImageUrl,
                    Images = imageUrls,
                    Facilities = model.Facilities
                };

                _apartmentService.AddApartment(apartmentDto);

                return RedirectToAction("Index");
            }

            return View(model);
        }

        private async Task<string> SaveFileAsync(IFormFile file)
        {
            if (file == null || file.Length == 0)
                return string.Empty;

            var uploadDir = "uploads";
            var filePath = Path.Combine(_webHostEnvironment.WebRootPath, uploadDir);

            if (!Directory.Exists(filePath))
            {
                Directory.CreateDirectory(filePath);
            }

            var uniqueFileName = Guid.NewGuid().ToString() + "_" + file.FileName;
            var fullPath = Path.Combine(filePath, uniqueFileName);

            using (var fileStream = new FileStream(fullPath, FileMode.Create))
            {
                await file.CopyToAsync(fileStream);
            }

            return $"/{uploadDir}/{uniqueFileName}";
        }

    }
}
