using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Poop : MonoBehaviour
{
    [SerializeField]
    private GameObject particle;



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // 실제 충돌 발생하는 경우 (is Trigger 체크 해제)
    // private void OnCollisionEnter2D(Collision collision)
    // {}

    // 충돌이 발생하는 경우 - 스쳐 지나가는 경우 (is Trigger 체크)
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.tag == "Ground") {
            GameManager.instance.AddScore();
        } else if(other.gameObject.tag == "Player") {
            GameManager.instance.GameOver();
            other.gameObject.GetComponent<Player>().CollideWithPoop();
        } else if (other.gameObject.tag == "Poop") {
            return;
        }

        Instantiate(particle, transform.position, Quaternion.identity);
        GetComponent<AudioSource>().Play();
        GetComponent<SpriteRenderer>().enabled = false;
        GetComponent<BoxCollider2D>().enabled = false;
        Destroy(gameObject, 1f);
        
    }
}
