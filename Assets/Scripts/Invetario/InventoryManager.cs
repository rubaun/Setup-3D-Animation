using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine.UI;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager instance;

    public List<Item> Itens = new List<Item>();

    public Transform itemContent;
    public GameObject inventoryItem;

    public InventoryItemController[] inventoryItens;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    public void AddItem(Item item)
    {
        Itens.Add(item);
    }

    public void RemoveItem(Item item)
    {
        Itens.Remove(item);
    }

    public void RemoverItem(GameObject item)
    {
        Destroy(item);
    }

    public void ListItens()
    {
        foreach (Transform item in itemContent)
        {
            Destroy(item.gameObject);
        }

        foreach (var item in Itens)
        {
            GameObject obj = Instantiate(inventoryItem, itemContent);
            var itemName = obj.transform.Find("NomeItem").GetComponent<TextMeshProUGUI>();
            var itemIcon = obj.transform.Find("Icone").GetComponent<Image>();
            var itemExcluir = obj.transform.Find("RemoverItem").GetComponent<Button>();

            itemName.text = item.nome;
            itemIcon.sprite = item.sprite;
            itemExcluir.onClick.AddListener(() => RemoverItem(obj));
        }

        DefinirItensInventario();
    }

    public void DefinirItensInventario()
    {
        inventoryItens = itemContent.GetComponentsInChildren<InventoryItemController>();

        for (int i = 0; i < Itens.Count; i++)
        {
            inventoryItens[i].AddItem(Itens[i]);
        }
    }
}