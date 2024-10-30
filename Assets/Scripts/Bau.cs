using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bau : MonoBehaviour
{
    [SerializeField] GameObject particulas;
    [SerializeField] private bool ehMagico;
    [SerializeField] private int numeroChave;
    [SerializeField] private List<GameObject> itensInstanciados = new List<GameObject>();
    [SerializeField] private int ouro;
    [SerializeField] private GameObject instancia;
    [SerializeField] private bool aberto;
    private bool pegouOuro = false;
    private Animator anima;

    void Start()
    {
        anima = GetComponent<Animator>();

        if(ehMagico)
        {
            particulas.SetActive(true);
            ouro = Random.Range(100, 500);
        }
        else 
        {
            particulas.SetActive(false);
            ouro = Random.Range(0, 100);
        }

        if(aberto)
        {
            anima.SetTrigger("Abrir");
        }
    }

    private void DesativarParticulas()
    {
        particulas.GetComponent<ParticleSystem>().Stop();
    }

    public int PegarOuro()
    {
        anima.SetTrigger("Abrir");

        if (!pegouOuro)
        {
            DesativarParticulas();
            StartCoroutine(ZerarBau());
            pegouOuro = true;
            return ouro;
        }

        return 0;
    }

    IEnumerator ZerarBau()
    {
        yield return new WaitForSeconds(2.5f);
        itensInstanciados.Clear();
        ouro = 0;
    }

    public int PegarNumeroFechadura()
    {
        return numeroChave;
    }

    public void AcessarConteudoBau()
    {
        foreach (var item in itensInstanciados)
        {
            Instantiate(item, instancia.transform.position, instancia.transform.rotation);
        }
    }

    public bool Aberto()
    {
        return aberto;
    }

}
