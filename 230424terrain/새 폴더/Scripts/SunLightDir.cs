using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SunLightDir : MonoBehaviour
{
    [SerializeField] private Transform terrain = null;
    [SerializeField] private GameObject moon = null;
    private Light sun=null;

    private void Awake()
    {
        sun = GetComponent<Light>();
    }

    private void Update()
    {
        Vector3 forwardvec = transform.forward;
        Vector3 dirvec = terrain.position - transform.position ;

      

        float forwardYZAngle = Mathf.Atan2(forwardvec.y, forwardvec.z) * Mathf.Rad2Deg;
        float dirYZAngle = Mathf.Atan2(dirvec.y, dirvec.z)   * Mathf.Rad2Deg;
        Debug.Log(dirYZAngle);
        #region 객체지향적으로 뭔가 잘못된거같은 구조
        SunLightIntensityCal(dirYZAngle);
       
        if (dirYZAngle >0f &&dirYZAngle<180f)
        {
            moon.SetActive(true);
            
        }
        if(dirYZAngle>-180f && dirYZAngle<0f)
        {
            moon.SetActive(false);
            
        }
        #endregion
        float changeYZAngle = 0f;
        if (forwardYZAngle != dirYZAngle)
        {
            changeYZAngle = forwardYZAngle - dirYZAngle ;
        }
        else
        {
            changeYZAngle = 0f;
        }

        transform.Rotate(changeYZAngle,0f, 0f);
    }

    private void SunLightIntensityCal(float _dirYZAngle)
    {
        const float MAX_SUN_LIGHT = 13000f;
        const float RATE_ANGLE_SUN_LIGHT = MAX_SUN_LIGHT / 90f;
        const float MAX_MOON_LIGHT = 1f;
        const float RATE_ANGLE_MOON_LIGHT = MAX_MOON_LIGHT / 10f;

        if (_dirYZAngle > 170f && _dirYZAngle < 180f)
        {
            sun.intensity =(_dirYZAngle-170)* RATE_ANGLE_MOON_LIGHT;
            Debug.Log(sun.intensity);
        }
        if (_dirYZAngle > 0f && _dirYZAngle < 10f)
        {
            sun.intensity = 1-(_dirYZAngle  * RATE_ANGLE_MOON_LIGHT);
            Debug.Log(sun.intensity);
        }
        if (_dirYZAngle > -90f)
        {
            sun.intensity = -(_dirYZAngle-1f)* RATE_ANGLE_SUN_LIGHT;
        }

        if (_dirYZAngle < -90f)
        {
            sun.intensity = (180f + _dirYZAngle) * RATE_ANGLE_SUN_LIGHT;
        }
            

    }
}
