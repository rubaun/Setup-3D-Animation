using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Arma", menuName = "Novo Item/ Arma")]
public class Arma : ScriptableObject
{
    public string nome;
    public string descricao;
    public Sprite sprite;
    public bool ehMagica;
    public int dano;
    public int danoAdicional;

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

    public int Dano()
    {
        return dano;
    }

    public int DanoAdicional()
    {
        return danoAdicional;
    }
}

