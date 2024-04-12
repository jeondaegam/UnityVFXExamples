using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawGraph : MonoBehaviour
{
    public GameObject Circle;
    private RectTransform graphContainer;

    private void Awake()
    {
        graphContainer = transform.Find("GraphContainer").GetComponent<RectTransform>();
    }



    private void ShowGraph(int[] values)
    {
        float graphHeight = graphContainer.sizeDelta.y;
        float yMaximum = 100f; // y의 최대값 
        float xSize = 50f; // x축 간격 

        for (int i = 0; i < values.Length; i++)
        {
            float xPosition = xSize + i * xSize;
            float yPosition = (values[i] / yMaximum) * graphHeight;
            Vector3 newPosition = new Vector3(xPosition, yPosition);
            Instantiate(Circle, newPosition, Quaternion.identity, graphContainer);

        }
    }

    private void Start()
    {
        int[] values = new int[] { 10, 20, 30, 40, 50, 30, 20, 10, 70 };
        ShowGraph(values);
    }
}
