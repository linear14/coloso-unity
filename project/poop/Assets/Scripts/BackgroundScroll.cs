using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScroll : MonoBehaviour
{
    // unity에서는 직접 값을 설정할 수 있게됨
    [SerializeField]
    private float moveSpeed;

    [SerializeField]
    private float posX;

    void Start()
    {
        
    }

    void Update()
    {
        // === Vector3 vec3 = new Vector3(-1, 0, 0);
        // deltaTime : 컴퓨터 성능에 따라서 프레임이 달라지는 것을 방지하기 위해 사용
        transform.position += Vector3.left * moveSpeed * Time.deltaTime;

        if (transform.position.x <= -posX)
        {
            transform.position = new Vector3(posX, 0, 0);
        }
    }
}
