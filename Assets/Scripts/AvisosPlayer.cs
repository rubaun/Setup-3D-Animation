using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class AvisosPlayer : MonoBehaviour
{
    private TextMeshProUGUI avisos;
    private TextMeshProUGUI textoOuro;
    [SerializeField] private List<string> listaAvisos = new List<string>();

    // Start is called before the first frame update
    void Start()
    {
        avisos = GameObject.Find("Avisos").GetComponent<TextMeshProUGUI>();
        textoOuro = GameObject.FindGameObjectWithTag("Ouro").GetComponent<TextMeshProUGUI>();
    }

    public void InformaOuroPlayer(int ouro)
    {
        textoOuro.text = ouro.ToString();
    }

    public void ListarAvisos(string aviso)
    {
        listaAvisos.Add(aviso);
        StopAllCoroutines();
        StartCoroutine("MostrarAviso");

    }

    IEnumerator MostrarAviso()
    {
        if (listaAvisos.Count >= 5)
        {
            LimparAvisos();
            StopCoroutine(MostrarAviso());
        }
        else
        {
            foreach (string texto in listaAvisos)
            {
                avisos.text = texto;
                GameObject.Find("Avisos").GetComponent<Animator>().SetTrigger("Aviso");
                yield return new WaitForSeconds(2.5f);
                GameObject.Find("Avisos").GetComponent<Animator>().SetTrigger("Aviso");
                yield return new WaitForSeconds(0.5f);
            }
            Invoke("LimparAvisos", 0.5f);
        }
        
        //StopCoroutine("MostrarAviso");
    }

    private void LimparAvisos()
    {
        listaAvisos.Clear();
        avisos.text = "";
    }
}
