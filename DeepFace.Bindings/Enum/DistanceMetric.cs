using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace DeepFace.Bindings.Enum
{
    public enum DistanceMetric
    {
        [Description("cosine")]
        Cosine,
        [Description("euclidean")]
        Euclidean,
        [Description("euclidean_l2")]
        EuclideanL2
    }
}
