﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallsSystem : MonoBehaviour
{
    public List<Sprite> BallsType;
    // 宣告不同種珠子Sprite的list

    public List<Transform> BallNumber;
    // 宣告珠子編號Transform的list

    void Start()
    {
        int Count = 0;
        for(int i=0; i < 6; i++)
        {
            for(int j = 0; j < 5; j++)
            {
                CreateNewBall(i,j);
                ChangeSprite(BallNumber[Count].gameObject);
                Count++;
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
        // 設定新磚塊，從Resource裡複製一個磚塊

        newBall.transform.position = new Vector2(NewBallPositionX(x), NewBallPositionY(y));
        // 設定它的座標為 剛剛設定好的

        BallNumber.Add(newBall.transform);
        // 然後把它加進Bricks陣列
    }
    void ChangeSprite(GameObject ThisBall)
    {
        int type = Random.Range(0, 6);
        // 設定隨機變數

        switch (type)
        {
            default:
                ThisBall.GetComponent<SpriteRenderer>().sprite = BallsType[0];
                ThisBall.tag = "Fire";
                // 改變珠子的sprite tag

                break;
            case 1:
                ThisBall.GetComponent<SpriteRenderer>().sprite = BallsType[1];
                ThisBall.tag = "Water";
                break;
            case 2:
                ThisBall.GetComponent<SpriteRenderer>().sprite = BallsType[2];
                ThisBall.tag = "Wood";
                break;
            case 3:
                ThisBall.GetComponent<SpriteRenderer>().sprite = BallsType[3];
                ThisBall.tag = "Light";
                break;
            case 4:
                ThisBall.GetComponent<SpriteRenderer>().sprite = BallsType[4];
                ThisBall.tag = "Dark";
                break;
            case 5:
                ThisBall.GetComponent<SpriteRenderer>().sprite = BallsType[5];
                ThisBall.tag = "Heart";
                break;
        }
    }
}
