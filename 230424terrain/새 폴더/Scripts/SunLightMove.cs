using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SunLightMove : MonoBehaviour
{

   
   
    [SerializeField,Range(1f,50f)]private float rotSpeed = 10f;
    // Start is called before the first frame update
    
    // Update is called once per frame
    void Update()
    {
        transform.Rotate(rotSpeed*Mathf.Deg2Rad,0f,0f);
        
    }

   
    
   
}
