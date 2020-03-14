
using UnityEngine;
using UnityEngine.SceneManagement;
public class Gamemanager : MonoBehaviour
{
  public void Completelevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
