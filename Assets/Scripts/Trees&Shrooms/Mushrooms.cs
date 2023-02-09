using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mushrooms : MycorrhizaSeeds
{
    [SerializeField] private Roots root;

    enum GrowthStates { Seed, Mushroom}
    private GrowthStates growthStates;

    private GameObject[] mushroomStates;

    private Place place;

    //Audio References Here.
    private AudioSource mushroomSounds;
    [SerializeField] AudioClip mushroomSeedAdded;
    [SerializeField] AudioClip mushroomSpread;
    private float volume = 1.0f;

    private void Start()
    {
        place = FindObjectOfType<Place>();
        mushroomSounds = GetComponentInChildren<AudioSource>();
    }

    public override void Update()
    {
    }

    public void AddMushroom()
    {
        //Audio Implementation Here.
        mushroomSounds.PlayOneShot(mushroomSeedAdded, volume);

        if(root.connectedToTree)
        {
            place.numberOfMushroomSeeds++;
        }
        place.numberOfMushroomSeeds++;
    }

    public void PlayMushroomGrowSound()
    {
        mushroomSounds.PlayOneShot(mushroomSpread, volume);
    }
}
