using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TMNApi.Models
{
    public class PitchModel
    {
        public int PitchID { get; set; }
        public int? seasonYear { get; set; }
        public string gameString { get; set; }
        public DateTime? gameDate { get; set; }
        public string gameType { get; set; }
        public string visitor { get; set; }
        public string home { get; set; }
        public int? visitingTeamFinalRuns { get; set; }
        public int? homeTeamFinalRuns { get; set; }
        public int? inning { get; set; }
        public string side { get; set; }
        public int? batterId { get; set; }
        public string batter { get; set; }
        public string batterHand { get; set; }
        public int? pitcherId { get; set; }
        public string pitcher { get; set; }
        public string pitcherHand { get; set; }
        public int? catcherId { get; set; }
        public string catcher { get; set; }
        public int? timesFaced { get; set; }
        public string batterPosition { get; set; }
        public int? balls { get; set; }
        public int? strikes { get; set; }
        public int? outs { get; set; }
        public string manOnFirst { get; set; }
        public string manOnSecond { get; set; }
        public string manOnThird { get; set; }
        public string endManOnFirst { get; set; }
        public string endManOnSecond { get; set; }
        public string endManOnThird { get; set; }
        public int? visitingTeamCurrentRuns { get; set; }
        public int? homeTeamCurrentRuns { get; set; }
        public string pitchResult { get; set; }
        public string pitchType { get; set; }
        public decimal? releaseVelocity { get; set; }
        public decimal? spinRate { get; set; }
        public decimal? spinDir { get; set; }
        public decimal? px { get; set; }
        public decimal? pz { get; set; }
        public decimal? szt { get; set; }
        public decimal? szb { get; set; }
        public decimal? x0 { get; set; }
        public decimal? y0 { get; set; }
        public decimal? z0 { get; set; }
        public decimal? vx0 { get; set; }
        public decimal? vy0 { get; set; }
        public decimal? vz0 { get; set; }
        public decimal? ax { get; set; }
        public decimal? ay { get; set; }
        public decimal? az { get; set; }
        public string paResult { get; set; }
        public int? runsHome { get; set; }
        public string battedBallType { get; set; }
        public decimal? battedBallAngle { get; set; }
        public decimal? battedBallDistance { get; set; }
        public string atbatDesc { get; set; }
    }
}