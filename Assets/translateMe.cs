using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class translateMe : MonoBehaviour
{
    public float Q;

    public void Slider_Change(float f)
    {
        Q = f;
    }

    void Start()
    {
        transform.localPosition = new Vector3(0, -1f, 0);
    }

    void Update()
    {
        transform.localPosition = new Vector3(0, -Q, 0);
    }
}
