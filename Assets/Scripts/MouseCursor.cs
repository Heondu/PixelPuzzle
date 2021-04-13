using UnityEngine;
using UnityEngine.UI;

public class MouseCursor : MonoBehaviour
{
    [SerializeField]
    private Sprite cursorNormal;
    [SerializeField]
    private Sprite cursorClick;
    [SerializeField]
    private Sprite cursorGrab;
    private Image image;

    private void Awake()
    {
        if (FindObjectsOfType<MouseCursor>().Length != 1) Destroy(transform.parent.gameObject);
        DontDestroyOnLoad(transform.parent.gameObject);
        image = GetComponent<Image>();
        Cursor.visible = false;
    }

    private void Update()
    {
        transform.position = Input.mousePosition;

        if (Input.GetMouseButtonDown(0)) image.sprite = cursorClick;
        if (Input.GetMouseButtonUp(0)) image.sprite = cursorNormal;
    }

    public void SetImage(bool isGrab)
    {
        if (isGrab) image.sprite = cursorGrab;
        else image.sprite = cursorNormal;
    }
}
