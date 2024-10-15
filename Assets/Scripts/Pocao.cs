using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Pocao", menuName = "Novo Item/ Poção")]
public class Pocao : ScriptableObject
{
    public string nome;
    public string descricao;
    public Sprite sprite;
    public bool tipoCura;
    public bool tipoMagia;
    public bool tipoDefesa; 
    public bool tipoPoder;
    public int tamanho;

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

    public string TipoPocao()
    {
        if (tipoCura)
        {
            return "Cura";
        }
        else if (tipoMagia)
        {
            return "Magia";
        }
        else if (tipoDefesa)
        {
            return "Defesa";
        }
        else if (tipoPoder)
        {
            return "Poder";
        }
        else
        {
            return "Não Definido";
        }
    }

    public int Tamanho()
    {
        return tamanho;
    }
}
