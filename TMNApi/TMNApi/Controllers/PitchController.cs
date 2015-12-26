using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TMNApi.Models;
using TMNPitchData.DAL;
using System.Linq.Dynamic;

namespace TMNApi.Controllers
{
    public class PitchController : ApiController
    {
        public List<PitchModel> Get([FromUri]string bid=null, string pid=null, string d=null)
        {
            var list = new List<PitchModel>();
            using (var dbContext = new PitchDataEntities())
            {
                var queryModel = Utilities.BuildWhereClause(bid, pid, d);

                var results = dbContext.Pitches
                                .Where(queryModel.WhereClause, queryModel.Values.ToArray());

                list = Utilities.MapFields(results);
            }
            return list;
        }
    }
}
