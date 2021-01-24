using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMove : MonoBehaviour {

    [SerializeField] private float speed = 30f;
    [SerializeField] private TextMesh LScore, RScore;
    private int L_score = 0, R_score = 0;
    private int f;
    private int x, y;
    private Transform target;
    private Vector2 direction;


    IEnumerator BallStart()
    {
        //System.Threading.Thread.Sleep(5000);

        f = Random.Range(0, 2);
        if(f == 0){ x = -1; }
        else{ x = 1; }

        f = Random.Range(0, 2);
        if (f == 0) { y = -1; }
        else { y = 1; }

        yield return new WaitForSeconds(2);

        target.position = new Vector3(0, 0, 0);
        direction = new Vector2(x, y);

    }

    void Start()
    {
        target = GetComponent<Transform>();
     
        f = Random.Range(0, 2);
        if (f == 0) { x = -1; }
        else { x = 1; }

        f = Random.Range(0, 2);
        if (f == 0) { y = -1; }
        else { y = 1; }

        direction = new Vector2(x, y);

        //direction = Vector2.one.normalized;
        
    }

    void Update()
    {
        transform.Translate(direction * speed * Time.deltaTime);

        if (target.position.y > 90 || target.position.y < -90)
        {           
            target.position = new Vector3(0, 0, 0);
            direction = new Vector2(x, y);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.name == "RacketLeft")
        {
            direction.x = -direction.x;          
        }
        else if(collision.gameObject.name == "RacketRight")
        {            
            direction.x = -direction.x;
        }

        else if(collision.gameObject.tag == "WallHor")
        {
            direction.y = -direction.y;

        }
    
        //if(collision.gameObject.name == "WallLeft")
        //{
        //     R_score++;
        //     RScore.text = "" + R_score;
        //     StartCoroutine(BallStart());
        //}


        if (collision.gameObject.tag == "WallVert")
        {
            direction.x = -direction.x;

        }

        //if(collision.gameObject.name == "WallRight")
        //{
        //     L_score++;
        //     LScore.text = "" + L_score;
        //     StartCoroutine(BallStart());
        //}

        if (collision.gameObject.name == "Gates_Right")
        {
            L_score++;
            LScore.text = "" + L_score;
            StartCoroutine(BallStart());
        }

        if (collision.gameObject.name == "Gates_Left")
        {
            R_score++;
            RScore.text = "" + R_score;
            StartCoroutine(BallStart());
        }
    }
}
