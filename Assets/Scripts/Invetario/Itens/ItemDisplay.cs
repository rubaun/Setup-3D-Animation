using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ItemDisplay : MonoBehaviour
{
    [SerializeField] private Arma arma;
    [SerializeField] private Escudo escudo;
    [SerializeField] private Pocao pocao;
    [SerializeField] private string nome;
    [SerializeField] private string descricao;
    [SerializeField] private Image sprite;
    [SerializeField] private bool ehMagico;
    [SerializeField] private TextMeshProUGUI textoDescricao;
    //Arma
    private int dano;
    private int danoAdicional;
    //Escudo
    private int defesa;
    //Poção
    private string tipo;
    private int tamanho;
    
    

    // Start is called before the first frame update
    void Start()
    {
        sprite = GetComponent<Image>();
        
        if (arma != null)
        {
            ItemArma();
        }
        else if(escudo != null)
        {
            ItemEscudo();
        }
        else if (pocao != null)
        {
            ItemPocao();
        }
    }

    private void ItemArma()
    {
        nome = arma.Nome();
        gameObject.name = nome;
        descricao = arma.Descricao();
        sprite.sprite = arma.Sprite();
        ehMagico = arma.EhMagico();
        dano = arma.Dano();
        danoAdicional = arma.DanoAdicional();
        textoDescricao.text = nome;
    }

    private void ItemEscudo()
    {
        nome = escudo.nome;
        gameObject.name = nome;
        descricao = escudo.descricao;
        sprite.sprite = escudo.Sprite();
        ehMagico = escudo.EhMagico();
        defesa = escudo.Defesa();
        textoDescricao.text = nome;
    }

    private void ItemPocao()
    {
        nome = pocao.nome;
        gameObject.name = nome;
        descricao = pocao.descricao;
        sprite.sprite = pocao.Sprite();
        tipo = pocao.TipoDePocao();
        tamanho = pocao.Tamanho();
        textoDescricao.text = nome;
    }

}
