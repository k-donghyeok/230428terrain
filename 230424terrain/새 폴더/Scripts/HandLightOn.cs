using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandLightOn : MonoBehaviour
{
    [SerializeField]private GameObject handLight = null;

    private bool isLightOn = false;
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.H))
        {
            if(isLightOn)
            {
                handLight.SetActive(false);
                isLightOn = false;
            }
            else
            {
                handLight.SetActive(true);
                isLightOn = true;
            }
            
        }
    }
}
