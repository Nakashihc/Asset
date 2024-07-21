using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HewanJalan : MonoBehaviour
{
    [Header("Kecepatan Hewan")]
    public float speed;

    [Header("Rentang Kecepatan")]
    public float minSpeed = 1f;
    public float maxSpeed = 3f;

    private Transform cumalewat;

    void Start()
    {
        // Atur kecepatan hewan secara acak dalam rentang yang ditentukan
        speed = Random.Range(minSpeed, maxSpeed);
    }

    public void SetCumaLewat(Transform cumaLewatPoint)
    {
        cumalewat = cumaLewatPoint;
    }

    public void SetSpeed(float newSpeed)
    {
        speed = newSpeed;
    }

    void Update()
    {
        if (cumalewat != null)
        {
            MoveTo(cumalewat.position);
            if ((cumalewat.position - transform.position).sqrMagnitude < 0.04f) // 0.2f^2 = 0.04f
            {
                Destroy(gameObject);
            }
        }
    }

    void MoveTo(Vector2 destination)
    {
        transform.position = Vector2.MoveTowards(transform.position, destination, speed * Time.deltaTime);
    }
}
