﻿using UnityEngine;
using System.Collections;

public class BulletScript : MonoBehaviour {

    void OnCollisionEnter2D(Collision2D coll)
    {
        Destroy(gameObject);
    }

    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
