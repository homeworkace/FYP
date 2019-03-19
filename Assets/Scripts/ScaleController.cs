using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.ARFoundation;

/// <summary>
/// Sets the scale of the ARSessionOrigin according to the value of a UI.Slider.
/// </summary>
[RequireComponent(typeof(ARSessionOrigin))]
public class ScaleController : MonoBehaviour
{
    [SerializeField]
    [Tooltip("The current scale")]
    public float scaleValue;
    
    float scale
    {
        get
        {
            return m_SessionOrigin.transform.localScale.x;
        }
        set
        {
            m_SessionOrigin.transform.localScale = Vector3.one * value;
        }
    }

    void Awake()
    {
        m_SessionOrigin = GetComponent<ARSessionOrigin>();
    }

    private void Start()
    {
        scale = scaleValue;
    }

    private void Update()
    {
        scale = scaleValue;
    }

    ARSessionOrigin m_SessionOrigin;
}
