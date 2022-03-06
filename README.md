# .Net Bindings for DeepFace

In this period I am becoming interested in facerecognition.
I found this interesting framework on Github and I wanted to make the binding for .Net:

 - https://github.com/serengil/deepface

I've used **Python.Included** and **Pythonet**, here you can find all the information:

 - https://github.com/henon/Python.Included

I only implemented DeepFace's **verify** method, it would be interesting to bind the other methods as well.

To use it just do:

    var serviceProvider = new ServiceCollection()
        .AddSingleton<IDeepFace, DeepFace.Bindings.DeepFace>()
        .BuildServiceProvider();
    
    var deepFace = serviceProvider
        .GetService<IDeepFace>();

Then call verify method:

    var result = deepFace?.Verify(a, b, 
                                  Model.VggFace, 
                                  DistanceMetric.EuclideanL2, 
                                  BackendDetector.MtCnn, 
                                  Normalization.VGGFace,
                                  true);

You can pass base64 image to verify method.

You have enum for:
- Model name: VGG-Face, Facenet, Facenet512, OpenFace, DeepFace, DeepID, ArcFace, Dlib
- Distance metric: Cosine, Euclidean, Euclidean L2
- Backend detector: Retina Face, Mt Cnn, Opencv, Ssd, Dlib
- Normalization: Base, Raw, Facenet, VGGFace, VGGFace2, ArcFace

Below execution for:
- Model name: Vgg face
- Distance metric: Euclidean L2
- Backend detector: Mt Cnn
- Normalization: Vgg face


![enter image description here](https://raw.githubusercontent.com/mapo80/deepface-dotnet/main/DeepFace-Execution.png)
