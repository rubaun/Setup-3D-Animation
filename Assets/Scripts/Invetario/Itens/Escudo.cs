using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Escudo", menuName = "Novo Item/ Escudo")]
public class Escudo : Item
{
    
    public bool ehMagica;
    public int defesa;

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

    public bool EhMagico()
    {
        return ehMagica;
    }

    public int Defesa()
    {
        return defesa;
    }
}
