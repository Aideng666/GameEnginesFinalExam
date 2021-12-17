using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrosshairController : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mouseWorldPos.z = 0;

        transform.position = mouseWorldPos;

        if (Input.GetMouseButtonDown(0))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        FindObjectOfType<AudioManager>().Play("Shoot");

        Duck[] ducks = FindObjectsOfType<Duck>(); 

        foreach(Duck duck in ducks)
        {
            float distance = Vector3.Distance(transform.position, duck.transform.position);

            if (distance < 1)
            {
                duck.KillDuck();

                if (Score.Instance.GetScorePerDuck() < 1000)
                {
                    Score.Instance.SetScorePerDuck(Score.Instance.GetScorePerDuck() * 2);
                }
            }
            else
            {
                Score.Instance.SetScorePerDuck(Score.Instance.GetScorePerDuck() / 2);
            }
        }
    }
}
