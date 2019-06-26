using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallsSystem : MonoBehaviour
{
    [SerializeField]
    private List<Sprite> BallsType = new List<Sprite>();
    [SerializeField]
    private List<GameObject> AllBall = new List<GameObject>();
    private int removeCountH, removeCountV;
    private int i, j;
    private bool checkLink;
    void Start()
    {
        for(i = 0; i < 5; i++)
        {
            for(j = 0; j < 6; j++)
            {
                CreateNewBall(j,i);
            }
        }
        foreach(GameObject ball in AllBall)
        {
            ChangeSprite(ball);
        }
    }
    private float NewBallPositionX(int x)
    {
        return -5.9f + 2.35f * x;
    }
    private float NewBallPositionY(int y)
    {
        return 2.15f - 2.6f * y;
    }
    private void CreateNewBall(int x,int y)
    {
        GameObject newBall = Instantiate(Resources.Load<GameObject>("Ball"));
        newBall.transform.position = new Vector2(NewBallPositionX(x), NewBallPositionY(y));
        AllBall.Add(newBall);
    }
    private void ChangeSprite(GameObject ThisBall)
    {
        int type = Random.Range(0, 6);
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
    private void GroupBall()
    {
        checkLink = false;
        for (i = 0; i < AllBall.Count; i++ )
        {
            removeCountH = 1;
            removeCountV = 1;
            // 上
            j = i - 6;
            while (j >= 0 && AllBall[j].GetComponent<SpriteRenderer>().sprite == AllBall[i].GetComponent<SpriteRenderer>().sprite)
            {
                removeCountV++;
                j =  j - 6;
            }
            // 右
            j = i + 1;
            while (j % 6 != 0 && AllBall[j].GetComponent<SpriteRenderer>().sprite == AllBall[i].GetComponent<SpriteRenderer>().sprite)
            {
                removeCountH++;
                j++;
            }
            // 下
            j = i + 6;
            while (j <= 29 && AllBall[j].GetComponent<SpriteRenderer>().sprite == AllBall[i].GetComponent<SpriteRenderer>().sprite)
            {
                removeCountV++;
                j = j + 6;
            }
            // 左
            j = i - 1;
            while (i % 6 != 0 && AllBall[j].GetComponent<SpriteRenderer>().sprite == AllBall[i].GetComponent<SpriteRenderer>().sprite)
            {
                removeCountH++;
                if (j % 6 == 0)
                {
                    break;
                }
                j--;
            }
            if (removeCountH >= 3 || removeCountV >= 3)
            {
                AllBall[i].GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0.5f);
                checkLink = true;
            }
        }
        if (checkLink)
        {
            removeBall();
        }
    }
    private void removeBall()
    {
        foreach(GameObject ball in AllBall)
        {
            if(ball.GetComponent<SpriteRenderer>().color == new Color(1, 1, 1, 0.5f))
            {
                ball.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 1f);
                ball.GetComponent<SpriteRenderer>().sprite = null;
            }
        }
        FallSystem();
    }
    private void FallSystem()
    {
        for(j = 0; j < 4; j++)
        {
            for (i = AllBall.Count - 1; i >= 6; i--)
            {
                if (AllBall[i].GetComponent<SpriteRenderer>().sprite == null)
                {
                    AllBall[i].GetComponent<SpriteRenderer>().sprite = AllBall[i - 6].GetComponent<SpriteRenderer>().sprite;
                    AllBall[i - 6].GetComponent<SpriteRenderer>().sprite = null;
                }
            }
        }
        ReCreate();
    }
    private void ReCreate()
    {
        foreach(GameObject ball in AllBall)
        {
            if(ball.GetComponent<SpriteRenderer>().sprite == null)
            {
                ChangeSprite(ball);
            }
        }
        GroupBall();
    }
}
