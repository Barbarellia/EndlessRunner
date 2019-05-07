using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCamera : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Rigidbody>().velocity = new Vector3(0, GM1.zVelAdj, 4*GM1.zVelAdj);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
