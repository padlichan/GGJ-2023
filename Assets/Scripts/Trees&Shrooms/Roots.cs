using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Roots : MonoBehaviour
{
    public enum RootParent { Tree, Mushroom };
    [SerializeField] private RootParent rootParent;

    [SerializeField] private GameObject[] roots;

    [SerializeField] private Material glow;

    public bool connectedToTree;
    public bool connectedToMushroom;

    //Audio references Here.
    private AudioSource connectionMade;

    private void Start()
    {
        connectionMade = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other);
        if(other.GetComponent<Roots>())
        {
            connectionMade.Play();
            if(other.GetComponent<Roots>().rootParent != this.GetComponent<Roots>().rootParent)
            {
                foreach (GameObject root in roots)
                {
                    if (root.GetComponent<MeshRenderer>())
                    {
                        root.GetComponent<MeshRenderer>().material = glow;
                    }
                }
            }

            if (other.GetComponent<Roots>().rootParent == RootParent.Tree)
            {
                GetComponentInParent<MycorrhizaSeeds>().OverlapWithTree();
                connectedToTree = true;
            }

            if (other.GetComponent<Roots>().rootParent == RootParent.Mushroom)
            {
                GetComponentInParent<MycorrhizaSeeds>().OverlapWithMushroom();
                connectedToMushroom = true;
            }
        }



        //if (other.GetComponent<Mushrooms>() && other.GetComponent<Mushrooms>() != this.GetComponent<Mushrooms>())
        //{
        //    other.GetComponentInParent<Mushrooms>().OverlapWithMushroom();
        //}
    }
}
