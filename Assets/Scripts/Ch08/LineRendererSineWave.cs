using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineRendererSineWave : MonoBehaviour
{
    [SerializeField]
    private float start = 0; // 선의 시작점 x위치
    [SerializeField]
    private float end = 30; // 선의 끝점 x위치
    [SerializeField]
    [Range(5, 50)] // 5 ~ 50까지
    private int points = 5; // 점의 개수 (많을수록 부드러운 곡선 표현)

    [SerializeField]
    [Min(1)] // 최소값이 1 
    private float amplitude = 1; // 진폭 ( 그래프의 y축 높이)

    [SerializeField]
    [Min(1)]
    private float frequency = 1; // 진동 수 
    private LineRenderer lineRenderer;

    private float[] yPosList = { 0, 5, -5, 10, 15 };

    private void Awake()
    {
        lineRenderer = GetComponent<LineRenderer>();
    }


    // Update is called once per frame
    private void Update()
    {
        Play();
    }

    private void Play()
    {
        lineRenderer.positionCount = points;

        for (int i=0; i < points; ++i)
        {
            float t = (float)i / (points - 1);
            float x = Mathf.Lerp(start, end, t);
            float y = amplitude * Mathf.Sin(2 * Mathf.PI * t * frequency);
            //float y = yPosList[i];
            lineRenderer.SetPosition(i, new Vector3(x, y, 0));
        }

    }

}
