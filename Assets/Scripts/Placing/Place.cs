using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Place : MonoBehaviour
{
    public Vector3 screenPosition;
    public Vector3 worldPosition;

    public Transform hitTransform;

    public GameObject sphere;

    public GameObject canvas;

    private GameObject previewPlacement;

    private MycorrhizaSeeds seeds;

    private CheckPlacement checkPlacement;

    private bool canPlace;

    public int numberOfTreeSeeds;
    public int numberOfMushroomSeeds;

    private bool treeSelected = false;
    private bool mushroomSelected = false;

    PauseMenu pauseMenu;
    tooltipPanel tooltipCall;

    [Header("Number of Seeds")]
    [SerializeField] private GameObject mushroomCounter;
    [SerializeField] private GameObject treeCounter;

    [Header("Audio")]
    //Audio Stuff ;-)
    [SerializeField] private AudioSource placementAudioController;
    [SerializeField] private AudioClip invalidArea;
    [SerializeField] private AudioClip placeMushroom;
    [SerializeField] private AudioClip placeTree;
    [SerializeField] private AudioClip pickSeed;
    [SerializeField] private float volume = 1.0f;

    // Start is called before the first frame update
    private void Start()
    {
        pauseMenu = canvas.GetComponent<PauseMenu>();
        tooltipCall = canvas.GetComponent<tooltipPanel>();
    }
    public void SelectPlant(GameObject seed)
    {
        seeds = seed.GetComponent<MycorrhizaSeeds>();
        previewPlacement = Instantiate(seeds.placementPreview);
        checkPlacement = previewPlacement.GetComponent<CheckPlacement>();
    }

    public void MushroomSelected(GameObject seed)
    {
        DeselectPlant();
        if(numberOfMushroomSeeds <= 0)
        {
            placementAudioController.PlayOneShot(invalidArea, volume);
        }

        else if(numberOfMushroomSeeds > 0 && PauseMenu.GameIsPaused == false && tooltipPanel.TooltipOn == false)
        {
            seeds = seed.GetComponent<MycorrhizaSeeds>();
            previewPlacement = Instantiate(seeds.placementPreview);
            checkPlacement = previewPlacement.GetComponent<CheckPlacement>();
            mushroomSelected = true;
            treeSelected = false;
            placementAudioController.PlayOneShot(pickSeed, volume);
        }
    }

    public void TreeSelected(GameObject seed)
    {
        DeselectPlant();
        if (numberOfTreeSeeds <= 0)
        {
            placementAudioController.PlayOneShot(invalidArea, volume);
        }

        else if (numberOfTreeSeeds > 0 && PauseMenu.GameIsPaused == false && tooltipPanel.TooltipOn == false)
        {
            seeds = seed.GetComponent<MycorrhizaSeeds>();
            previewPlacement = Instantiate(seeds.placementPreview);
            checkPlacement = previewPlacement.GetComponent<CheckPlacement>();
            mushroomSelected = false;
            treeSelected = true;
            placementAudioController.PlayOneShot(pickSeed, volume);
        }
    }

    public void DeselectPlant()
    {
        canPlace = false;
        Destroy(previewPlacement);
        seeds = null;
        previewPlacement = null;
        mushroomSelected = false;
        treeSelected = false;
    }

    // Update is called once per frame
    void Update()
    {
        treeCounter.GetComponent<TextMeshProUGUI>().text = numberOfTreeSeeds.ToString();
        mushroomCounter.GetComponent<TextMeshProUGUI>().text = numberOfMushroomSeeds.ToString();

        screenPosition = Input.mousePosition;
        Ray ray = Camera.main.ScreenPointToRay(screenPosition);

        if (Physics.Raycast(ray, out RaycastHit hitData))
        {
            worldPosition = hitData.point;
            hitTransform = hitData.transform;
        }

        if(previewPlacement != null)
        {
            previewPlacement.transform.position = worldPosition;
            previewPlacement.transform.LookAt(hitData.collider.gameObject.transform);

            if(hitData.collider.gameObject.layer == 9 || checkPlacement.overLapped)
            {
                var materials = checkPlacement.meshRenderer.materials;
                materials[0] = checkPlacement.unplaceable;
                if(seeds.GetComponent<Trees>())
                {
                    materials[1] = checkPlacement.unplaceable;
                }

                checkPlacement.meshRenderer.materials = materials;
                //checkPlacement.meshRenderer.materials[0] = checkPlacement.unplaceable;
                //checkPlacement.meshRenderer.materials[1] = checkPlacement.unplaceable;
                canPlace = false;
            }

            if (hitData.collider.gameObject.layer == 10 && !checkPlacement.overLapped)
            {
                var materials = checkPlacement.meshRenderer.materials;

                for (int i = 0; i < materials.Length; i++)
                {
                    materials[i] = checkPlacement.placeable;
                }

                checkPlacement.meshRenderer.materials = materials;

                //checkPlacement.meshRenderer.materials[0] = checkPlacement.placeable;
                //checkPlacement.meshRenderer.materials[1] = checkPlacement.placeable;
                canPlace = true;
            }

        }

        if (Input.GetMouseButtonDown(0) && canPlace)
        {
            if (treeSelected)
            {
                numberOfTreeSeeds--;
                placementAudioController.PlayOneShot(placeTree, volume);
            }
            else if (mushroomSelected)
            {
                numberOfMushroomSeeds--;
                placementAudioController.PlayOneShot(placeMushroom, volume);
            }
            GameObject seed = Instantiate(seeds.seed, worldPosition, hitTransform.rotation);
            seed.transform.LookAt(hitData.collider.gameObject.transform);
            Destroy(previewPlacement);
            DeselectPlant();
        }
        else if (Input.GetMouseButtonDown(0) && !canPlace)
        {
            if (mushroomSelected || treeSelected)
            {
                placementAudioController.PlayOneShot(invalidArea, volume);
            }
        }
    }

}
