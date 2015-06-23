﻿namespace Colab.API.Controllers
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.Http;

    using Colab.Data;

    ////[Authorize]
    public class ValuesController : BaseApiController
    {
        public ValuesController(IColabData data)
            : base(data)
        {
        }

        // GET api/values
        public IEnumerable<string> Get()
        {
            var count = this.Data.Messages.All().Count();

            return new string[] { "value1", "value2", count.ToString() };
        }

        // GET api/values/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}