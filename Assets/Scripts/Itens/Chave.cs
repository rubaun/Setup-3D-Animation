using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Chave", menuName = "Novo Item/ Chave")]
public class Chave : Item
{
    public string nome;
    public string descricao;
    public Sprite sprite;
    public int numeroChave;

    public string NomeDaChave()
    {
        return nome;
    }
    public string DescricaoDaChave()
    {
        return descricao;
    }
    public Sprite Sprite()
    {
        return sprite;
    }
    public int PegarNumeroChave()
    {
        return numeroChave;
    }
}
