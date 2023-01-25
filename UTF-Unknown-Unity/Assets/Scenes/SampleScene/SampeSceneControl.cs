using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using UnityEngine;
using UtfUnknown;

public class SampeSceneControl : MonoBehaviour
{
    public string pathToDemoFiles = "Assets/Scenes/SampleScene/DemoFiles";

    private void Start()
    {
        var demoFiles = Directory.GetFiles(pathToDemoFiles)
            .Where(file => file.EndsWith(".txt"))
            .ToList();
        foreach (var demoFile in demoFiles)
        {
            DetectEncoding(demoFile);
        }
    }

    private void DetectEncoding(string demoFile)
    {
        var detectionResult = CharsetDetector.DetectFromFile(demoFile);
        var encoding = detectionResult.Detected.Encoding;
        var encodingName = detectionResult.Detected.EncodingName;
        var confidence = detectionResult.Detected.Confidence;
        Debug.Log($"Detected encoding '{encodingName}' (C# '{encoding}') with confidence {confidence} for file {demoFile}");
    }
}