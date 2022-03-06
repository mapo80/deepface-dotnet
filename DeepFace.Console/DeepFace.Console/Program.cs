using System.Diagnostics;
using System.Reflection;
using DeepFace.Bindings;
using DeepFace.Bindings.Enum;
using DeepFace.Console;
using Microsoft.Extensions.DependencyInjection;

var timer = new Stopwatch();

//Clooney
var a = $"{Convert.ToBase64String(Utility.ReadEmbeddedResource(Assembly.GetExecutingAssembly(), "a.jpg"))}";
var b = $"{Convert.ToBase64String(Utility.ReadEmbeddedResource(Assembly.GetExecutingAssembly(), "b.jpg"))}";
// Di caprio
var c = $"{Convert.ToBase64String(Utility.ReadEmbeddedResource(Assembly.GetExecutingAssembly(), "c.jpg"))}";
var d = $"{Convert.ToBase64String(Utility.ReadEmbeddedResource(Assembly.GetExecutingAssembly(), "d.jpg"))}";
var e = $"{Convert.ToBase64String(Utility.ReadEmbeddedResource(Assembly.GetExecutingAssembly(), "e.jpg"))}";
//Jolie
var f = $"{Convert.ToBase64String(Utility.ReadEmbeddedResource(Assembly.GetExecutingAssembly(), "f.jpg"))}";
var g = $"{Convert.ToBase64String(Utility.ReadEmbeddedResource(Assembly.GetExecutingAssembly(), "g.jpg"))}";

var serviceProvider = new ServiceCollection()
    .AddSingleton<IDeepFace, DeepFace.Bindings.DeepFace>()
    .BuildServiceProvider();

var deepFace = serviceProvider
    .GetService<IDeepFace>();

timer.Start();

#region Clooney comparison
var result = deepFace?.Verify(a, b, 
                              Model.VggFace, 
                              DistanceMetric.EuclideanL2, 
                              BackendDetector.MtCnn, 
                              Normalization.VGGFace,
                              true);

Utility.LogProperties("Clooney comparison", result);
Console.WriteLine("Execution time - {0}", timer.Elapsed);

#endregion

#region Young Di Caprio comparison
result = deepFace?.Verify(c, d,
                          Model.VggFace,
                          DistanceMetric.EuclideanL2,
                          BackendDetector.MtCnn,
                          Normalization.VGGFace,
                          true);

Utility.LogProperties("Young Di Caprio comparison", result);
Console.WriteLine("Execution time - {0}", timer.Elapsed);
#endregion

#region Old Di Caprio comparison
result = deepFace?.Verify(d, e,
                          Model.VggFace,
                          DistanceMetric.EuclideanL2,
                          BackendDetector.MtCnn,
                          Normalization.VGGFace,
                          true);

Utility.LogProperties("Old Di Caprio comparison", result);
Console.WriteLine("Execution time - {0}", timer.Elapsed);
#endregion

#region Jolie comparison
result = deepFace?.Verify(f, g,
                          Model.VggFace,
                          DistanceMetric.EuclideanL2,
                          BackendDetector.MtCnn,
                          Normalization.VGGFace,
                          true);

Utility.LogProperties("Jolie comparison", result);
Console.WriteLine("Execution time - {0}", timer.Elapsed);
#endregion

timer.Stop();
