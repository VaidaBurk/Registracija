using Microsoft.EntityFrameworkCore;
using Registracija.Data;
using Registracija.Dtos;
using Registracija.Models;
using System.Collections.Generic;
using System.Linq;

namespace Registracija.Services
{
    public class RegistrationService
    {
        private readonly DataContext _context;

        public RegistrationService(DataContext context)
        {
            _context = context;
        }
        public int? SaveChanges(int regId, List<RegistrationDto> registrationDtos)
        {
            var registrationsInDb = _context.Registrations.Select(r => r.RegId).ToList();

            if (registrationsInDb.Contains(regId) == false)
            {
                foreach (var question in registrationDtos)
                {
                    var mappedRegistration = new Registration()
                    {
                        RegId = regId,
                        QuestionId = question.QuestionId,
                        AnswerId = question.AnswerId
                    };
                    _context.Registrations.Add(mappedRegistration);
                }
            }
            else
            {
                foreach (var question in registrationDtos)
                {
                    var mappedRegistration = new Registration()
                    {
                        RegId = regId,
                        QuestionId = question.QuestionId,
                        AnswerId = question.AnswerId
                    };
                    _context.Registrations.Update(mappedRegistration);
                }
            }
            _context.SaveChanges();
            return (regId);
        }

        public List<RegistrationDto> GetFilledFormData(int? regId)
        {
            var registration = _context.Registrations.Where(r => r.RegId == regId).ToList();
            var questions = _context.Questions.Include(q => q.Answers).ToList();
            var registrationDtos = new List<RegistrationDto>();
            foreach (var question in registration)
            {
                var registrationDto = new RegistrationDto()
                {
                    QuestionId = question.QuestionId,
                    QuestionValue = questions.Where(q => q.Id == question.QuestionId).Select(q => q.Value).FirstOrDefault().ToString(),
                    AnswerId = question.AnswerId,
                    Answers = _context.Answers.Where(a => a.Question.Id == question.QuestionId).ToList()
                };
                registrationDtos.Add(registrationDto);
            }
            return registrationDtos;
        }

        public List<RegistrationDto> GetNewForm(int? regId)
        {
            var registrationsInDb = _context.Registrations.Select(r => r.RegId).ToList();
            var questions = _context.Questions.Include(q => q.Answers).ToList();
            var registrationDtos = new List<RegistrationDto>();
            foreach (var question in questions)
            {
                var registrationDto = new RegistrationDto()
                {
                    QuestionId = question.Id,
                    QuestionValue = question.Value,
                    Answers = question.Answers
                };
                registrationDtos.Add(registrationDto);
            }
            return registrationDtos;
        }
    }
}
