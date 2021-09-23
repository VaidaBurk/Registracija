using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Registracija.Data;
using Registracija.Dtos;
using Registracija.Models;
using System.Collections.Generic;
using System.Linq;

namespace Registracija.Controllers
{
    public class RegistrationController : Controller
    {
        private readonly DataContext _context;

        public RegistrationController(DataContext context)
        {
            _context = context;
        }

        public IActionResult Index([FromQuery] int? regId)
        {
            var registrationsInDb = _context.Registrations.Select(r => r.RegId).ToList();
            var questions = _context.Questions.Include(q => q.Answers).ToList();
            var registrationDtos = new List<RegistrationDto>();

            if (registrationsInDb.Contains(regId) == false)
            {
                foreach (var question in questions)
                {

                    var registrationDto = new RegistrationDto()
                    {
                        RegId = regId,
                        QuestionId = question.Id,
                        QuestionValue = question.Value,
                        Answers = question.Answers
                    };
                    registrationDtos.Add(registrationDto);
                }
            }
            else
            {
                var registration = _context.Registrations.Where(r => r.RegId == regId).ToList();
                foreach (var question in registration)
                {
                    var registrationDto = new RegistrationDto()
                    {
                        RegId = regId,
                        QuestionId = question.QuestionId,
                        QuestionValue = questions.Where(q => q.Id == question.QuestionId).Select(q => q.Value).FirstOrDefault().ToString(),
                        AnswerId = question.AnswerId,
                        Answers = _context.Answers.Where(a => a.Question.Id == question.QuestionId).ToList()
                    };
                    registrationDtos.Add(registrationDto);
                }
            }
            return View(registrationDtos);
        }


        public IActionResult SaveChanges(List<RegistrationDto> registrationDtos)
        {
            foreach (var question in registrationDtos)
            {
                var mappedRegistration = new Registration()
                {
                    RegId = question.RegId,
                    QuestionId = question.QuestionId,
                    AnswerId = question.AnswerId
                };
                _context.Registrations.Add(mappedRegistration);
            }

            _context.SaveChanges();
            return RedirectToAction("Index", new { regId = registrationDtos.First().RegId });
        }

    }
}
