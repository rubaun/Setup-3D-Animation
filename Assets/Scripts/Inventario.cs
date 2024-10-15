using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventario : MonoBehaviour
{
    [SerializeField] private GameObject inventario;
    public void AtivarInventario()
    {
        inventario.SetActive(true);
    }

    public void DesativarInventario()
    {
        inventario.SetActive(false);
    }
}
