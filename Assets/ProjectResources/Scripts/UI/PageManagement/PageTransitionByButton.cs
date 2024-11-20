using UnityEngine.UI;

public class PageTransitionByButton : PageTransition
{
    private Button button;

    private void Awake()
    {
        button = GetComponent<Button>();
    }

    private void OnEnable()
    {
        button.onClick.AddListener(go);
    }
    private void OnDisable()
    {
        button.onClick.RemoveListener(go);
    }
}