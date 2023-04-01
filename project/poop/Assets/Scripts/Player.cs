using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    private Animator animator;

    [SerializeField]
    private float moveSpeed = 5.0f;

    private string playerDirection = "right";

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        // 키보드 입력을 받아서 이동
        // 왼쪽 방향키를 누르면 왼쪽으로 이동
        // 오른쪽 방향키를 누르면 오른쪽으로 이동

        if(Input.GetKey(KeyCode.LeftArrow))
        {
            
            // 상대적인 움직임 (현재 위치에서 이동하는 방식)
            transform.Translate(Vector3.left * moveSpeed * Time.deltaTime);
            
            // 절대적인 움직임 (좌표값을 이용해서 이동하는 방식)
            // transform.position = new Vector3(transform.position.x - moveSpeed * Time.deltaTime, transform.position.y, transform.position.z);
            // or
            // transform.position += Vector3.left * moveSpeed * Time.deltaTime;

            animator.SetBool("isRunning", true);


            // 캐릭터 왼쪽으로 바라보도록 변경
            playerDirection = "left";
        }
        else if(Input.GetKey(KeyCode.RightArrow))
        {
            transform.Translate(Vector3.right * moveSpeed * Time.deltaTime);
            animator.SetBool("isRunning", true);

            // 캐릭터 오른쪽으로 바라보도록 변경
            playerDirection = "right";
        }
        else {
            animator.SetBool("isRunning", false);
        }

        // 캐릭터 방향 전환
        if(playerDirection == "left")
        {
            Vector3 currentScale = transform.localScale;
            float newX = -Mathf.Abs(currentScale.x);
            transform.localScale = new Vector3(newX, currentScale.y, currentScale.z);
        }
        else if(playerDirection == "right")
        {
            Vector3 currentScale = transform.localScale;
            float newX = Mathf.Abs(currentScale.x);
            transform.localScale = new Vector3(newX, currentScale.y, currentScale.z);
        }

    }
}
