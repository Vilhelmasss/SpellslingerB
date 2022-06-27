using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;
using Scene = UnityEngine.SceneManagement.Scene;

public class GM_Main : MonoBehaviour
{
    [SerializeField] private KeyCode pauseKey;
    [SerializeField] private KeyCode restartKey;

    private SceneManager sceneManager;
    // Update is called once per frame
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

        if (Input.GetKeyDown(restartKey))
        {
            Scene scene = SceneManager.GetActiveScene();
            SceneManager.LoadScene(scene.name);
        }
    }
}
