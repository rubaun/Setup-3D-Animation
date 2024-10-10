using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bau : MonoBehaviour
{
    [SerializeField] GameObject particulas;
    [SerializeField] private bool ehMagico;
    [SerializeField] private int numeroChave;
    [SerializeField] private List<GameObject> itens = new List<GameObject>();
    [SerializeField] private int ouro;
    private bool pegouOuro = false;

    void Start()
    {
        if (ehMagico)
        {
            particulas.SetActive(true);
            ouro = Random.Range(100, 500);
        }
        else 
        {
            particulas.SetActive(false);
            ouro = Random.Range(0, 100);
        }
    }

    private void DesativarParticulas()
    {
        particulas.GetComponent<ParticleSystem>().Stop();
    }

    public int PegarOuro()
    {
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
        ouro = 0;
    }

    public int PegarNumeroFechadura()
    {
        return numeroChave;
    }

    public List<GameObject> AcessarConteudoBau()
    { 
        return itens; 
    }

    public void RemoverConteudoBau()
    { 
        itens.Clear(); 
    }
}
