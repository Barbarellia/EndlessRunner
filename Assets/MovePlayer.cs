using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MovePlayer : MonoBehaviour
{
    public float horVel = 0;
    public KeyCode moveL, moveR;
    public int laneNum = 2;
    //public int vertVel = 0;
    public bool controlLocked = false;

    public object GM { get; private set; }

    void Update()
    {
        GetComponent<Rigidbody>().velocity = new Vector3(-2, 0, 0);
        //float horizontal = Input.GetAxisRaw("Horizontal");
        //float vertical = Input.GetAxisRaw("Vertical");
        //Vector3 direction = new Vector3(horizontal, 0, vertical);


        if (Input.GetKeyDown(moveL)&& !controlLocked && laneNum > 1)
        {
            horVel -= 0.73f;
            StartCoroutine(stopSlide());
            laneNum -= 1;
            controlLocked = true;
            gameObject.transform.Translate(0f, 0f, horVel);
        }

        if (Input.GetKeyDown(moveR) && !controlLocked && laneNum < 3)
        {
            horVel += 0.73f;
            StartCoroutine(stopSlide());
            laneNum += 1;
            controlLocked = true;
            gameObject.transform.Translate(0f, 0f, horVel);
        }
    }

    public Transform boomObj;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Respawn")
        {
            gameObject.transform.position = new Vector3(0f, 0.73f, 0f);
            horVel = 0;
            laneNum = 2;
            controlLocked = false;
        }
        if(collision.gameObject.tag=="lethal")
        {
            Destroy(gameObject);
            GM1.zVelAdj = 0;
            Instantiate(boomObj, transform.position, boomObj.rotation);
            GM1.lvlCompStatus = "Fail!";



        }
        if (collision.gameObject.tag == "coin")
        {
            GM1.coins++;
            Destroy(collision.gameObject);
            GM1.zVelAdj = 0;
        }
    }

    public void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.name == "bridge") GM1.vertVel = 2;
        if (collision.gameObject.name == "bridge2") GM1.vertVel = 0;
        if(collision.gameObject.name=="exit")
        {
            SceneManager.LoadScene("levelComplete");
        }
    }

    IEnumerator stopSlide()
    {
        yield return new WaitForSeconds(.5f);
        horVel = 0;
        controlLocked = false;
    }
}
