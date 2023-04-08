using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Line : MonoBehaviour
{
    void Update()
    {
        transform.Translate(Vector3.up * GameManager.instance.gameSpeed * Time.deltaTime);

        if(transform.position.y > 9f) {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.tag == "LineCreator") {
            LineController.instance.CreateLine(transform.position.x);
        }
    }
}
