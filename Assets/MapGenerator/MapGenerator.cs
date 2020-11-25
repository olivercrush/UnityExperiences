using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGenerator : MonoBehaviour
{
    public GameObject _prefab;
    public GameObject _camera;

    public int _width = 5;
    public int _height = 5;

    public float _xOrigin = 0f;
    public float _yOrigin = 0f;
    public float _scale = 1f;

    // Start is called before the first frame update
    void Start()
    {
        GenerateGraphicMapAtOrigin();
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.S)) {
            _yOrigin--;
            GenerateGraphicMapAtOrigin();
        }

        if (Input.GetKey(KeyCode.W)) {
            _yOrigin++;
            GenerateGraphicMapAtOrigin();
        }

        if (Input.GetKey(KeyCode.A)) {
            _xOrigin--;
            GenerateGraphicMapAtOrigin();
        }

        if (Input.GetKey(KeyCode.D)) {
            _xOrigin++;
            GenerateGraphicMapAtOrigin();
        }
    }

    public void GenerateGraphicMapAtOrigin() {
        GenerateGraphicMap(_width, _height, _xOrigin, _yOrigin, _scale);
    }

    public void GenerateGraphicMapAtRandom() {
        GenerateGraphicMap(_width, _height, Random.value*100f, Random.value*100f, _scale);
    }

    private void GenerateGraphicMap(int width, int height, float xOrigin, float yOrigin, float scale) {
        DeleteGraphicMap();
        for (int y = 0; y < height; y++) {
            for (int x = 0; x < width; x++) {
                GameObject cell = Instantiate(_prefab, new Vector3(x, 0, y), Quaternion.identity, transform);

                float xNoise = xOrigin + x / (width * scale);
                float yNoise = yOrigin + y / (height * scale);
                float color = Mathf.PerlinNoise(xNoise, yNoise);
                //Debug.Log(color);
                cell.GetComponent<Renderer>().material.color = new Color(color, color, color);
            }
        }
        PlaceCameraAtCenter();
    }

    private void DeleteGraphicMap() {
        foreach (Transform child in transform) {
            GameObject.Destroy(child.gameObject);
        }
    }

    private void PlaceCameraAtCenter() {
        _camera.transform.position = new Vector3(_width / 2, _width, _height / 2);
    }
}
