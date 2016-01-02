using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using TMNApi.Models;
using TMNPitchData.DAL;
using System.Linq.Dynamic;

namespace TMNApi.Controllers
{
    public class PitchAverageController : ApiController
    {
        [HttpGet]
        public List<PitchAveragesModel> Get(string id)
        {
            var list = new List<PitchAveragesModel>();
            using (var dbContext = new PitchDataEntities())
            {
                var queryModel = Utilities.BuildWhereClause(null, null, id, "PlayerId", null, null);
                list = dbContext.PitchAverages
                        .Where(queryModel.WhereClause, queryModel.Values.ToArray())
                        .Select(x => new PitchAveragesModel
                        {
                            AvgReleaseVelocity = x.AvgReleaseVelocity,
                            AvgSpinRate = x.AvgSpinRate,
                            BatterHand = x.BatterHand,
                            PitchType = x.PitchType,
                            PlayerId = x.PlayerId,
                            ReleaseVelocitySampleSize = x.ReleaseVelocitySampleSize,
                            SpinRateSampleSize = x.SpinRateSampleSize,
                            SwStrRate = x.SwStrRate,
                            SwStrRateSampleSize = x.SwStrRateSampleSize
                        })
                        .OrderBy(x => x.PitchType)
                        .ToList();
            }
            return list;
        }
    }
}
