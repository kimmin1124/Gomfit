using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    [SerializeField] private float fallSpeed = 2.5f;
    private Transform myTransform;
    private bool isInit = false;
    public void Init()
    {
        myTransform = GetComponent<Transform>();
        isInit = true;
    }

    private void Update()
    {
        if (!isInit)
        {
            return;
        }
        var curSpeed = fallSpeed * Time.deltaTime;
        myTransform.Translate(Vector3.down * curSpeed);
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        Destroy(this.gameObject);
    }
}
