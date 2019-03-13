using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestBed : MonoBehaviour
{
    public WebCamTexture marker;
    public string debugLine;
    public Color32[] videoFeed;

    // Start is called before the first frame update
    void Start()
    {
        videoFeed = new Color32[1080 * 1920];
        marker = new WebCamTexture(1080, 1920);
        debugLine += "Yay, I can see!\n";
        marker.deviceName = WebCamTexture.devices[0].name;
        GetComponent<UnityEngine.UI.RawImage>().texture = marker;
        marker.Play();
        StartCoroutine(SeeingRed());
    }

    private void OnGUI()
    {
#if UNITY_ANDROID
        GUI.TextArea(new Rect(0, 0, 200, 200), debugLine);
#else
        GUI.TextArea(new Rect(0, 0, 100, 100), debugLine);
#endif
    }

    IEnumerator SeeingRed()
    {
        while (true)
        {
            yield return new WaitForSeconds(10);
            marker.GetPixels32(videoFeed);
            foreach (Color32 i in videoFeed)
            {
                Vector3 difference = new Vector3(255 - i.r, 0 - i.g, 0 - i.b);
                if (difference.magnitude > 30)
                    debugLine += "k";
            }
            marker.Play();
        }
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void OnApplicationQuit()
    {
        StopCoroutine(SeeingRed());
    }
}