using UnityEngine;

public class FPSRestrict : MonoBehaviour
{
    private void Awake()
    {
        Application.targetFrameRate = 60;
    }
}