using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgressBar : MonoBehaviour
{
    public int maximum;
    public int current;
    public Image fill;

    public GameObject inputSystem;
    public GameObject nextLevelButton;
    public GameObject restartGameScript;
    public GameObject restartButton;

    WinCondition winCondition;
    PauseMenu restartGame;
    NextLevelButton nextLevelString;

    // maximum is the value for complete surface area covering
    // current is value for surface area currently covered by player

    void Start()
    {
        winCondition = inputSystem.GetComponent<WinCondition>();
        restartGame = restartGameScript.GetComponent<PauseMenu>();
        nextLevelString = nextLevelButton.GetComponent<NextLevelButton>();
        maximum = winCondition.winningNumber;
    }

    // Go get the current fill of the bar from the GetCurrentFill function
    void Update()
    {
        current = winCondition.currentNumTrees;
        GetCurrentFill();
       
        if (current / maximum >=1 )
            {
                nextLevelButton.SetActive(true);
            }

           
    }

    // Calculate fill amount with current value/maximum value
    void GetCurrentFill()
    {
        fill.fillAmount = (float)current / (float)maximum;
    }
}
