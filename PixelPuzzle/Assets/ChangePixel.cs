using UnityEngine;

public class ChangePixel : MonoBehaviour
{
    private Color clickedColor;
    private SpriteRenderer clickedObject;
    private SpriteRenderer changedObject;
    private RaycastHit2D hit;
    private MouseCursor mouseCursor;
    [SerializeField]
    private GameObject select;

    private void Awake()
    {
        mouseCursor = FindObjectOfType<MouseCursor>();
    }

    private void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        hit = Physics2D.Raycast(ray.origin, ray.direction);
        if (hit != false && hit.collider.CompareTag("PixelData"))
        {
            select.SetActive(true);
            select.transform.position = hit.collider.transform.position;
            if (Input.GetMouseButtonDown(0))
            {
                mouseCursor.SetImage(true);
                clickedObject = hit.collider.GetComponent<SpriteRenderer>();
                changedObject = clickedObject;
                clickedColor = clickedObject.color;
            }
            if (Input.GetMouseButton(0))
            {
                changedObject.color = clickedObject.color;
                clickedObject.color = hit.collider.GetComponent<SpriteRenderer>().color;
                changedObject = hit.collider.GetComponent<SpriteRenderer>();
                changedObject.color = clickedColor;
            }
            if (Input.GetMouseButtonUp(0))
            {
                mouseCursor.SetImage(false);
            }
        }
        else select.SetActive(false);
    }
}
