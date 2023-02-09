using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinCondition : MonoBehaviour
{
    [SerializeField] public int currentNumTrees;
    [SerializeField] public int winningNumber;

    private bool winConditionMet;

    // Start is called before the first frame update
    void Start()
    {
        currentNumTrees = 0;
        winConditionMet = false;
    }

    public void AddToCount()
    {
        currentNumTrees++;
        if(currentNumTrees >= winningNumber)
        {
            winConditionMet = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(winConditionMet)
        {
            if(Input.GetKeyDown(KeyCode.Space))
            {

            }
        }
    }
}
