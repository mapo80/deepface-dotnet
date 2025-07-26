# .NET bindings for DeepFace

This repository exposes a minimal .NET API to the
[**DeepFace**](https://github.com/serengil/deepface) framework. The
implementation uses [**Python.Included**](https://github.com/henon/Python.Included)
and **pythonnet** in order to install Python and invoke DeepFace directly from a
.NET application.

Only the `verify` method is currently wrapped, but the structure of the project
allows other DeepFace features to be added easily.

---

## Building

The solution targets **.NET 6** and can be built with the .NET CLI:

```bash
dotnet build DeepFace.Console/DeepFace.Console.sln -c Release
```

The build generates `DeepFace.Bindings.dll` and a sample console application in
`DeepFace.Console/bin/Release/net6.0`.

## Usage

Configure dependency injection and call `Verify` with the desired options:

```csharp
var serviceProvider = new ServiceCollection()
    .AddSingleton<IDeepFace, DeepFace.Bindings.DeepFace>()
    .BuildServiceProvider();

var deepFace = serviceProvider.GetService<IDeepFace>();

var result = deepFace?.Verify(img1Base64, img2Base64,
                              Model.VggFace,
                              DistanceMetric.EuclideanL2,
                              BackendDetector.MtCnn,
                              Normalization.VGGFace,
                              true);
```

`img1Base64` and `img2Base64` must contain image data encoded as base64 strings.

## Enumerations

The API exposes several enums that mirror DeepFace options:

| Enum                | Values                                                                 |
|---------------------|------------------------------------------------------------------------|
| **Model**           | VggFace, Facenet, Facenet512, OpenFace, DeepFace, DeepId, Dlib, ArcFace |
| **DistanceMetric**  | Cosine, Euclidean, EuclideanL2                                          |
| **BackendDetector** | RetinaFace, MtCnn, OpenCv, Ssd, Dlib                                    |
| **Normalization**   | Base, Raw, Facenet, VGGFace, VGGFace2, ArcFace                          |

## Example output

Below is an example of the console output when comparing two images using the
settings shown above:

![Execution example](https://raw.githubusercontent.com/mapo80/deepface-dotnet/main/DeepFace-Execution.png)

