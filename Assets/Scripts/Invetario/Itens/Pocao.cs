using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Pocao", menuName = "Novo Item/ Poção")]
public class Pocao : Item
{
    
    public TipoPocao tipo;
    public enum TipoPocao
    {
        Cura,
        Magia,
        Defesa,
        Poder
    }
    
    public int tamanho;

    public override string Nome()
    {
        return nome;
    }

    public override string Descricao()
    {
        return descricao;
    }

    public override Sprite Sprite()
    {
        return sprite;
    }

    public string TipoDePocao()
    {
        return tipo.ToString();
    }

    public int Tamanho()
    {
        return tamanho;
    }
}
