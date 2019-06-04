﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class BallsSystem : MonoBehaviour
{
    public List<Sprite> BallsType;
    // 宣告不同種珠子Sprite的list
    private List<GameObject> BallNumber = new List<GameObject>(30);
    // 宣告珠子Transform的list
    private int count = 0;
    // 用來計算第幾個珠子
    private Vector3 EachPosition;
    Sprite nowSprite;
    public List<float> no;
    void Start()
    {
        for(int i=0; i < 6; i++)
        {
            for(int j = 0; j < 5; j++)
            {
                CreateNewBall(i,j);
                ChangeSprite(BallNumber[count]);
                count++;
            }
        }
    }
    float NewBallPositionX(int x)
    {
        return -5.9f + 2.35f * x;
    }
    float NewBallPositionY(int y)
    {
        return 2.15f - 2.6f * y;
    }
    void CreateNewBall(int x,int y)
    {
        GameObject newBall = Instantiate(Resources.Load<GameObject>("Ball"));
        // 設定新珠子 從Resource裡複製一個珠子
        newBall.transform.position = new Vector2(NewBallPositionX(x), NewBallPositionY(y));
        BallNumber.Add(newBall);
    }
    public void AllCheckLink()
    {
       foreach(GameObject EachBall in BallNumber)
       {
            int horCount = 0;
            int verCount = 0;
            EachPosition = EachBall.transform.position;
            nowSprite = EachBall.GetComponent<SpriteRenderer>().sprite;
            RaycastHit2D[] hitsR = Physics2D.LinecastAll(EachPosition, EachPosition + EachBall.transform.right * 10);
            //向右射出隱形射線(初始值,很遠很遠的地方)
            RaycastHit2D[] hitsL = Physics2D.LinecastAll(EachPosition, EachPosition - EachBall.transform.right * 10);
            //向左射出隱形射線(初始值,很遠很遠的地方)
            RaycastHit2D[] hitsU = Physics2D.LinecastAll(EachPosition, EachPosition + EachBall.transform.up * 10);
            //向上射出隱形射線(初始值,很遠很遠的地方)
            RaycastHit2D[] hitsD = Physics2D.LinecastAll(EachPosition, EachPosition - EachBall.transform.up * 10);
            //向下射出隱形射線(初始值,很遠很遠的地方)
            for (int i = 0; i < hitsR.Length; i++)
            {
                if (hitsR[i].collider.GetComponent<SpriteRenderer>().sprite != nowSprite)
                {
                    break;
                }
                horCount++;
            }
            for (int j = 0; j < hitsL.Length; j++)
            {
                if (hitsL[j].collider.GetComponent<SpriteRenderer>().sprite != nowSprite)
                {
                    break;
                }
                horCount++;
            }
            for (int k = 0; k < hitsU.Length; k++)
            {
                if (hitsU[k].collider.GetComponent<SpriteRenderer>().sprite != nowSprite)
                {
                    break;
                }
                verCount++;
            }
            for (int l = 0; l < hitsD.Length; l++)
            {
                if (hitsD[l].collider.GetComponent<SpriteRenderer>().sprite != nowSprite)
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
                    if (hit.collider.GetComponent<SpriteRenderer>().sprite == nowSprite)
                    //如果碰到的圖案跟自己一樣
                    {
                        hit.collider.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0f);
                        //讓球消失
                    }
                    else
                    {
                        break;
                    }
                }
                foreach (RaycastHit2D hit in hitsL)
                {
                    if (hit.collider.GetComponent<SpriteRenderer>().sprite == nowSprite)
                    //如果碰到的圖案跟自己一樣
                    {
                        hit.collider.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0f);
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
                    if (hit.collider.GetComponent<SpriteRenderer>().sprite == nowSprite)
                    //如果碰到的圖案跟自己一樣
                    {
                        hit.collider.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0f);
                        //讓球消失
                    }
                    else
                    {
                        break;
                    }
                }
                foreach (RaycastHit2D hit in hitsD)
                {
                    if (hit.collider.GetComponent<SpriteRenderer>().sprite == nowSprite)
                    //如果碰到的圖案跟自己一樣
                    {
                        hit.collider.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0f);
                        //讓球消失
                    }
                    else
                    {
                        break;
                    }
                }
            }
        }
    }
    public void FallSystem()
    {
        int i = 0;
        // 計數用
        foreach (GameObject EachBall in BallNumber)
        {
            if(EachBall.GetComponent<SpriteRenderer>().color == new Color( 1, 1, 1, 0f))
                // 如果是被消掉的珠子
            {
                ChangeSprite(EachBall);
                EachBall.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 1f);
                EachPosition = EachBall.transform.position;
                for (int j = 0; j < 5; j++)
                {
                    if (EachPosition.y + 2.6f * j > 2.14f)
                    {
                        i = j + 1;
                        EachBall.transform.position = new Vector2(EachPosition.x , EachPosition.y + 2.6f * i) ;
                    }
                }
            }
        }
        i = 0;
        foreach (GameObject EachBall in BallNumber)
        {
            RaycastHit2D[] FallD = Physics2D.LinecastAll(EachBall.transform.position, EachBall.transform.position - EachBall.transform.up * 20);
            if (FallD.Length == 1)
            {
                no[i] = -8.25f;
            }
            else if (FallD.Length == 2)
            {
                no[i] = -5.65f;
            }
            else if (FallD.Length == 3)
            {
                no[i] = -3.05f;
            }
            else if (FallD.Length == 4)
            {
                no[i] = -0.45f;
            }
            else if (FallD.Length == 5)
            {
                no[i] = 2.15f;
            }
            i++;
        }
        i = 0;
        foreach (GameObject EachBall in BallNumber)
        {
            EachBall.transform.position = new Vector2(EachBall.transform.position.x, no[i]);
            i++;
        }
    }
    void ChangeSprite(GameObject ThisBall)
    {
        int type = Random.Range(0, 6);
        // 設定隨機變數
        switch (type)
        {
            default:
                ThisBall.GetComponent<SpriteRenderer>().sprite = BallsType[0];
                break;
            case 1:
                ThisBall.GetComponent<SpriteRenderer>().sprite = BallsType[1];
                break;
            case 2:
                ThisBall.GetComponent<SpriteRenderer>().sprite = BallsType[2];
                break;
            case 3:
                ThisBall.GetComponent<SpriteRenderer>().sprite = BallsType[3];
                break;
            case 4:
                ThisBall.GetComponent<SpriteRenderer>().sprite = BallsType[4];
                break;
            case 5:
                ThisBall.GetComponent<SpriteRenderer>().sprite = BallsType[5];
                break;
        }
    }
}
