using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseCursor : MonoBehaviour
{
    [SerializeField]
    private Sprite cursorNormal;
    [SerializeField]
    private Sprite cursorClick;
    [SerializeField]
    private Sprite cursorGrab;
    private SpriteRenderer spriteRenderer;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
        spriteRenderer = GetComponent<SpriteRenderer>();
        Cursor.visible = false;
    }

    private void Update()
    {
        transform.position = Vector2.one * Camera.main.ScreenToWorldPoint(Input.mousePosition);

        if (Input.GetMouseButtonDown(0)) spriteRenderer.sprite = cursorClick;
        if (Input.GetMouseButtonUp(0)) spriteRenderer.sprite = cursorNormal;
    }

    public void SetImage(bool isGrab)
    {
        if (isGrab) spriteRenderer.sprite = cursorGrab;
        else spriteRenderer.sprite = cursorNormal;
    }
}
