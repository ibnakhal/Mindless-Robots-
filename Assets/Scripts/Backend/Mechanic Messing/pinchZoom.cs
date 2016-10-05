using UnityEngine;
using System.Collections;

public class pinchZoom : MonoBehaviour
{
    public float pZoomSpeed = 0.5f;
    public float oZoomSpeed = 0.5f;
    Camera curcam;
    public void Start()
    {
        curcam = Camera.main;
    }
    void Update()
    {
        if (Input.touchCount == 2)
        {
            Touch touchZero = Input.GetTouch(0);
            Touch touchOne = Input.GetTouch(1);

            Vector2 touchZeroPrevPos = touchZero.position - touchZero.deltaPosition;
            Vector2 touchOnePrevPos = touchOne.position - touchOne.deltaPosition;

            float prevTouchDeltaMag = (touchZeroPrevPos - touchOnePrevPos).magnitude;
            float touchDeltaMag = (touchZero.position - touchOne.position).magnitude;

            float deltaMagDiff = prevTouchDeltaMag - touchDeltaMag;

            if(curcam.orthographic)
            {
                curcam.orthographicSize += deltaMagDiff * oZoomSpeed;
                curcam.orthographicSize = Mathf.Max(curcam.orthographicSize, .1f);
            }
            else
            {
                curcam.fieldOfView += deltaMagDiff * pZoomSpeed;
                curcam.fieldOfView = Mathf.Clamp(curcam.fieldOfView, .1f, 179.9f);
            }
        }
    }




}
