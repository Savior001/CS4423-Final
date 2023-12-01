using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ItemSelectHandler : MonoBehaviour, IPointerExitHandler, IPointerEnterHandler {
    public class VMItem {
        public VMItem(string n, string d, int t, int v, float p) {
            name = n;
            desc = d;
            type = t;
            value = v;
            price = p;
        }
        
        public string name;
        public string desc;
        public int type; //0 for HP : 1 for PP
        public int value;
        public float price;
    }

    [SerializeField] GameObject buttonObject;
    [SerializeField] Text text;
    [SerializeField] Text priceText;
    [SerializeField] Text vmUIPriceText;
    public GameInfoSO gameInfoSO;
    public Image image;
    public List<VMItem> vmItems = new List<VMItem>();
    public static ItemSelectHandler singleton;
    private Color color;
    private bool onHover = false;

    void Awake() {
        if(singleton == null) {
            singleton = this;
        }

        image = GetComponent<Image>();
        color = new Color(image.color.r, image.color.g, image.color.b, 0f);
        image.color = color;
        if (vmItems.Count == 0) {
            PopulateItems();
        }

        // for (int i = 1; i < vmItems.Count; i++) {
        //     Debug.Log(vmItems[i].name + vmItems[i].desc);
        // }
    }

    void FixedUpdate() {
        if (!onHover && gameInfoSO.selectedVMItem != int.Parse(buttonObject.name)) {
            image.color = new Color(color.r, color.g, color.b, 0f);
        }

        if (gameInfoSO.selectedVMItem == 0) {
            vmUIPriceText.transform.parent.GetComponent<Image>().enabled = false;
        } else {
            vmUIPriceText.transform.parent.GetComponent<Image>().enabled = true;
        }
    }

    public void OnClick() {
        image.color = new Color(1, 1, 1, 255f);
        gameInfoSO.selectedVMItem = int.Parse(buttonObject.name);
        UpdateText();
    }

    public void OnPointerEnter(PointerEventData eventData) {
        onHover = true;
        if (gameInfoSO.selectedVMItem != int.Parse(buttonObject.name)) {
            image.color = new Color(color.r, color.g, color.b, 255f);
        }
    }

    public void OnPointerExit(PointerEventData eventData) {
        onHover = false;
        if (gameInfoSO.selectedVMItem != int.Parse(buttonObject.name)) {
            image.color = new Color(color.r, color.g, color.b, 0f);
        }
    }

    public void OffClick() {
        image.color = new Color(color.r, color.g, color.b, 0f);
    }

    public void UpdateText() {
        if (gameInfoSO.selectedVMItem > 0) {
            VMItem item = vmItems[gameInfoSO.selectedVMItem - 1];
            text.text = item.name + item.desc;
            priceText.text = "$" + item.price.ToString("0.00");
            vmUIPriceText.text = priceText.text;
        } else {
            text.text = "Could really go for a snack...";
            priceText.text = "";
            vmUIPriceText.text = priceText.text;
        }
    }

    void PopulateItems() {
        Debug.Log("Populating items");
        vmItems.Add(new VMItem("Popsi Cola", " : Heals 20 HP, but is it worth it?", 0, 20, 2.25f));
        vmItems.Add(new VMItem("Classic Cola", " : Heals 30 HP, better. Ah!", 0, 30, 2.5f));
        vmItems.Add(new VMItem("P-Water", " : Heals 45 HP, electrolytes for taste.", 0, 45, 3.25f));
        vmItems.Add(new VMItem("Above Average Water", " : Heals 50 HP, I can feel me brain cells multiply.", 0, 50, 3.5f));
        vmItems.Add(new VMItem("Leis", " : Heals 10 HP.", 0, 10, 1.25f));
        vmItems.Add(new VMItem("Penguin Cakes", " : Heals 15 HP.", 0, 15, 1.5f));
    }
}
