
using UnityEngine;
using UnityEngine.SceneManagement;

public class Endgame : MonoBehaviour
{

    public Gamemanager gamemanager;
    public int nextlevel;
 void Start()
    {
        nextlevel = SceneManager.GetActiveScene().buildIndex + 1;
    }
    void OnTriggerEnter()
    {
        SceneManager.LoadScene(nextlevel);


        if(nextlevel > PlayerPrefs.GetInt("levelcomplate"))
            {
            PlayerPrefs.SetInt("levelcomplate", nextlevel);
        }
    
    }
}
