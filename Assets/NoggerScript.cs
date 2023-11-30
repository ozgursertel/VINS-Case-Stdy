using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class NoggerScript : MonoBehaviour
{
    float doTween_y = -0.5f;
    float doTween_time = 0.5f;

    public float lastPositon_y;
    public float lastPosition_timer;
    // Start is called before the first frame update
    void Awake()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public IEnumerator doNoggerYMove()
    {
        transform.DOMoveY(doTween_y, doTween_time);
        yield return new WaitForSeconds(doTween_time);
        StartCoroutine(doNoggerLastPositionMove());

    }

    IEnumerator doNoggerLastPositionMove()
    {
        yield return new WaitForSeconds(0.1f);
        transform.DOMoveY(lastPositon_y,lastPosition_timer);
        yield return new WaitForSeconds(lastPosition_timer);
    }
}
