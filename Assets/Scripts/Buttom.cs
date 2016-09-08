using UnityEngine;
using System.Collections;

public class Buttom : MonoBehaviour {

    
    public LayerMask player;
    Animator anim;
    Transform tr;
    public bool activate;
    public GameObject wall1;
    public GameObject wall2;
    //public GameObject wall1State;
    bool control;
	
    // Use this for initialization
	void Start () {
        anim = gameObject.GetComponent<Animator>();
        tr = gameObject.GetComponent<Transform>();
    }
	
	// Update is called once per frame
	void Update () {
        

        if (Physics2D.OverlapCircle(tr.position, 0.2f, player) && !control) {
            control = true;
            activate = !activate;
            anim.SetBool("pressed", activate);
        }
        else if (!Physics2D.OverlapCircle(tr.position, 0.2f, player) && control)
            control = false;

        if (wall1) { 
            wall1.GetComponent<SpriteRenderer>().enabled = !activate;
            wall1.GetComponent<BoxCollider2D>().enabled = !activate;
        }

        if (wall2)
        {
            wall2.GetComponent<SpriteRenderer>().enabled = activate;
            wall2.GetComponent<BoxCollider2D>().enabled = activate;
        }
    }
}
