using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour {

    private Transform target;

    private int choise_b;
    private int choise_e; 
    private float x;
    private float z;
    [SerializeField] private float dy;

    IEnumerator StartGame()
    {

        while(choise_b == choise_e)
        {
            choise_e = Random.Range(-1, 2);
        }       

        yield return new WaitForSeconds(1);

        if (choise_e == -1)
        {
            target.position = new Vector3(x, -dy, z);
        }
        else if (choise_e == 0)
        {
            target.position = new Vector3(x, 0, z);
        }
        else if (choise_e == 1)
        {
            target.position = new Vector3(x, dy, z);
        }

        choise_b = choise_e;

    }

    void Start () {

        target = GetComponent<Transform>();

        x = target.position.x;
        z = target.position.z;

        choise_b = 0;
        choise_e = 0;
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.name == "Ball")
        {
            StartCoroutine(StartGame());

        }
    }

}
