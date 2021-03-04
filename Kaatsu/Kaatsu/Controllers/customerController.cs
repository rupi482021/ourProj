using Kaatsu.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.IO;
using System.Web;
using System.Web.Hosting;

namespace Kaatsu.Controllers
{
    public class customerController : ApiController
    {


        public customer GET(string email, string password)
        {
            try
            {
                customer cus = new customer(email, password);
                return cus.Check();

            }
            catch (Exception ex)
            {
                throw (ex);
            }

        }

        public customer Post([FromBody] customer customer)
        {

            customer insertCust = new customer(customer);
            return insertCust.Insert();

        }

        public void Put([FromBody] customer upCustomer)
        {
            customer upCus = upCustomer;
            upCus.updateCustomerDet();
        }

    }
}