using UnityEngine;
using UnityEngine.UI;
public class CameraHeight : MonoBehaviour
{
    [SerializeReference] private Text text,platform;
    [SerializeReference] private CharacterController XROrigin;

    [SerializeReference] private float OculusHeight;
    [SerializeReference] private float FocusHeight;

    public void addHeight(float i) => XROrigin.center += new Vector3(0, i, 0);
    private void Update()
    {
        if(text!= null)
        text.text = XROrigin.center.y.ToString();
    }
    private void Start()
    {
        string platformInfo = SystemInfo.deviceModel.ToString().ToLower();
        if (platform != null) platform.text = platformInfo;

        if (platformInfo.Contains("oculus"))
        {
            XROrigin.center = new Vector3(0, OculusHeight, 0);
        }
        else if(platformInfo.Contains("focus")) {
            XROrigin.center = new Vector3(0, FocusHeight, 0);
        }
    }
}
