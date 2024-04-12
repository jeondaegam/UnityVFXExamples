using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LineAnimator : MonoBehaviour
{
    // Referencing
    public GameObject TempPoint;
    public TextMeshProUGUI TempPointText;
    public TextMeshProUGUI TimeText;
    public Transform CanvasTransform;
    public WeatherManager WeatherManager;

    [SerializeField] private float animationDuration = 3f;
    private LineRenderer lineRenderer;

    // point 개수
    private int pointsCount = 10;
    // 각 point들을 담을 배열 
    private Vector3[] linePoints;

    private float XPosRange; // -45 ~ +40
    private float XPosition = -68f; // -45f부터 시작, 근데 좌표에 8씩 더하는 로직때문에 -57부터 시작 

    private int YpositionMin = 18;
    private int YPosisionMax = 28;


    // Start is called before the first frame update
    void Start()
    {
        int pointsCount;
        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.enabled = true;

        pointsCount = lineRenderer.positionCount;
        linePoints = new Vector3[pointsCount];

        // linePoints 배열 초기화 : renderer의 Poisiton값을 가져온다 
        for (int i = 0; i < pointsCount; i++)
        {
            linePoints[i] = lineRenderer.GetPosition(i);
        }

        StartCoroutine(AnimateRandomLine());
    }

    private IEnumerator AnimateLine()
    {
        //lineRenderer.gameObject.SetActive(true);
        float segmentDuration = animationDuration / pointsCount;
        lineRenderer.enabled = true;

        for (int i = 0; i < pointsCount - 1; i++)
        {
            float startTime = Time.time;
            Vector3 startPosition = linePoints[i];
            Vector3 endPosition = linePoints[i + 1];
            Vector3 pos = startPosition;

            while (pos != endPosition)
            {
                float t = (Time.time - startTime) / segmentDuration;
                pos = Vector3.Lerp(startPosition, endPosition, t);

                for (int j = i + 1; j < pointsCount; j++)
                {
                    lineRenderer.SetPosition(j, pos);
                    yield return null;

                }

            }

        }
    }

    // X축 간격은 고정해주고 Y축은 랜덤 좌표 설정 
    private IEnumerator AnimateRandomLine()
    {
        lineRenderer.positionCount = pointsCount;
        Vector3[] positions = new Vector3[pointsCount];

        // random position 10개 만든다음
        for (int i = 0; i < pointsCount; i++)
        {
            // 좌표 10개 만들기
            XPosition += 12f;
            positions[i] = new Vector3(XPosition, Random.Range(YpositionMin, YPosisionMax));

            Debug.Log($"{positions[i].x}, {positions[i].y}");
        }

        // renderer position에 넣어준다
        lineRenderer.SetPositions(positions);
        Debug.Log(positions.ToString());

        // 그리고 그려주면 ok 
        float segmentDuration = animationDuration / pointsCount;
        for (int i = 0; i < pointsCount - 1; i++)
        {
            float startTime = Time.time;
            Vector3 startPosition = positions[i];
            Vector3 endPosition = positions[i + 1];
            Vector3 nowPos = startPosition;

            while (nowPos != endPosition)
            {
                float t = (Time.time - startTime) / segmentDuration;
                nowPos = Vector3.Lerp(startPosition, endPosition, t);
                //nowPos = Vector3.Slerp(startPosition, endPosition, t);

                for (int j = i + 1; j < pointsCount; j++)
                {
                    lineRenderer.SetPosition(j, nowPos);
                    yield return null;
                }
            }
            // point 인스턴스 생성 
            Instantiate(TempPoint, endPosition, Quaternion.identity);
            // 온도 텍스트 그리기 - y축+7 떨어진 곳에 생성  
            //TempPointText.text = endPosition.y.ToString();
            TempPointText.text = WeatherManager.weatherData.list[i].main.temp.ToString() + "°C";
            Vector3 textPosition = startPosition + new Vector3(0, 7f);
            Instantiate(TempPointText, textPosition, Quaternion.identity, CanvasTransform);

            // 시간 텍스트 화면에 그리기 
            string dateTimeString = WeatherManager.weatherData.list[i].dt_txt;
            string timePart= dateTimeString.Substring(11, 5);
            TimeText.text = timePart;
            Vector3 timePosition = startPosition + new Vector3(0, -5f);
            Instantiate(TimeText, timePosition, Quaternion.identity, CanvasTransform);

            // log
            Debug.Log(gameObject.transform);
        }


    }
}
