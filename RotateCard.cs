using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateCard : MonoBehaviour
{
    [SerializeField] float rotateSpeed = 100f;
    [SerializeField] float rotationAngle = 180f;
    [SerializeField] float delayTime = 3;

    public RectTransform cardFront;
    public RectTransform cardBack;
    Quaternion initialRotation;
    Quaternion desiredRotation;
    void Start() 
    {
        initialRotation = transform.rotation;
        desiredRotation = initialRotation * Quaternion.AngleAxis(rotationAngle, Vector3.up);
        StartCoroutine(DelaySpin());
    }

    void Update()
    {

    }

    IEnumerator DelaySpin()
    {
        yield return new WaitForSeconds(delayTime);

        while (true)
        {
            Spin();
            yield return null;
        }
    }

    void Spin()
    {
        float dotProduct = Vector3.Dot(Camera.main.transform.forward, transform.forward);


        if (dotProduct < 0)
        {
        cardFront.gameObject.SetActive(false);
        cardBack.gameObject.SetActive(true);
         }
        else
        {
        cardFront.gameObject.SetActive(true);
        cardBack.gameObject.SetActive(false);
        }

        // Rotate
        float angle = Quaternion.Angle(transform.rotation, desiredRotation);
        float maxAngle = rotateSpeed * Time.deltaTime;
        transform.rotation = Quaternion.RotateTowards(transform.rotation, desiredRotation, maxAngle);
    }
}
