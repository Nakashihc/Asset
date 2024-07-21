using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HanyaLewat : MonoBehaviour
{
    [Header("Kecepatan NPC")]
    public float speed;

    private Transform cumalewat;

    public void SetCumaLewat(Transform cumaLewatPoint)
    {
        cumalewat = cumaLewatPoint;
    }

    void Update()
    {
        if (cumalewat != null)
        {
            MoveTo(cumalewat.position);
            if (Vector2.Distance(transform.position, cumalewat.position) < 0.2f)
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