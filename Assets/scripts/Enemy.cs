using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private int pos;
    public float speed;

    void Start()
    {
        pos = -1;
    }

    void Update()
    {
        transform.position += new Vector3(pos, 0, 0) * (speed * Time.deltaTime);
    }
    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("plat2"))
        {
            pos = 1;
        }
        else if (col.gameObject.CompareTag("plat3"))
        {
            pos = -1;
        }
    }
}