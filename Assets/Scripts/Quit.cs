using UnityEngine;

public class Quit : MonoBehaviour
{
    [SerializeField]
    private GameObject quitPopup;

    private void Awake()
    {
        if (FindObjectsOfType<Quit>().Length != 1) Destroy(gameObject);
        DontDestroyOnLoad(gameObject);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            quitPopup.SetActive(!quitPopup.activeSelf);
        }
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
