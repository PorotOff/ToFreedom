using UnityEngine;

public class Dynamic2DCamera : MonoBehaviour
{
    private Dynamic2DCameraModel dynamic2DCameraModel;

    private Transform target;

    [SerializeField] private float smoothness;

    private void Awake()
    {
        target = FindAnyObjectByType<BirdWave>(FindObjectsInactive.Include).gameObject.transform;

        dynamic2DCameraModel = new CasualDynamic2DCameraModel(transform, target, smoothness);
    }

    private void Update()
    {
        dynamic2DCameraModel.MoveX();
    }
}