using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    Transform camTrans;
    public float shakeTime, shakeRange;
    Vector3 originalPos;


    private void Start()
    {
        camTrans = Camera.main.transform;
        originalPos = camTrans.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            StartCoroutine(ShakeCamera());
        }
    }

    IEnumerator ShakeCamera()
    {
        float elapsedTime = 0;

        while (elapsedTime < shakeTime)
        {
            //It gives us a random value on x y and z by creating a sphere and randomly select a point
           Vector3 pos = originalPos+ Random.insideUnitSphere* shakeRange;

            //the z position of the camera will be unchanged
            pos.z = originalPos.z;
            camTrans.position = pos;
            elapsedTime += Time.deltaTime;

            yield return null;  
        }

        //Camera returns to it's original position after it finish shaking  
        camTrans.position = originalPos;
    }
}
