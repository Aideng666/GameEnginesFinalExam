using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.InteropServices;

public class DuckRandomSize : MonoBehaviour
{

    [DllImport("GameEnginesFinalExamDuckSizeDll.dll")]
    private static extern float RandomScaleValue(float minValue, float maxValue);

    [SerializeField] float minRandomFactor = 0.5f;
    [SerializeField] float maxRandomFactor = 2f;

    void Start()
    {
        transform.localScale = transform.localScale * RandomScaleValue(minRandomFactor, maxRandomFactor);
    }
}
