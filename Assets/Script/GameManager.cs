using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    int Score = 0;
    public static GameManager Instance { get; private set; }
// Write down your variables here

    private void Awake()
    {
        Instance = this;
    }

    public void IncrementScore()
    {
        //Increment score
        ++Score;
        Debug.Log("Score : "+ Score);
    }
}
