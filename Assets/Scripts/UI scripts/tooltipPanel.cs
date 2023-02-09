using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tooltipPanel : MonoBehaviour
{
    public static bool TooltipOn = false;

    public GameObject tooltipPanelUI;
    public GameObject tooltipButton;
    public GameObject tooltipButtonExit;

    // Start is called before the first frame update
    void Start()
    {
        PauseMenu pauseMenu = GetComponent<PauseMenu>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Question))
        {
            if (TooltipOn)
            {
                EnterTooltip();
            }
            else
            {
                ExitTooltip();
            }
        }
    }

    public void EnterTooltip()
    {
        // Pull up the tooltip overlay and freeze time
        if (PauseMenu.GameIsPaused != true)
        {
            tooltipPanelUI.SetActive(true);
            tooltipButton.SetActive(false);
            tooltipButtonExit.SetActive(true);
            Time.timeScale = 0f;
            TooltipOn = true;
        }
    }

    public void ExitTooltip()
    {
        // Close tooltip panel and restart time
        tooltipPanelUI.SetActive(false);
        tooltipButton.SetActive(true);
        tooltipButtonExit.SetActive(false);
        Time.timeScale = 1f;
        TooltipOn = false;
    }
}
