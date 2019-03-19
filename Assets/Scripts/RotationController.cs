using UnityEngine;

/// <summary>
/// Controls the orientation of content place by the <see cref="MakeAppearOnPlane"/>
/// component using a UI.Slider to affect the rotation about the Y axis.
/// </summary>
[RequireComponent(typeof(MakeAppearOnPlane))]
public class RotationController : MonoBehaviour
{
    MakeAppearOnPlane m_MakeAppearOnPlane;

    [SerializeField]
    [Tooltip("Current RotationalValue")]
    public float rotationalValue;

    float angle
    {
        get
        {
            return m_MakeAppearOnPlane.rotation.eulerAngles.y;
        }
        set
        {
            m_MakeAppearOnPlane.rotation = Quaternion.AngleAxis(value, Vector3.up);
        }
    }

    void Awake()
    {
        m_MakeAppearOnPlane = GetComponent<MakeAppearOnPlane>();
    }

    private void Start()
    {
        angle = rotationalValue;
    }

    private void Update()
    {
        angle = rotationalValue;
    }
}
