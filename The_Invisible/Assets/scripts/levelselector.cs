
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class levelselector : MonoBehaviour
{

    public Button[] levelbutton;
       void Start()
    {
       int levelcomplete = PlayerPrefs.GetInt("levelcomplate" , 1);
        for (int i = 0; i < levelbutton.Length; i++)
        {  
           if(i + 1 > levelcomplete)
            {
                levelbutton[i].interactable = false;
            }
        }
    }
    public void Loadgame(string levelname)
    {
        SceneManager.LoadScene(levelname);
    
    }

    
}
