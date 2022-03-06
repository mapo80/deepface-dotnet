using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace DeepFace.Bindings.Enum
{
    public enum BackendDetector
    {
        [Description("retinaface")]
        RetinaFace,
        [Description("mtcnn")]
        MtCnn,
        [Description("opencv")]
        OpenCv,
        [Description("ssd")]
        Ssd,
        [Description("dlib")]
        Dlib
    }
}
