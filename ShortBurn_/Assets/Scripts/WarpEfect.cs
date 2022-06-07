using Cinemachine;
using Unity.Mathematics;
using UnityEngine;

public class WarpEfect : MonoBehaviour
{
    [SerializeField] private CinemachineVirtualCamera CVCamera;
    [SerializeField] private AnimationCurve Curve;
    [SerializeField] private float speed = 1;
    public bool DoWarp = false; 
    
    private float _current;
    private void Start()
    {
        CVCamera = FindObjectOfType<CinemachineVirtualCamera>();
        if (CVCamera == null)
        {
            Debug.LogError(this.name +" can not find CinemachineVirtualCamera");
        }
    }
    private void Update()
    {
        if (DoWarp)
        {
            WarpEffect();
        }
    }

    private void WarpEffect()
    {
        if (_current >= 1)
        {
            DoWarp = false;
            _current = 0;
        }
        
        _current = Mathf.MoveTowards(_current, 1, speed * Time.deltaTime);
        CVCamera.m_Lens.FieldOfView = math.lerp(60f, 0f,Curve.Evaluate(_current));
    }
}
