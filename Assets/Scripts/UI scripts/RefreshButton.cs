using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RefreshButton : MonoBehaviour
{
    public static bool GameIsReset = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Function called to refresh the level
    public void ResetTheGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        print("Scene refreshed");

        if (GameIsReset == false)
        {
            GameIsReset = true;
        }
    }
}
