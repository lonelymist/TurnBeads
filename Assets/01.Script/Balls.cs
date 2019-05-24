using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Balls : MonoBehaviour
{
    public List<Sprite> BallsType;
    // 宣告不同種珠子Sprite的list

    void Start()
    {
        int j = Random.Range(0, 6);
        // 設定隨機變數
        
        switch (j)
        {
            default:
                GetComponent<SpriteRenderer>().sprite = BallsType[0];
                tag = "Fire";
                // 改變珠子的sprite tag

                break;
            case 1:
                GetComponent<SpriteRenderer>().sprite = BallsType[1];
                tag = "Water";
                break;
            case 2:
                GetComponent<SpriteRenderer>().sprite = BallsType[2];
                tag = "Wood";
                break;
            case 3:
                GetComponent<SpriteRenderer>().sprite = BallsType[3];
                tag = "Light";
                break;
            case 4:
                GetComponent<SpriteRenderer>().sprite = BallsType[4];
                tag = "Dark";
                break;
            case 5:
                GetComponent<SpriteRenderer>().sprite = BallsType[5];
                tag = "Heart";
                break;
        }
    }
}
