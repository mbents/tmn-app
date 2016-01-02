using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using TMNApi.Models;
using TMNPitchData.DAL;
using System.Linq.Dynamic;

namespace TMNApi.Controllers
{
    public class PitchController : ApiController
    {
        [HttpGet]
        public List<AtBatCountModel> Get(string id)
        {
            var list = new List<AtBatCountModel>();
            using (var dbContext = new PitchDataEntities())
            {
                var queryModel = Utilities.BuildWhereClause(null, null, id, "pitcherId", null, null);
                var pitchExpectancy = dbContext.Pitches
                                        .Where(queryModel.WhereClause, queryModel.Values.ToArray());

                list = (from r in pitchExpectancy.AsEnumerable()
                        group r by new 
                        { 
                            AB_count = r.balls.Value + "-" + r.strikes.Value, 
                            r.pitchType,
                            r.batterHand
                        } into grp
                        orderby grp.Key.AB_count
                        select new AtBatCountModel
                        {
                            pitchType = grp.Key.pitchType,
                            atBatCount = grp.Key.AB_count,
                            pitchTypeCount = grp.Count(),
                            batterHand = grp.Key.batterHand
                        }).ToList();
            }
            return list;
        }
    }
}
