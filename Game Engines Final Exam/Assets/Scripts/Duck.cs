using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Duck : MonoBehaviour
{
    [SerializeField] float speed = 1;

    float timeToDirectionChange = 1.5f;
    float changeDelay = 2;

    Vector3 moveDirection = Vector3.up;

    float timeAtInitialization;
    float timeSinceInitialization;

    // Update is called once per frame
    void Update()
    {
        timeSinceInitialization = Time.realtimeSinceStartup - timeAtInitialization;

        if (CanChangeDirection())
        {
            moveDirection = ChangeDirection();
        }

        transform.position += moveDirection * speed * Time.deltaTime;

        if (!GetComponent<Renderer>().isVisible)
        {
            KillDuck();
            FindObjectOfType<Lives>().LoseLife();
        }
    }

    public void KillDuck()
    {
        DuckPool.Instance.AddToPool(gameObject);

        Score.Instance.AddScore(Score.Instance.GetScorePerDuck());
    }

    bool CanChangeDirection()
    {
        if (timeToDirectionChange < timeSinceInitialization)
        {
            timeToDirectionChange = timeSinceInitialization + changeDelay;
            return true;
        }

        return false;
    }

    Vector3 ChangeDirection()
    {
        int directionOption = (int)Random.Range(0, 3.99f);
        Vector3 direction = Vector3.up;

        switch (directionOption)
        {
            case 0:
                direction = Vector3.up;
                break;

            case 1:
                direction = Vector3.down;
                break;

            case 2:
                direction = Vector3.left;
                break;

            case 3:
                direction = Vector3.right;
                break;
        }

        return direction;
    }

    public void ResetTime()
    {
        timeAtInitialization = Time.realtimeSinceStartup;
    }
}
