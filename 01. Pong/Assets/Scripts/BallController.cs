using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BallController : MonoBehaviour
{
    public float speed;
    public Vector2 direction;
    public delegate void Score(int side);
    public Score addScore = null;

    // Start is called before the first frame update
    void Start()
    {
        addScore += ResetBall;
        transform.position = new Vector3(0, 0, -1);
        speed = 5;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(speed * Time.deltaTime * direction);
        if (transform.position.x < -10) addScore?.Invoke(1);
        if (transform.position.x > 9) addScore?.Invoke(0);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<PaddleController>() != null)
        {
            direction.x = -direction.x;
            direction.y = Random.Range(-1.0f, 1.0f);
            speed += 1;
        }
        else direction.y = -direction.y;
    }

    private void ResetBall(int _)
    {
        transform.position = new Vector3(0, 0, -1);
        speed = 5;
    }
}
