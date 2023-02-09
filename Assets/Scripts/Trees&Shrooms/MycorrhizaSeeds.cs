using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MycorrhizaSeeds : MonoBehaviour
{
    enum GrowthSpeeds { Normal, Fast, Stop };
    [SerializeField] private GrowthSpeeds growthSpeeds;

    [SerializeField] private float growthSpeed;
    [SerializeField] private float currentSpeed; 

    public GameObject seed;
    public GameObject placementPreview;

    [SerializeField] private bool treeOverlap;
    [SerializeField] private bool mushroomOverlap;
    [SerializeField] private bool spedUp;

    public float timeToFullGrowth;
    public float currentTime;

    public bool stopCounting;

    // Start is called before the first frame update
    void Start()
    {
        stopCounting = false;
        growthSpeeds = GrowthSpeeds.Normal;
        currentTime = timeToFullGrowth;
    }

    // Update is called once per frame
    public virtual void Update()
    {

        //switch (growthSpeeds)
        //{
        //    case GrowthSpeeds.Normal:
        //        currentSpeed = growthSpeed;
        //        break;
        //    case GrowthSpeeds.Fast:
        //        currentSpeed = growthSpeed + (growthSpeed * 0.5f);
        //        break;
        //    case GrowthSpeeds.Stop:
        //        currentSpeed = growthSpeed - growthSpeed;
        //        break;
        //    default:
        //        break;
        //}

    }

    void CheckGrowthSpeed()
    {
        if(GetComponentInChildren<TreeCouting>())
        {
            TreeCouting treeCouting = GetComponentInChildren<TreeCouting>();
            if (treeOverlap && mushroomOverlap)
            {
                treeCouting.gameObject.GetComponent<Animator>().speed = 2;
                //stopCounting = false;
                //growthSpeeds = GrowthSpeeds.Fast;
                //if (!spedUp)
                //{
                //    currentTime /= 2;
                //}
                //spedUp = true;
                //Debug.Log("Fast");
            }

            else if (treeOverlap)
            {
                treeCouting.gameObject.GetComponent<Animator>().speed = 0;
                //stopCounting = true;
                //growthSpeeds = GrowthSpeeds.Stop;
                //Debug.Log("Slow");
            }

            else if (mushroomOverlap)
            {
                treeCouting.gameObject.GetComponent<Animator>().speed = 2;
                //stopCounting = false;
                //growthSpeeds = GrowthSpeeds.Fast;
                //if (!spedUp)
                //{
                //    currentTime /= 2;
                //}
                //spedUp = true;
                //Debug.Log("Fast");
            }
        }
    }

    public void OverlapWithTree()
    {
        treeOverlap = true;
        CheckGrowthSpeed();
    }

    public void OverlapWithMushroom()
    {
        mushroomOverlap = true;
        CheckGrowthSpeed();
    }
}
