using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimaPlayer : MonoBehaviour
{
    [SerializeField] private Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PegarAnima()
    {
        animator.SetTrigger("Pegando");
    }

    public void AndarFrenteAnima()
    {
        animator.SetBool("Andar", true);
        animator.SetBool("AndarPraTras", false);
    }

    public void AndarTrasAnima()
    {
        animator.SetBool("AndarPraTras", true);
        animator.SetBool("Andar", false);
    }

    public void AndarAnima()
    {
        animator.SetBool("Andar", true);
    }

    public void PararAnima()
    {
        animator.SetBool("Andar", false);
        animator.SetBool("AndarPraTras", false);
    }

    public void PularAnima()
    {
        animator.SetTrigger("Pular");
        animator.SetBool("EstaNoChao", false);
    }

    public void NoChao()
    {
        animator.SetBool("EstaNoChao", true);
    }

    public void AtacarAnima()
    {
        animator.SetTrigger("Ataque");
    }

    public void CorrerAnima()
    {
        animator.SetBool("Correndo", true);
    }

    public void PararCorrerAnima()
    {
        animator.SetBool("Correndo", false);
    }

    public void MorrerAnima()
    {
        animator.SetTrigger("EstaVivo");
    }
}
