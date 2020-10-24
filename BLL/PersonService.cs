using System;
using System.Collections.Generic;
using DAL;
using Entity;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace BLL
{
    public class PersonService
    {
        private readonly FirstParcialContext context;

        public PersonService(FirstParcialContext parcialContext)
        {
            context = parcialContext;
        }

        public ServiceResponse Save(Person person)
        {
            try
            {
                context.Persons.Add(person);
                context.SaveChanges();
                return new ServiceResponse(person);

            }catch(Exception e)
            {
                return new ServiceResponse($"Error del aplicacion: {e.Message}");
            }
        }

        public ConsultResponse GetConsult()
        {
            try
            {
                IList<Person> persons = context.Persons.Include(s => s.Support).ToList();
                return new ConsultResponse(persons);
            }catch(Exception e)
            {
                return new ConsultResponse($"Error de aplicacion: {e.Message}");
            }
        }
        public ServiceResponse GetPerson(string identification)
        {
            try
            {

                Person person = context.Persons.Where(s => s.Identification == identification)
                                                .Include(s  => s.Support)
                                                .FirstOrDefault();

                return new ServiceResponse(person);
            }
            catch (Exception e)
            {
                
                return new ServiceResponse($"Error de la Aplicacion: {e.Message}");
            }
        }

        public SupportResponse GetSumaSupport()
        {
            try
            {
                decimal sumaSupport = context.Persons.
                FromSqlRaw("SELECT * FROM  Persons p JOIN Support s ON p.SupportIdSupport = s.IdSupport").
                Sum(p => p.Support.Value);

                return new SupportResponse(sumaSupport);
            }
            catch(Exception e)
            {
                return new SupportResponse($"Error de la Aplicacion: {e.Message}");
            }
        }
    }

    public class ServiceResponse
    {
        public ServiceResponse(Person person)
        {
            Error = false;
            Person = person;
        }

        public ServiceResponse(string message)
        {
            Error = true;
            Message = message;
        }

        public bool Error { get; set; }
        public string Message { get; set; }
        public Person Person { get; set; }
    }

    public class ConsultResponse
    {
        public ConsultResponse(IList<Person> persons)
        {
            Error = false;
            Persons = persons;
        }

        public ConsultResponse(string message)
        {
            Error = true;
            Message = message;
        }

        public bool Error { get; set; }
        public string Message { get; set; }
        public IList<Person> Persons { get; set; }
    }

    public class SupportResponse
    {
        public SupportResponse(decimal sumaSupport)
        {
            Error = false;
            SumaSupport = sumaSupport;
        }

        public SupportResponse(string message)
        {
            Error = true;
            Message = message;
        }

        public bool Error { get; set; }
        public string Message { get; set; }
        public decimal SumaSupport { get; set; }
    }
}
