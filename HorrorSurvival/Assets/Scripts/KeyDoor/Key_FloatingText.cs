using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    Transform mainCam;
    Transform unit;
    Transform worldSpaceCanvas;

    //[SerializeField] private GameObject myKey = null;

    public Vector3 offset;
    // Start is called before the first frame update
    void Start()
    {
        mainCam = Camera.main.transform;
        unit = transform.parent;
        worldSpaceCanvas = GameObject.FindObjectOfType<Canvas>().transform;

        transform.SetParent(worldSpaceCanvas);
    }

    // Update is called once per frame
    void Update()
    {
        transform.rotation = Quaternion.LookRotation(transform.position - mainCam.transform.position); // Look at cam
        transform.position = unit.position + offset;

        //if (myKey.activeSelf == false)
        //{ // hide text when key is picked up
        //    gameObject.SetActive(false);
        //}
        //else
        //{
        //    gameObject.SetActive(true);
        //}

    }
}
