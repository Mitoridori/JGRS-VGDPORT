﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestinationPoint : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.GetComponent<IEndPoint>() != null)
        {
            other.GetComponent<IEndPoint>().DidReach(true);
        }
    }
}
