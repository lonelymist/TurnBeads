using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mouse : MonoBehaviour
{
    private Camera cam;
    // 抓Camera
    private Vector3 newPos;
    // 宣告newPos 等等用來做滑鼠座標
    private bool Moving = false;
    private GameObject TempGameObject;
    void Start()
    {
        GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0f);
        cam = Camera.main;
        // 抓到MainCamera 
    }
    void Update()
    {
        newPos = cam.ScreenToWorldPoint(Input.mousePosition);
        // 抓到目前滑鼠座標
        newPos.x = Mathf.Clamp(newPos.x, -5.9f, 5.85f);
        // 限制x座標範圍
        newPos.y = Mathf.Clamp(newPos.y, -8.25f, 2.15f);
        // 限制y座標範圍
        transform.position = new Vector3(newPos.x, newPos.y, 0);
        // 將剛剛設定好的座標 給當前物件
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (!Moving)
        {
            GetComponent<SpriteRenderer>().sprite = null;
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!Moving)
        {
            TempGameObject = other.gameObject;
            GetComponent<SpriteRenderer>().sprite = other.GetComponent<SpriteRenderer>().sprite;
        }
        if (Moving)
        {
            other.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0f);
            TempGameObject.GetComponent<SpriteRenderer>().sprite = other.GetComponent<SpriteRenderer>().sprite;
            TempGameObject.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 1f);
            TempGameObject = other.gameObject;
        }
    }
    private void OnMouseDrag()
    {
        if(GetComponent<SpriteRenderer>().sprite != null)
        {
            TempGameObject.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0f);
            Moving = true;
            GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0.7f);
            GetComponent<CircleCollider2D>().radius = 0.4f;
        }
    }
    private void OnMouseUp()
    {
        if(GetComponent<SpriteRenderer>().sprite != null)
        {
            Moving = false;
            TempGameObject.GetComponent<SpriteRenderer>().sprite = GetComponent<SpriteRenderer>().sprite;
            TempGameObject.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 1f);
            GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0f);
            GetComponent<SpriteRenderer>().sprite = null;
            GetComponent<CircleCollider2D>().radius = 0.01f;
            GameObject.Find("BallsSystem").SendMessage("GroupBall");
        }
    }
}
