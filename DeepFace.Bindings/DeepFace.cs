using System;
using System.Diagnostics;
using System.Threading.Tasks;
using DeepFace.Bindings.Dto;
using DeepFace.Bindings.Enum;
using DeepFace.Bindings.Utility;
using Python.Included;
using Python.Runtime;

namespace DeepFace.Bindings
{
    public class DeepFace: IDeepFace
    {
        public DeepFace()
        {
            Init();
        }

        public VerifyResult Verify(string img1Base64, string img2Base64, 
                                   Model modelName,
                                   DistanceMetric distanceMetric,
                                   BackendDetector backendDetector,
                                   Normalization normalization,
                                   bool align)
        {

            if (!img1Base64.IsBase64() || !img2Base64.IsBase64())
            {
                throw new ArgumentException("Input not base64 encoded");
            }

            VerifyResult verifyResult;

            using (Py.GIL())
            {
                dynamic sys = Py.Import("sys");

                PythonEngine.RunSimpleString(
                    "import sys\n" +
                    "from deepface import DeepFace\n" +

                    $"sys.result = DeepFace.verify(img1_path = 'data:image/,{img1Base64}', img2_path = 'data:image/,{img2Base64}', model_name = '{modelName.GetDescription()}', distance_metric = '{distanceMetric.GetDescription()}', detector_backend = '{backendDetector.GetDescription()}', normalization = '{normalization.GetDescription()}', align = {align.ToString().ToInvarianTitleCase()})\n"
                );

                dynamic result;

                try
                {
                    result = sys.result;
                }
                catch (Exception ex)
                {
                    Trace.WriteLine(ex);
                    throw;
                }

                verifyResult = ParseResponse(result);
            }

            return verifyResult;
        }

        private void Init()
        {
            //Installer.InstallPath = Environment.CurrentDirectory;
            Installer.SetupPython().Wait();
            Installer.TryInstallPip();
            Installer.PipInstallModule("deepface");
            PythonEngine.Initialize();
        }

        private VerifyResult ParseResponse(dynamic result)
        {
            if (result == null)
            {
                throw new ApplicationException("Response null by DeepFace execution");
            }

            var response = new VerifyResult();

            try
            {
                response.Verified = result["verified"].IsTrue();
                response.Distance = (double)result["distance"];
                response.MaxThresholdToVerify = (double)result["threshold"];
                response.Model = result["model"].As<string>();
                response.SimilarityMetric = result["similarity_metric"].As<string>();

                return response;
            }
            catch (Exception ex)
            {
                Trace.WriteLine(ex);
                throw;
            }

        }

    }

    public interface IDeepFace
    {
        VerifyResult Verify(string img1Base64, string img2Base64,
                            Model modelName,
                            DistanceMetric distanceMetric,
                            BackendDetector backendDetector,
                            Normalization normalization,
                            bool align);
    }
}
