using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : ScriptableObject
{
    public string nome;
    public string descricao;
    public Sprite sprite;
    public bool excluir;

    public virtual string Nome()
    {
        return nome;
    }

    public virtual string Descricao()
    {
        return descricao;
    }

    public virtual Sprite Sprite()
    {
        return sprite;
    }

}
