using UnityEngine;

public class UpDownControls : MonoBehaviour
{
    [SerializeField] private SimpleUpDown simpleUpDownAnimation;

    private bool isPaused = true;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (isPaused)
            {
                simpleUpDownAnimation.PlayLivitate();
                isPaused = false;
            }
            else
            {
                simpleUpDownAnimation.PauseLivitate();
                isPaused = true;
            }
        }

        if (Input.GetKeyDown(KeyCode.Escape)) simpleUpDownAnimation.StopLivitate();

        if (Input.GetKeyDown(KeyCode.R)) simpleUpDownAnimation.RestartLivivtate();
    }
}