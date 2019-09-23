using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenShake : MonoBehaviour
{
    [SerializeField]
    AnimationCurve verticalShake;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //if (Input.GetKeyDown(KeyCode.Space))
        //{
        //    StartCoroutine(Shake());
        //}
    }

    IEnumerator Shake()
    {
        float counter = 0;

        while (counter < 1)
        {
            Vector3 pos = transform.position;
            pos.y += verticalShake.Evaluate(2 * counter * Time.deltaTime);
            transform.position = pos;
            counter += .1f;
        }
        yield return null;
    }
}
