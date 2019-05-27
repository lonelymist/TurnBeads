using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    private Camera cam;
    private Vector2 newPos;
    private Vector3 iniPos;
    private Vector3 Temp;
    private bool Moving;
    void Start()
    {
        iniPos = transform.position;
        cam = Camera.main;
    }
    void Update()
    {
        if (transform.position == iniPos)
        {
            Moving = false;
        }
        else
        {
            Moving = true;
        }
    }
    void OnMouseDrag()
    {
        newPos = cam.ScreenToWorldPoint(Input.mousePosition);
        newPos.x = Mathf.Clamp(newPos.x, -5.9f , 5.85f);
        newPos.y = Mathf.Clamp(newPos.y, -8.25f, 2.15f);
        transform.position = new Vector2(newPos.x, newPos.y);
    }
    void OnMouseUp()
    {
        transform.position = iniPos;
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (Moving)
        {
            Temp = iniPos;
            iniPos = other.transform.position;
            other.transform.position = Temp;
        }
    }
}