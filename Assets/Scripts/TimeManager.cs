using System.Collections;
using UnityEngine;

public class TimeManager : MonoBehaviour
{
    // Start is called before the first frame update
    IEnumerator Start()
    {
        Time.timeScale = 0f;
        CameraFade fade = FindObjectOfType<CameraFade>();

        while (fade == null)
        {
            yield return new WaitForFixedUpdate();
            fade = FindObjectOfType<CameraFade>();
        }
        fade.gameObject.SetActive(false);
    }


    public void SetTimeTo1()
    {
        Time.timeScale = 1f;
    }
}
