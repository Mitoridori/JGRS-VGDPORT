using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseCharacter : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<CapsuleCollider>().center = gameObject.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
