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
    public class SpeakersController : Controller
    {
        private readonly IQueryProcessor _queryProcessor;

        public SpeakersController(IQueryProcessor queryProcessor)
        {
            _queryProcessor = queryProcessor;
        }

        [HttpGet]
        public async Task<IEnumerable<Speaker>> Get()
        {
            var query = new AllSpeakersQuery();
            var speakers = await _queryProcessor.ProcessAsync(query);
            return speakers;
        }

        [HttpGet("{id}")]
        public async Task<Speaker> Get(Guid id)
        {
            var query = new SingleSpeakerByIdQuery(id);
            var speakers = await _queryProcessor.ProcessAsync(query);
            return speakers;
        }

        [HttpPost]
        public void Post([FromBody]string value)
        {
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
