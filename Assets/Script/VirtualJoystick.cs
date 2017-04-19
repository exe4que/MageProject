using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections.Generic;
using UnityEngine;
using System;

public class VirtualJoystick : MonoBehaviour, IDragHandler, IPointerUpHandler, IPointerDownHandler {

    private RectTransform bgRectTransform;
    private Image joystickImg;

    public Vector3 inputDirection { set; get; }

    void Start() {
        bgRectTransform= GetComponent<RectTransform>();
        joystickImg = transform.GetChild(0).GetComponent<Image>();
        inputDirection = Vector3.zero;
    }

    public void OnDrag(PointerEventData eventData) {
        Vector2 pos = Vector2.zero;
        if (RectTransformUtility.ScreenPointToLocalPointInRectangle(bgRectTransform,
            eventData.position,
            eventData.pressEventCamera,
            out pos)) {

            pos.x = (pos.x / bgRectTransform.sizeDelta.x);
            pos.y = (pos.y / bgRectTransform.sizeDelta.y);

            float x = (bgRectTransform.pivot.x == 1) ? pos.x * 2 + 1 : pos.x * 2 - 1;
            float y = (bgRectTransform.pivot.y == 1) ? pos.y * 2 + 1 : pos.y * 2 - 1;

            inputDirection = new Vector3(x, y, 0);
            inputDirection = (inputDirection.magnitude > 1) ? inputDirection.normalized : inputDirection;

            joystickImg.rectTransform.anchoredPosition =
                new Vector3(inputDirection.x * (bgRectTransform.sizeDelta.x / 3),
                inputDirection.y * (bgRectTransform.sizeDelta.y / 3));
        }
    }

    public void OnPointerDown(PointerEventData eventData) {
        OnDrag(eventData);
    }

    public void OnPointerUp(PointerEventData eventData) {
        inputDirection = Vector3.zero;
        joystickImg.rectTransform.anchoredPosition = Vector3.zero;
    }
}
