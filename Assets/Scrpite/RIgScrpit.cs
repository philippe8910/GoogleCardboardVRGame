using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RIgScrpit : MonoBehaviour
{
    [SerializeField] private bool IsCtrl;

    [SerializeField] private GameObject owo;

    // Start is called before the first frame update
    void Start()
    {
        IsCtrl = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (IsCtrl)
        {
            transform.position = owo.transform.position;
        }
    }

    public void SetIsCtrl(bool _IsCtrl)
    {
        IsCtrl = _IsCtrl;
    }
}
