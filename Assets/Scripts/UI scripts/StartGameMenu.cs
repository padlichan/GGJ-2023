using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartGameMenu : MonoBehaviour
{
    public static bool StartMenuUp = true;

    public GameObject startMenuUI;

    public GameObject mainCamera;


    // Start is called before the first frame update
    void Start()
    {
       RefreshButton refreshButton = mainCamera.GetComponent<RefreshButton>();
    }

    // Update is called once per frame
    void Update()
    {
        if (RefreshButton.GameIsReset)
        {
            startMenuUI.SetActive(false);
        }
        
        if (StartMenuUp)
        {
            Time.timeScale = 0f;
        }
    }

    public void StartGame()
    {
        startMenuUI.SetActive(false);
        Time.timeScale = 1f;
        StartMenuUp = false;
    }
}
