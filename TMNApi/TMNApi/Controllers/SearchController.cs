using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using TMNApi.Models;
using TMNPitchData.DAL;
using System.Linq.Dynamic;

namespace TMNApi.Controllers
{
    public class SearchController : ApiController
    {
        // GET api/search/5
        [HttpGet]
        public List<PlayerModel> Get(string id)
        {
            var list = new List<PlayerModel>();
            using (var dbContext = new PitchDataEntities())
            {
                var results = dbContext.Players
                                .Where(x => x.Name.Contains(id))
                                .Select(x => new PlayerModel { Bats = x.Bats, Name = x.Name, PlayerID = x.PlayerId.Value, Throws = x.Throws })
                                .OrderBy(x => x.Name)
                                .ToList();
                list = results;
            }
            return list;
        }

        // POST api/search
        [HttpPost]
        public List<PlayerModel> Post([FromBody]string value)
        {
            var list = new List<PlayerModel>();
            using (var dbContext = new PitchDataEntities())
            {
                var results = dbContext.Players
                                .Where(x => x.Name.Contains(value))
                                .Select(x => new PlayerModel { Bats = x.Bats, Name = x.Name, PlayerID = x.PlayerId.Value, Throws = x.Throws }).ToList();
                list = results;
            }
            return list;
        }
    }
}
