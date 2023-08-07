using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public GameObject player;
    void Awake()
    {
        Instance = this;
    }

    public static void BossDead()
    {
        SceneManager.LoadScene("Main Ending");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
