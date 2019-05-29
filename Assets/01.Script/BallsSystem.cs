using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class BallsSystem : MonoBehaviour
{
    public List<Sprite> BallsType;
    // 宣告不同種珠子Sprite的list
    private List<Transform> BallNumber = new List<Transform>(30);
    // 宣告珠子Transform的list
    private int count = 0;
    // 用來計算第幾個珠子
    private Ball ball;
    void Start()
    {
        for(int i=0; i < 6; i++)
        {
            for(int j = 0; j < 5; j++)
            {
                CreateNewBall(i,j);
                ChangeSprite(BallNumber[count].gameObject);
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
        BallNumber.Add(newBall.transform);
    }

    public void AllCheckLink()
    {
       
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
