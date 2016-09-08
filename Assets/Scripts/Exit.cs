using UnityEngine;
using System.Collections;
//using UnityEngine.SceneManagement;

public class Exit : MonoBehaviour {
    public Transform tr;
    public LayerMask player;
    public string sc;
    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        //if (Physics2D.OverlapCircle(tr.position, 0.2f, player))
            //SceneManager.LoadScene(sc);
    }
}
