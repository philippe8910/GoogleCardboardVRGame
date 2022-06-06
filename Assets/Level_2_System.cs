using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Level_2_System : MonoBehaviour
{
    [SerializeField] private Material material;
    
    [SerializeField] private int CubeIndex = 0;

    [SerializeField] private List<GameObject> CubeList = new List<GameObject>();

    [SerializeField] private UnityEvent EndLevel;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        CubeList[CubeIndex].GetComponent<MeshRenderer>().material = material;
    }

    public void ClickCube(GameObject TargetGameObject)
    {
        if (TargetGameObject == CubeList[CubeIndex])
        {
            CubeIndex++;
            TargetGameObject.SetActive(false);

            if (CubeIndex  >= CubeList.Count)
            {
                EndLevel.Invoke();
                Debug.Log("Start3"); 
            }
        }
        
    }
}
