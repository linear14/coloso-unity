using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public int gameLevel = 1;
    public int gameSpeed = 1;

    private void Awake() {
        if (instance == null) {
            instance = this;
        }
    }
}
