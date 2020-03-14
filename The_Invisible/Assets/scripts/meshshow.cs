using UnityEngine.SceneManagement;
using UnityEngine;

public class meshshow : MonoBehaviour
{
    // Start is called before the first frame update
  
    void Start()
    {
       Invoke("hidmesh", 6f);
        
    }
  
    // Update is called once per frame
    void Update()
    {
        
    }
    void hidmesh()
    {
        GetComponent<MeshRenderer>().enabled = false;
    }
    void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.tag == "Player")
        {
            GetComponent<MeshRenderer>().enabled = true;
        }
    }
  void OnCollisionExit(Collision collision)
    {
        if (collision.collider.tag == "Player")
        {
            GetComponent<MeshRenderer>().enabled = false;
        }
    }
}
