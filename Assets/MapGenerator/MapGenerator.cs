using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGenerator : MonoBehaviour
{
    public int _width = 5;
    public int _height = 5;
    public GameObject _prefab;

    // Start is called before the first frame update
    void Start()
    {
        GenerateGraphicMap();
    }

    public void GenerateGraphicMap() {
        DeleteGraphicMap();
        for (int y = 0; y < _height; y++) {
            for (int x = 0; x < _width; x++) {
                GameObject cell = Instantiate(_prefab, new Vector3(x, 0, y), Quaternion.identity, transform);
                float color = Random.value;
                cell.GetComponent<Renderer>().material.color = new Color(color, color, color);
            }
        }
    }

    private void DeleteGraphicMap() {
        foreach (Transform child in transform) {
            GameObject.Destroy(child.gameObject);
        }
    }
}
