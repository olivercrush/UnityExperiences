using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Graph : MonoBehaviour
{
    // Experimentation from https://catlikecoding.com/unity/tutorials/basics/building-a-graph/

    public Transform pointPrefab;

    private void Awake()
    {
        for (int i = -10; i < 10; i++)
        {
            Transform point = Instantiate(pointPrefab);
            point.localPosition = Vector3.right * i / 5f;
            point.localScale = Vector3.one / 5f;
        }
    }

}
