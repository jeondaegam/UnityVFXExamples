using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineRendererAtoB : MonoBehaviour
{
    private LineRenderer lineRenderer;

    private void Awake()
    {
        lineRenderer = GetComponent<LineRenderer>();

        lineRenderer.positionCount = 2;
        lineRenderer.enabled = false;
    }

    public void Play(Vector3 from, Vector3 to)
    {
        lineRenderer.enabled = true;

        lineRenderer.SetPosition(0, from);
        lineRenderer.SetPosition(1, to);
        
    }

    public void Stop()
    {
        // 선이 보이지 않도록 비활성화 
        lineRenderer.enabled = false;
    }
}
