using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraChange : MonoBehaviour
{
    public GameObject ThirdCam;
    public GameObject FirstCam;
    int CamMode;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Camera"))
        {
            if (CamMode == 1)
                CamMode = 0;
            else
            {
                CamMode += 1;
            }

            StartCoroutine(CanChange());
        }
    }


    IEnumerator CanChange()
    {
        yield return new WaitForSeconds(0.01f);
        if(CamMode == 0)
        {
            ThirdCam.SetActive(true);
            FirstCam.SetActive(false);
        }
        if(CamMode == 1)
        {
            FirstCam.SetActive(true);
            ThirdCam.SetActive(false);
        }
    }
}
