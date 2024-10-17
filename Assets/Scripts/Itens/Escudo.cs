using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Escudo", menuName = "Novo Item/ Escudo")]
public class Escudo : Item
{
    public string nome;
    public string descricao;
    public Sprite sprite;
    public bool ehMagica;
    public int defesa;

    public string Nome()
    {
        return nome;
    }

    public string Descricao()
    {
        return descricao;
    }

    public Sprite Sprite()
    {
        return sprite;
    }

    public bool EhMagico()
    {
        return ehMagica;
    }

    public int Defesa()
    {
        return defesa;
    }
}
