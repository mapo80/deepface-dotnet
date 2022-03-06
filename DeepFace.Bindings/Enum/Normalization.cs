using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace DeepFace.Bindings.Enum
{
    public enum Normalization
    {
        [Description("Base")]
        Base,
        [Description("Raw")]
        Raw,
        [Description("Facenet")]
        Facenet,
        [Description("VGGFace")]
        VGGFace,
        [Description("VGGFace2")]
        VGGFace2,
        [Description("ArcFace")]
        ArcFace
    }
}
