using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography.X509Certificates;
using Sample.Model;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.JsonPatch.Operations;
using ilrapifunction;
using System.Reflection.Metadata.Ecma335;

namespace Contactapifunction
{
    public class ContactFunction
    {
        private readonly SampleDBContext _context;
        public ContactFunction(SampleDBContext context)
        {
            _context = context;
        }


        [FunctionName("GetAllContacts")]
        public async Task<IActionResult> GetContact(
    [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "Contact")] HttpRequest req,
    ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");


            var Contacts = await _context.Contacts.ToListAsync();

            return new OkObjectResult(Contacts);
        }


        [FunctionName("GetContact")]
        public async Task<IActionResult> GetContactByID(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "Contact/{id}")] HttpRequest req,
            ILogger log, int id)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");

            if (id < 0)
                return new BadRequestObjectResult("no identifier passed");

            var dbContact = await _context.Contacts.FirstOrDefaultAsync(x => x.ID == id);

            if (dbContact == null || dbContact.ID != id)
            {
                return new NotFoundResult();
            }

            return new OkObjectResult(dbContact);
        }

        [FunctionName("PostContact")]
        public async Task<IActionResult> Post(
    [HttpTrigger(AuthorizationLevel.Anonymous, "post", Route = "Contact")] HttpRequest req,
    ILogger log)
        {
            log.LogInformation("C# HTTP trigger POST Contact function processed a request.");

            try
            {
                string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
                var contact = JsonConvert.DeserializeObject<Contact>(requestBody);

                if (contact == null)
                    return new BadRequestResult();


                _context.Contacts.Add(contact);
                await _context.SaveChangesAsync();

                return new OkObjectResult(contact);
            }
            catch (Exception e)
            {
                return new BadRequestObjectResult(e.Message);
            }
        }

        [FunctionName("PatchContact")]
        public async Task<IActionResult> Patch(
    [HttpTrigger(AuthorizationLevel.Anonymous, "patch", Route = "Contact/{id}")] HttpRequest req,
    ILogger log, int id)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");

            if (id < 0)
                return new BadRequestObjectResult("no identifier passed");

            var dbContact = await _context.Contacts.FirstOrDefaultAsync(x => x.ID == id);

            if (dbContact == null || dbContact.ID != id)
            {
                return new NotFoundResult();
            }

            try
            {

                string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
                JsonPatchDocument<Contact> patchDoc = JsonConvert.DeserializeObject<JsonPatchDocument<Contact>>(requestBody);

                patchDoc.ApplyTo(dbContact);

                _context.Entry(dbContact).State = EntityState.Modified;
                var RowsAffected = await _context.SaveChangesAsync();

                if (RowsAffected > 0)
                    return new OkObjectResult(dbContact);
            }
            catch (Exception e)
            {
                return new BadRequestObjectResult(e.Message);
            }

            return new BadRequestResult();
        }


        [FunctionName("PutContact")]
        public async Task<IActionResult> Put(
[HttpTrigger(AuthorizationLevel.Anonymous, "put", Route = "Contact/{id}")] HttpRequest req,
ILogger log, int id)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");

            if (id < 0)
                return new BadRequestObjectResult("no identifier passed");

            var dbContact = await _context.Contacts.FirstOrDefaultAsync(x => x.ID == id);

            if (dbContact == null || dbContact.ID != id)
            {
                return new NotFoundResult();
            }

            try
            {
                string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
                var Contact = JsonConvert.DeserializeObject<Contact>(requestBody);

                if (Contact == null)
                    return new BadRequestResult();

                Contact.ID = id;

                _context.Entry(dbContact).State = EntityState.Detached;
                _context.Entry(Contact).State = EntityState.Modified;

                var RowsAffected = await _context.SaveChangesAsync();

                if (RowsAffected > 0)
                    return new OkObjectResult(dbContact);
            }
            catch (Exception e)
            {
                if (e.InnerException != null)
                    return new BadRequestObjectResult(e.InnerException + e.Message);
                else
                    return new BadRequestObjectResult(e.Message);
            }

            return new BadRequestResult();
        }

        [FunctionName("DeleteContact")]
        public async Task<IActionResult> Delete(
    [HttpTrigger(AuthorizationLevel.Anonymous, "delete", Route = "Contact/{id}")] HttpRequest req,
    ILogger log, int id)
        {
            try
            {
                if (id <= 0)
                {
                    return new BadRequestObjectResult("no id passed");
                }

                var contact = await _context.Contacts.FirstOrDefaultAsync(x => x.ID == id);

                if (contact == null || contact.ID != id)
                {
                    return new BadRequestObjectResult("no record found");
                }

                _context.Contacts.Remove(contact);
                await _context.SaveChangesAsync();

                return new OkObjectResult(true);
            }
            catch (Exception e)
            {
                return new BadRequestObjectResult(e.Message);
            }
        }
    }
}
