using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stat : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(gameObject.name == "stat")
        {
            GetComponent<TextMesh>().text = "Coins: " + GM1.coins;
        }
        if (gameObject.name == "stat1")
        {
            GetComponent<TextMesh>().text = "Time: " + GM1.coins;
        }
    }
}
