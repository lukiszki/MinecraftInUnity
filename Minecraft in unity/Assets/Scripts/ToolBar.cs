using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToolBar : MonoBehaviour
{
    private PlayerControls Controls;
    
    World world;

    [SerializeField]
    PlayerController player;

    [SerializeField]
    RectTransform Highlight;

    [SerializeField]
    ItemSlot[] itemSlots;

    int slotIndex = 0;

    private void Awake()
    {
        Controls = new PlayerControls();
        world = GameObject.Find("World").GetComponent<World>();
        Controls.Gameplay.Enable();

    }
    private void Start()
    {

        foreach(ItemSlot slot in itemSlots)
        {
            slot.icon.sprite = World.blockTypes[slot.itemType].icon;
            slot.icon.gameObject.SetActive(true);
        }
                Controls.Gameplay.Scroll.performed +=
                                    ctx => scroll2 = ctx.ReadValue<Vector2>();
    }

    Vector2 scroll2 = new Vector2(0,0);
    float scroll;
    int i = 0;
    private void Update()
    {
        scroll = scroll2.y / 120f;
        if(scroll!=0)
        {
            if (scroll > 0)
                slotIndex--;
            else
                slotIndex++;
            if (slotIndex > itemSlots.Length - 1)
                slotIndex = 0;
            if (slotIndex < 0)
                slotIndex = itemSlots.Length - 1 ;
            Highlight.position = itemSlots[slotIndex].icon.transform.position;
            player.selectedBlockType = itemSlots[slotIndex].itemType;
        }
        scroll = 0;
        scroll2.y = 0;
    }
    private void OnEnable()
    {
        Controls.Gameplay.Enable();
    }
    private void OnDisable()
    {
        Controls.Gameplay.Disable();
    }


}
[System.Serializable]
public class ItemSlot
{
    public BlockType.Type itemType;
    public Image icon;
}
