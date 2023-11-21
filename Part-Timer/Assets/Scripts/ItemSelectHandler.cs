using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ItemSelectHandler : MonoBehaviour, IPointerExitHandler, IPointerEnterHandler {
    public Image image;

    void Awake() {
        image = GetComponent<Image>();
        image.color = new Color(image.color.r, image.color.g, image.color.b, 0f);
    }

    public void OnPointerEnter(PointerEventData eventData) {
        image.color = new Color(image.color.r, image.color.g, image.color.b, 255f);
    }

    public void OnPointerExit(PointerEventData eventData) {
        image.color = new Color(image.color.r, image.color.g, image.color.b, 0f);
    }
}
