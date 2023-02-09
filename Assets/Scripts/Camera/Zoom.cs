using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zoom : MonoBehaviour
{
    [SerializeField] private float scrollSpeed;
    [SerializeField] private GameObject m_Camera;
    private RotatePlanet m_RotatePlanet;

    // Start is called before the first frame update
    void Start()
    {
        m_RotatePlanet = this.gameObject.GetComponent<RotatePlanet>();
    }

    // Update is called once per frame
    void Update()
    {
        m_RotatePlanet.distanceToTarget = Mathf.Clamp(m_RotatePlanet.distanceToTarget -= Input.GetAxis("Mouse ScrollWheel") * scrollSpeed, 75, 130);
    }
}
