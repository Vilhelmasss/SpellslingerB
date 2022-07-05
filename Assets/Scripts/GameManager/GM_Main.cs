using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//using UnityEngine.SceneManagement.Scene;
//using UnityEngine.SearchService;


public class GM_Main : MonoBehaviour
{
    [SerializeField] private KeyCode pauseKey;
    [SerializeField] private KeyCode restartKey;
    public GameObject Player;
    private SceneManager sceneManager;

    public static GM_Main Instance { get; private set; }
    private void Awake()
    {

        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(pauseKey))
        {
            if (Time.timeScale == 1)
            {
                Time.timeScale = 0f;
            }
            else
            {
                Time.timeScale = 1f;
            }
        }

//        if (Input.GetKeyDown(restartKey))
//        {
//            Scene scene = SceneManager.GetActiveScene();
//            SceneManager.LoadScene(scene.name);
//        }
    }
}
