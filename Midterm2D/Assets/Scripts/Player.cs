using UnityEngine;
using UnityEngine.UI;//text的api

public class Player : MonoBehaviour
{
    //設定欄位用於計數 以及
    public Text textCount;
    public int score=0;
    //欄位名final 儲存物件過關介面
    public GameObject final;
    //碰撞偵測api
    //條件:
    //1.兩物件須都有碰撞器collider2D
    //2.兩物件其中一個有剛體 rigidbody2D
    //collision儲存碰到物件的資訊
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "傳送門")
        {
         //使final欄位物件的設定為true
            final.SetActive(true);
        }
        if (collision.tag =="chem")
        {
            //使"碰到的東西"其物件(gameobject)消失
            Destroy(collision.gameObject);
            score++;
            textCount.text = "Score :["+score + "]";
        }

    }
}
