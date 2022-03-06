using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace DeepFace.Bindings.Enum
{
    public enum Model
    {
        [Description("VGG-Face")]
        VggFace,
        [Description("Facenet")]
        Facenet,
        [Description("Facenet512")]
        Facenet512,
        [Description("OpenFace")]
        OpenFace,
        [Description("DeepFace")]
        DeepFace,
        [Description("DeepID")]
        DeepId,
        [Description("Dlib")]
        Dlib,
        [Description("ArcFace")]
        ArcFace,
        [Description("Ensemble")]
        Ensemble
    }
}
