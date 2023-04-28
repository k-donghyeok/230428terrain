using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.HighDefinition;

public class SpaceMove : MonoBehaviour
{
    [SerializeField]private PhysicallyBasedSky sky = null;
    [SerializeField]private Volume nightVolume = null;
    [SerializeField,Range(1f,5f)]private float rotateSpeed = 1.0f;

    private void Awake()
    {
        nightVolume = GetComponent<Volume>();
       
    }

    private void Update()
    {
        
       
        
        if (nightVolume.sharedProfile.TryGet(out sky))
        {
            Vector3 current = sky.spaceRotation.value;
            current.z += Time.deltaTime * rotateSpeed;
            sky.spaceRotation.value = current;
        }

    }
}
