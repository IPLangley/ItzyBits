using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Inventory : MonoBehaviour
{
    // Start is called before the first frame update
    public List<Item> items = new List<Item>();

    int slotCount;
    int initialSlots;
    public List<GameObject> slots = new List<GameObject>();



    public Item item1;
    public Item item2;
    public Item item3;
    [SerializeField]
    int iSlot = 0;
    [SerializeField]
    int nextSlot = 0;


    Item currentItem;




    void Start()
    {
        slotCount = initialSlots;
        AddItem(item1);
        AddItem(item2);
        AddItem(item3);

        nextSlot = iSlot;
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void AddItem(Item item)
    {
        Item newItem = Instantiate(item);
        newItem.transform.rotation = Quaternion.identity;
        newItem.transform.SetParent(transform);
        newItem.transform.localPosition = Vector3.zero;
        items.Add(newItem);
        newItem.gameObject.SetActive(false);
    }

    public void RemoveItem(Item item)
    {
        if (items.Count != 0)
        {
            items.Remove(item);
            item.gameObject.SetActive(false);
        }
    }

}
