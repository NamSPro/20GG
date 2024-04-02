using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleController : MonoBehaviour
{
    public float speed;
    public float input;

    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(transform.position.x, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        input = Input.GetAxis("Vertical");
        transform.Translate(input * speed * Time.deltaTime * Vector2.up);
        transform.position = new Vector3(transform.position.x, Mathf.Clamp(transform.position.y, -4, 4), transform.position.z);
    }
}
