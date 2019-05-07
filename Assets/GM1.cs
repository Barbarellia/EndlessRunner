using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GM1 : MonoBehaviour
{
    public static float vertVel = 0;
    public static int coins = 0;
    public static float time = 0;
    public static float zVelAdj = 0;
    public static string lvlCompStatus = "";
    public static float waitToLoad = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        if(lvlCompStatus=="Fail!")
        {
            waitToLoad += Time.deltaTime;

        }
        if (waitToLoad > 2) SceneManager.LoadScene("levelComp");
    }
}
