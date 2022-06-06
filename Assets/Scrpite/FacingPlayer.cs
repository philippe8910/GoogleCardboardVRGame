using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FacingPlayer : MonoBehaviour
{
    public GameObject cameraToLookAt;

    public GameObject UICamera;
   
    void Start() 
    {
        
    }
 
    void Update()
    {
        transform.position = Vector3.Lerp(transform.position , new Vector3(cameraToLookAt.transform.position.x , transform.position.y , cameraToLookAt.transform.position.z) , 0.03f);
        
        transform.LookAt(UICamera.transform.position);
        
        
        //transform.rotation = Quaternion.Lerp(transform.rotation , Quaternion.Euler(new Vector3(cameraToLookAt.transform.position.x , cameraToLookAt.transform.position.y , cameraToLookAt.transform.position.z)), 0.05f);
    }
}
