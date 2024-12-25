using UnityEngine;

public class PopupExample : MonoBehaviour
{
    [SerializeField] private Popup popup;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            popup.gameObject.SetActive(true);
            popup.Show();
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            popup.Hide();
        }
    }
}