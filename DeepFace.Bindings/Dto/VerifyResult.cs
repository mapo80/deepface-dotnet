using System;
using System.Collections.Generic;
using System.Text;

namespace DeepFace.Bindings.Dto
{
    public class VerifyResult
    {
        public bool Verified { get; set; }
		public double Distance { get; set; }
		public double MaxThresholdToVerify { get; set; }
		public string Model { get; set; }
		public string SimilarityMetric	{ get; set; }
    }
}
