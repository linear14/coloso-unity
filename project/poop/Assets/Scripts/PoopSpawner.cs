using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoopSpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject[] poops;

    [SerializeField]
    private float spawnInterval = 1f;


    void Start()
    {
        StartSpawning();
    }

    private void StartSpawning() {
        StartCoroutine("SpawnPoopRoutine");
    }

    public void StopSpawning() {
        StopCoroutine("SpawnPoopRoutine");
    }

    IEnumerator SpawnPoopRoutine() {
        yield return new WaitForSeconds(1f);
        while(true) {
            SpawnPoop();
            yield return new WaitForSeconds(spawnInterval);
        }
    }

    void Update()
    {
        
    }

    public void SpawnPoop()
    {
        int randomIndex = Random.Range(0, poops.Length);
        float randomXPosition = Random.Range(-3f, 3f);
        Vector3 position = new Vector3(randomXPosition, 6, 0);
    
        // 새로운 게임 오브젝트를 만드는 함수 Instantiate
        // 별도 회전을 안넣을거면 3번째 파라미터 값으로 Quaternion.identity를 넣어줌
        Instantiate(poops[randomIndex], position, Quaternion.identity);
    }

    public bool IncreaseSpeed() {
        if(spawnInterval <= 0.2f) {
            spawnInterval = 0.2f;
            return false;
        }

        spawnInterval -= 0.1f;
        return true;
    }
}
