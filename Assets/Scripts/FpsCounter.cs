using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FpsCounter : MonoBehaviour
{

    [SerializeField] private float _hudRefreshRate = 1f;

    private float _timer;
    private int fps;

    private void Update()
    {
        if (Time.unscaledTime > _timer)
        {
            fps = (int) (1f / Time.unscaledDeltaTime);
            //_fpsText.text = "FPS: " + fps;
            _timer = Time.unscaledTime + _hudRefreshRate;
        }
    }


    void OnGUI()
    {
        GUI.TextArea(new Rect(10, 10, 50, 50), fps.ToString());
    }
}
