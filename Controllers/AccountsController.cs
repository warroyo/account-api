using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;


namespace account_api.Controllers
{
    

    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        private IConfiguration configuration;
        public AccountsController(IConfiguration iConfig)  
        {  
        configuration = iConfig;  
        }   
        // GET api/accounts
        [HttpGet]
        public IEnumerable<Account> Get()
        {
            string order_service = configuration.GetValue<string>("endpoints:order-service");  

            using (AccountDb db = new AccountDb())
            {
                return db.Accounts.ToList();
            }
        }
  

        // GET api/accounts/5
        [HttpGet("{id}")]
        public Account Get(int id)
        {
            using (AccountDb db = new AccountDb())
            {
                return db.Accounts.First(t => t.Id == id);
            }
        }

        // POST api/accounts
        [HttpPost]
        public void Post([FromBody]JObject value)
        {
            Account posted = value.ToObject<Account>();
            using (AccountDb db = new AccountDb())
            {
                db.Accounts.Add(posted);
                db.SaveChanges();
            }
        }

        // PUT api/accounts/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]JObject value)
        {
            Account posted = value.ToObject<Account>();
            posted.Id = id; // Ensure an id is attached
            using (AccountDb db = new AccountDb())
            {
                db.Accounts.Update(posted);
                db.SaveChanges();
            }
        }
        // DELETE api/accounts/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            using (AccountDb db = new AccountDb())
            {
                if (db.Accounts.Where(t => t.Id == id).Count() > 0) // Check if element exists
                    db.Accounts.Remove(db.Accounts.First(t => t.Id == id));
                db.SaveChanges();
            }
        }
    }
}
