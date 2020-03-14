
using UnityEngine;

public class playerfollow : MonoBehaviour
{

    public GameObject player;
   public Vector3 offset;
    // Start is called before the first frame update
   

    // Update is called once per frame
    void Update()
    {
        transform.position = player.transform.position + offset;
    }
}
