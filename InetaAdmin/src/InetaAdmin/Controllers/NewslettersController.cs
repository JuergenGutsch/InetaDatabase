using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Gos.Tools.Cqs.Query;
using InetaAdmin.Database.Entities;
using InetaAdmin.Infrastructure.Read.Queries;
using Microsoft.AspNet.Mvc;

namespace InetaAdmin.Controllers
{
    [Route("api/[controller]")]
    public class NewslettersController : Controller
    {
        private readonly IQueryProcessor _queryProcessor;

        public NewslettersController(IQueryProcessor queryProcessor)
        {
            _queryProcessor = queryProcessor;
        }

        [HttpGet]
        public async Task<IEnumerable<Newsletter>> Get()
        {
            var query = new AllNewslettersQuery();
            var speakers = await _queryProcessor.ProcessAsync(query);
            return speakers;
        }

        [HttpGet("{id}")]
        public async Task<Newsletter> Get(Guid id)
        {
            var query = new SingleNewsletterByIdQuery(id);
            var speakers = await _queryProcessor.ProcessAsync(query);
            return speakers;
        }

        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
