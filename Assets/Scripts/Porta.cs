using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Porta : MonoBehaviour
{
    [SerializeField] private int fechadura;
    [SerializeField] private bool aberto;
    private Animator anima;

    // Start is called before the first frame update
    void Start()
    {
        anima = GetComponent<Animator>();   

        if(aberto)
        {
            anima.SetTrigger("Abrir");
        }
    }

    public int PegarNumeroFechadura()
    {
        return fechadura;
    }

    public void AbrirPorta()
    {
        anima.SetTrigger("Abrir");
    }

    public bool Aberto()
    {
        return aberto;
    }
}
