using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineController : MonoBehaviour
{
    public static LineController instance;

    [SerializeField]
    private GameObject line;

    private void Awake() {
        if (instance == null) {
            instance = this;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        InitializeLine();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void InitializeLine() {
        float[] yPositions = new float[] { -5f, 1f, 7f }; 
        for (int i = 0; i < yPositions.Length; i++) {
            CreateLine(-1.4f, yPositions[i]);
            CreateLine(1.4f, yPositions[i]);
        }
    }

    public void CreateLine(float xPosition, float yPosition = -11f) {
        Instantiate(line, new Vector3(xPosition, yPosition, 0), Quaternion.identity);
    }
}
