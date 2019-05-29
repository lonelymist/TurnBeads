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
    public RaycastHit2D[] hitsR;
    //設定右側碰撞
    public RaycastHit2D[] hitsL;
    //設定左側碰撞
    public RaycastHit2D[] hitsU;
    //設定上側碰撞 
    public RaycastHit2D[] hitsD;
    //設定下側碰撞
    public BallsSystem control;
    private Sprite sprite;

    private int horCount=0;
    private int verCount=0;

    void Start()
    {
        iniPos = transform.position;
        // 一開始的位置值 給 iniPos
        cam = Camera.main;
        // 抓到MainCamera
    }
    void Update()
    {
        if (!Moving)
        {
            iniPos = transform.position;
        }
    }
  
    void OnMouseDrag()
    // 滑鼠再拖移時
    {
        Moving = true;
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
        Moving = false;
        GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 1f);
        // 將顏色復原
        transform.position = iniPos;
        // 回歸初始位置
       
        CheckLink();
        horCount--;
        verCount--;

    }
    void CheckLink()
    {
        hitsR = Physics2D.LinecastAll(transform.position, transform.position + transform.right * 10);
        //向右射出隱形射線(初始值,很遠很遠的地方)
        hitsL = Physics2D.LinecastAll(transform.position, transform.position - transform.right * 10);
        //向左射出隱形射線(初始值,很遠很遠的地方)
        hitsU = Physics2D.LinecastAll(transform.position, transform.position + transform.up * 10);
        //向上射出隱形射線(初始值,很遠很遠的地方)
        hitsD = Physics2D.LinecastAll(transform.position, transform.position - transform.up * 10);
        //向下射出隱形射線(初始值,很遠很遠的地方)

        sprite = GetComponent<SpriteRenderer>().sprite;
        for (int i = 0; i < hitsR.Length; i++)
        {
            if (hitsR[i].collider.GetComponent<SpriteRenderer>().sprite != sprite)
          {
                break;
          }
            horCount++;
        }
        for (int j = 0; j < hitsL.Length; j++)
        {
            if (hitsL[j].collider.GetComponent<SpriteRenderer>().sprite != sprite)
            {
                break;
            }
            horCount++;
        }
        for (int k = 0; k < hitsU.Length; k++)
        {
            if (hitsU[k].collider.GetComponent<SpriteRenderer>().sprite != sprite)
            {
                break;
            }
            verCount++;
        }
        for (int l = 0; l < hitsD.Length; l++)
        {
            if (hitsD[l].collider.GetComponent<SpriteRenderer>().sprite != sprite)
            {
                break;
            }
            verCount++;
        }
        horCount--;
        verCount--;

        if (horCount >= 3)
        {
            foreach (RaycastHit2D hit in hitsR)
            {
                if (hit.collider.GetComponent<SpriteRenderer>().sprite == sprite)
                //如果碰到的圖案跟自己一樣
                {
                    hit.collider.GetComponent<Ball>().Fade();
                    //讓球消失
                }
                else
                {
                    break;
                }
                
            }
            foreach (RaycastHit2D hit in hitsL)
            {
                if (hit.collider.GetComponent<SpriteRenderer>().sprite == sprite)
                //如果碰到的圖案跟自己一樣
                {
                    hit.collider.GetComponent<Ball>().Fade();
                    //讓球消失
                }
                else
                {
                    break;
                }
                
            }
        }
        if (verCount >= 3)
        {
            foreach (RaycastHit2D hit in hitsU)
            {
                if (hit.collider.GetComponent<SpriteRenderer>().sprite == sprite)
                //如果碰到的圖案跟自己一樣
                {
                    hit.collider.GetComponent<Ball>().Fade();
                    //讓球消失
                }
                else
                {
                    break;
                }
                
            }
            foreach (RaycastHit2D hit in hitsD)
            {
                if (hit.collider.GetComponent<SpriteRenderer>().sprite == sprite)
                //如果碰到的圖案跟自己一樣
                {
                    hit.collider.GetComponent<Ball>().Fade();
                    //讓球消失
                }
                else
                {
                    break;
                }
                
            }
        }
            
    }
    void Fade()
    {
        GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0f);
    }
    void OnTriggerEnter2D(Collider2D other)
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