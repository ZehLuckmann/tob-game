using UnityEngine;
using System.Collections;

public class EnemyController : MonoBehaviour {

    public float velocidade;
    public bool direcao;
    public float duracaoDirecao;
    public Transform groundCheck;
    public LayerMask whatIsEnemy;

    private float tempoNaDirecao;
    public Animator animator;

    // Use this for initialization
    void Start () {
    }
	
	// Update is called once per frame
	void Update () {

        if (Physics2D.OverlapCircle(groundCheck.position, 0.2f, whatIsEnemy))
            Destroy(gameObject, .5f);
        if (direcao)
            transform.eulerAngles = new Vector2(0, 0);
        else
            transform.eulerAngles = new Vector2(0, 180);
        
        animator.SetFloat("velocidade", Mathf.Abs(velocidade));
        transform.Translate(Vector2.right * velocidade * Time.deltaTime);

        tempoNaDirecao += Time.deltaTime;
        if (tempoNaDirecao >= duracaoDirecao){
            tempoNaDirecao = 0;
            direcao = !direcao;
        }
    }
}
