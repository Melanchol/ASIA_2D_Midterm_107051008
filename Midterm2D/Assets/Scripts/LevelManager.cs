
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public void NextLevel1(string LvNum)
    {
        SceneManager.LoadScene(LvNum);
    }
    public void BackToMenu()
    {
        SceneManager.LoadScene("選單");
    }
    public void Quit()
    {
        Application.Quit();
            
    
        
    }
}
