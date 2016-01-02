using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TMNApi.Models;

namespace TMNApi
{
    public class Utilities
    {
        public static QueryModel BuildWhereClause(string batterId, string batterField, string pitcherId, string pitcherField, string gameDate, string gameDateField)
        {
            var queryModel = new QueryModel { Values = new List<object>() };

            int paramCounter = 0;
            var whereClause = new System.Text.StringBuilder();

            if (!string.IsNullOrEmpty(batterId))
            {
                whereClause.Append(string.Format("{0} = @{1}", batterField, paramCounter++));
                queryModel.Values.Add(Convert.ToInt32(batterId));
            }

            if (!string.IsNullOrEmpty(pitcherId))
            {
                if (paramCounter > 0)
                    whereClause.Append(string.Format(" AND {0} = @{1}", pitcherField, paramCounter++));
                else
                    whereClause.Append(string.Format("{0} = @{1}", pitcherField, paramCounter++));

                queryModel.Values.Add(Convert.ToInt32(pitcherId));
            }

            if (!string.IsNullOrEmpty(gameDate))
            {
                var startDate = Convert.ToDateTime(gameDate);
                var endDate = Convert.ToDateTime(gameDate).AddDays(1);
                if (paramCounter > 0)
                    whereClause.Append(string.Format(" AND ({0} >= @{1} AND {0} < @{2})", gameDateField, paramCounter++, paramCounter++));
                else
                    whereClause.Append(string.Format("({0} >= @{1} AND {0} < @{2})", gameDateField, paramCounter++, paramCounter++));

                queryModel.Values.Add(startDate);
                queryModel.Values.Add(endDate);
            }

            queryModel.WhereClause = whereClause.ToString();
            return queryModel;
        }
    }
}