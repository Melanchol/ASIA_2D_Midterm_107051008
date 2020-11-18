
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    // 按鈕要與程式溝通的橋樑=方法(函式/功能)
    //語法:類型 方法名稱 () {}
    
    public void StartGame()
    {
        print("開始執行遊戲");
        SceneManager.LoadScene("關卡1");
    }

    // Update is called once per frame
    public void EndGame()
    {
        print("結束遊戲");
        Application.Quit();
    }
}
