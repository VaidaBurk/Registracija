using Microsoft.AspNetCore.Mvc;
using Registracija.Data;
using Registracija.Dtos;
using Registracija.Services;
using System.Collections.Generic;
using System.Linq;

namespace Registracija.Controllers
{
    public class RegistrationController : Controller
    {
        private readonly DataContext _context;
        private readonly RegistrationService _registrationService;

        public RegistrationController(DataContext context, RegistrationService registrationService)
        {
            _context = context;
            _registrationService = registrationService;
        }

        public IActionResult Index([FromQuery] int? regId)
        {
            var registrationsInDb = _context.Registrations.Select(r => r.RegId).ToList();
            if (registrationsInDb.Contains(regId) == false)
            {
                var registrationDtos = _registrationService.GetNewForm(regId);
                return View(registrationDtos);
            }
            else
            {
                var registrationDtos = _registrationService.GetFilledFormData(regId);
                return View(registrationDtos);
            }
        }

        public IActionResult SaveChanges([FromQuery] int regId, List<RegistrationDto> registrationDtos)
        {
            _registrationService.SaveChanges(regId, registrationDtos);
            return RedirectToAction("Index", new { regId });
        }

    }
}
