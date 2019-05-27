using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    private Camera cam;
    // 抓Camera
    private Vector3 newPos;
    // 宣告newPos 等等用來做滑鼠座標
    private Vector3 iniPos;
    // 宣告iniPos 等等用來做初始座標
    private Vector3 Temp;
    // 等等互換值 用來暫存
    private bool Moving;
    // 判斷是否在移動
    void Start()
    {
        iniPos = transform.position;
        // 一開始的位置值 給 iniPos
        cam = Camera.main;
        // 抓到MainCamera
    }
    void Update()
    {
        if (transform.position == iniPos)
            // 如果目前位置等於初始位置
        {
            Moving = false;
            // 就是沒在移動
        }
        else
        {
            Moving = true;
            // 不等於就是在移動
        }
    }
    void OnMouseDrag()
    // 滑鼠再拖移時
    {
        GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0.7f);
        // 將當前物件調整為稍微透明
        newPos = cam.ScreenToWorldPoint(Input.mousePosition);
        // 抓到目前滑鼠座標
        newPos.x = Mathf.Clamp(newPos.x, -5.9f , 5.85f);
        // 限制x座標範圍
        newPos.y = Mathf.Clamp(newPos.y, -8.25f, 2.15f);
        // 限制y座標範圍
        transform.position = new Vector3(newPos.x, newPos.y,0);
        // 將剛剛設定好的座標 給當前物件
    }
    void OnMouseUp()
        //滑鼠放開時
    {
        GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 1f);
        // 將顏色復原
        transform.position = iniPos;
        // 回歸初始位置
    }
    private void OnTriggerEnter2D(Collider2D other)
        // 撞到其他物件時
    {
        if (Moving && other.gameObject.tag=="Ball")
            // 如果在移動 和 碰撞物件tag 為 Ball時
        {
            Temp = iniPos;
            // 先將當前物件的初始座標暫存
            iniPos = other.transform.position;
            // 再將碰到的物件的初始座標換到當前座標
            other.transform.position = Temp;
            // 最後把剛剛暫存的座標替換到被撞到的物件上
        }
    }
}