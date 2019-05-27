using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    private Camera cam;
    private Vector2 newPos;
    private Vector2 iniPos;
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
    void Start()
    {
        iniPos = transform.position;
        cam = Camera.main;
    }
}