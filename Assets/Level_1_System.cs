using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Level_1_System : MonoBehaviour
{
    [SerializeField] private List<Level1Cube> Level1Cubes = new List<Level1Cube>();

    public UnityEvent AllClear ;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CheckCube()
    {
        if (CheckAllCLear())
        {
            AllClear.Invoke();
        }
    }
    
    

    public bool CheckAllCLear()
    {
        bool IsAllClear = true;

        for (int i = 0 ; i < Level1Cubes.Count ; i++)
        {
            if (!Level1Cubes[i].GetIsGaze())
            {
                IsAllClear = false;
            }
        }

        return IsAllClear;
    }
}
