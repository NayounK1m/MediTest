
using UnityEngine;

class Pinch : MonoBehaviour
{
    public float ZoomMax;
    public float ZoomMin;
    public float Sensitivity = 0.0045f;

    public Transform chgObj;
    public Transform touchDummyA;
    public Transform touchDummyB;

    private void Update()
    {
        PinchZoom();
    }

    private void PinchPos()
    {
        float dist = Vector3.Distance(touchDummyB.position, touchDummyA.position) * Sensitivity;
        //Debug.Log(dist);
        if (dist < 1.5f)
        {
            var pos = Vector3.Lerp(touchDummyA.position, touchDummyB.position, 0.5f);
            chgObj.position = pos;
        }
    }
    private void PinchZoom()
    {
        float dist = Vector3.Distance(touchDummyB.position, touchDummyA.position);
        dist *= Sensitivity;
        dist = Mathf.Clamp(dist, ZoomMin, ZoomMax);
        //Debug.Log(dist);
        chgObj.localScale = new Vector3(dist, dist, dist);
    }

    private Vector3 currPosA;
    private Vector3 currPosB;
    private Vector3 prevPosA;
    private Vector3 prevPosB;

    private void PinchRotate()
    {
        currPosA = touchDummyA.position;
        currPosB = touchDummyB.position;

        float angle = Vector3.SignedAngle(currPosA - currPosB,
                                          prevPosA - prevPosB,
                                          chgObj.transform.forward);
        //Debug.Log(angle);
        chgObj.transform.RotateAround(chgObj.transform.position, -chgObj.transform.forward, angle);

        prevPosA = currPosA;
        prevPosB = currPosB;
    }
}
