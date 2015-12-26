using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TMNApi.Models;

namespace TMNApi
{
    public class Utilities
    {
        public static QueryModel BuildWhereClause(string batterId, string pitcherId, string gameDate)
        {
            var queryModel = new QueryModel { Values = new List<object>() };

            int paramCounter = 0;
            var whereClause = new System.Text.StringBuilder();

            if (!string.IsNullOrEmpty(batterId))
            {
                whereClause.Append(string.Format("batterId = @{0}", paramCounter++));
                queryModel.Values.Add(Convert.ToInt32(batterId));
            }

            if (!string.IsNullOrEmpty(pitcherId))
            {
                if (paramCounter > 0)
                    whereClause.Append(string.Format(" AND pitcherId = @{0}", paramCounter++));
                else
                    whereClause.Append(string.Format("pitcherId = @{0}", paramCounter++));

                queryModel.Values.Add(Convert.ToInt32(pitcherId));
            }

            if (!string.IsNullOrEmpty(gameDate))
            {
                var startDate = Convert.ToDateTime(gameDate);
                var endDate = Convert.ToDateTime(gameDate).AddDays(1);
                if (paramCounter > 0)
                    whereClause.Append(string.Format(" AND (gameDate >= @{0} AND gameDate < @{1})", paramCounter++, paramCounter++));
                else
                    whereClause.Append(string.Format("(gameDate >= @{0} AND gameDate < @{1})", paramCounter++, paramCounter++));

                queryModel.Values.Add(startDate);
                queryModel.Values.Add(endDate);
            }

            queryModel.WhereClause = whereClause.ToString();
            return queryModel;
        }

        public static List<PitchModel> MapFields(IQueryable<TMNPitchData.DAL.Pitch> results)
        {
            var list = results
                        .AsEnumerable()
                        .Select(x => new PitchModel
                                {
                                    atbatDesc = x.atbatDesc,
                                    ax = string.IsNullOrEmpty(x.ax) ? (decimal?)null : Convert.ToDecimal(x.ax),
                                    ay = string.IsNullOrEmpty(x.ay) ? (decimal?)null : Convert.ToDecimal(x.ay),
                                    az = string.IsNullOrEmpty(x.az) ? (decimal?)null : Convert.ToDecimal(x.az),
                                    balls = x.balls,
                                    battedBallAngle = string.IsNullOrEmpty(x.battedBallAngle) ? (decimal?)null : Convert.ToDecimal(x.battedBallAngle),
                                    battedBallDistance = string.IsNullOrEmpty(x.battedBallDistance) ? (decimal?)null : Convert.ToDecimal(x.battedBallDistance),
                                    battedBallType = x.battedBallType,
                                    batter = x.batter,
                                    batterHand = x.batterHand,
                                    batterId = x.batterId,
                                    batterPosition = x.batterPosition,
                                    catcher = x.catcher,
                                    catcherId = x.catcherId,
                                    endManOnFirst = x.endManOnFirst,
                                    endManOnSecond = x.endManOnSecond,
                                    endManOnThird = x.endManOnThird,
                                    gameDate = x.gameDate,
                                    gameString = x.gameString,
                                    gameType = x.gameType,
                                    home = x.home,
                                    homeTeamCurrentRuns = x.homeTeamCurrentRuns,
                                    homeTeamFinalRuns = x.homeTeamFinalRuns,
                                    inning = x.inning,
                                    manOnFirst = x.manOnFirst,
                                    manOnSecond = x.manOnSecond,
                                    manOnThird = x.manOnThird,
                                    outs = x.outs,
                                    paResult = x.paResult,
                                    pitcher = x.pitcher,
                                    pitcherHand = x.pitcherHand,
                                    pitcherId = x.pitcherId,
                                    PitchID = x.PitchID,
                                    pitchResult = x.pitchResult,
                                    pitchType = x.pitchType,
                                    px = string.IsNullOrEmpty(x.px) ? (decimal?)null : Convert.ToDecimal(x.px),
                                    pz = string.IsNullOrEmpty(x.pz) ? (decimal?)null : Convert.ToDecimal(x.pz),
                                    releaseVelocity = string.IsNullOrEmpty(x.releaseVelocity) ? (decimal?)null : Convert.ToDecimal(x.releaseVelocity),
                                    runsHome = string.IsNullOrEmpty(x.runsHome) ? (int?)null : Convert.ToInt32(x.runsHome),
                                    seasonYear = x.seasonYear,
                                    side = x.side,
                                    spinDir = string.IsNullOrEmpty(x.spinDir) ? (decimal?)null : Convert.ToDecimal(x.spinDir),
                                    spinRate = string.IsNullOrEmpty(x.spinRate) ? (decimal?)null : Convert.ToDecimal(x.spinRate),
                                    strikes = x.strikes,
                                    szb = string.IsNullOrEmpty(x.szb) ? (decimal?)null : Convert.ToDecimal(x.szb),
                                    szt = string.IsNullOrEmpty(x.szt) ? (decimal?)null : Convert.ToDecimal(x.szt),
                                    timesFaced = x.timesFaced,
                                    visitingTeamCurrentRuns = x.visitingTeamCurrentRuns,
                                    visitingTeamFinalRuns = x.visitingTeamFinalRuns,
                                    visitor = x.visitor,
                                    vx0 = string.IsNullOrEmpty(x.vx0) ? (decimal?)null : Convert.ToDecimal(x.vx0),
                                    vy0 = string.IsNullOrEmpty(x.vy0) ? (decimal?)null : Convert.ToDecimal(x.vy0),
                                    vz0 = string.IsNullOrEmpty(x.vz0) ? (decimal?)null : Convert.ToDecimal(x.vz0),
                                    x0 = string.IsNullOrEmpty(x.x0) ? (decimal?)null : Convert.ToDecimal(x.x0),
                                    y0 = string.IsNullOrEmpty(x.y0) ? (decimal?)null : Convert.ToDecimal(x.y0),
                                    z0 = string.IsNullOrEmpty(x.z0) ? (decimal?)null : Convert.ToDecimal(x.z0)
                                }).ToList();

            return list;
        }
    }
}