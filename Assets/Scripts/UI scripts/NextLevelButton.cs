using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevelButton : MonoBehaviour
{
    public GameObject progressBarObject;
    public GameObject refreshButton;
    public GameObject refreshCanceller;

    RefreshButton refreshCancel;

    ProgressBar progressBar;

    public string nextLevel;

    // Start is called before the first frame update
    void Start()
    {
        progressBar = progressBarObject.GetComponent<ProgressBar>();
        refreshCancel = refreshCanceller.GetComponent<RefreshButton>();
    }

    // Update is called once per frame
    void Update()
    {
        if (progressBar.current / progressBar.maximum >= 1)
        {
            refreshButton.SetActive(false);
        }

        if (RefreshButton.GameIsReset && nextLevel == "Level_1")
        {
            RefreshButton.GameIsReset = false;
        }
    }

    public void NextLevel()
    {
        // Move to the next level
        SceneManager.LoadScene(nextLevel);
    }
}
