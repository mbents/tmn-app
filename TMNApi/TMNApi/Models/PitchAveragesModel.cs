namespace TMNApi.Models
{
    public class PitchAveragesModel
    {
        public int PlayerId { get; set; }
        public string PitchType { get; set; }
        public string BatterHand { get; set; }
        public decimal? AvgReleaseVelocity { get; set; }
        public int? ReleaseVelocitySampleSize { get; set; }
        public decimal? AvgSpinRate { get; set; }
        public int? SpinRateSampleSize { get; set; }
        public decimal? SwStrRate { get; set; }
        public int? SwStrRateSampleSize { get; set; }
    }
}