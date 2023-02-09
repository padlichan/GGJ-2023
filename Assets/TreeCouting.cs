using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeCouting : MonoBehaviour
{
    [SerializeField] private Roots root;
    [SerializeField] private WinCondition winCondition;
    private Place place;

    //Audio References Here.
    private AudioSource treeSounds;
    [SerializeField] AudioClip treeSeedAdded;
    [SerializeField] AudioClip treeHasGrown;
    private float volume = 1.0f;

    // Start is called before the first frame update
    void Start()
    {
        winCondition = FindObjectOfType<WinCondition>();
        place = FindObjectOfType<Place>();

        treeSounds = GetComponent<AudioSource>();
    }

    public void AddToWinCondition()
    {
        //Audio Implementation Here.
        treeSounds.PlayOneShot(treeSeedAdded, 0.5f);

        if(root.connectedToMushroom)
        {
            place.numberOfTreeSeeds++;
        }
        place.numberOfTreeSeeds++;
        winCondition.AddToCount();
    }

    void PlayTreeGrowSound()
    {
        treeSounds.PlayOneShot(treeHasGrown, volume);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
