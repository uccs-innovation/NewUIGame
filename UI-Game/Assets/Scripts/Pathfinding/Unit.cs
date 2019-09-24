using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{
    public Transform target;
    public float speed = 2.1f;
    Vector3[] path;
    int targetIndex;

    bool rotatorComplete = true;
    private void Start()
    {
        PathRequestManager.RequestPath(transform.position, target.position, OnPathFound);
    }

    public void OnPathFound(Vector3[] newPath, bool pathSuccessful)
    {
        if (pathSuccessful)
        {
            path = newPath;
            StopCoroutine("FollowPath");
            StartCoroutine("FollowPath");
        }
        else
        {
            StartCoroutine("Timer");
        }
    }

    IEnumerator FollowPath()
    {
        // This means that the target hasn't moved from his previous location since last path
        if (path.Length == 0)
        {
            StartCoroutine("Timer");
            yield break;
        }

        targetIndex = 0;

        Vector3 currentWaypoint = path[0];
        while(true)
        {
            if (Vector2.Distance(transform.position, currentWaypoint) < .1f)
            {
                targetIndex++;
                if (targetIndex >= path.Length)
                {
                    StartCoroutine("Timer");
                    yield break;
                }
                currentWaypoint = path[targetIndex];
            }
            transform.position = Vector3.MoveTowards(transform.position, currentWaypoint, speed * Time.deltaTime);
            if (rotatorComplete)
            {
                Vector3 direction = (currentWaypoint - transform.position);
                float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
                Quaternion tar = Quaternion.Euler(new Vector3(0, 0, angle));
                StartCoroutine(PacmanRotator(transform.rotation, tar));
            }
            yield return null;
        }
    }


    /// <summary>
    /// This Coroutine rotates the pacman 
    /// </summary>
    /// <returns></returns>
    IEnumerator PacmanRotator(Quaternion startRot, Quaternion target)
    {
        rotatorComplete = false;

        // Keep track of progress using deltatime
        float counter = 0f;

        // Loop until this enemy's rotation is less than .1 degree away from the target rotation
        while (Quaternion.Angle(transform.rotation, target) > .1f)
        {
            // Increment counter with the time elapsed since last frame
            counter += Time.deltaTime;

            // Smoothly rotate the enemy droid using lerp combined with animation curve
            transform.rotation = Quaternion.Slerp(startRot, target, Mathf.SmoothStep(0.0f, 1.0f,
                counter * 5));
            yield return null;
        }
        rotatorComplete = true;
    }
    IEnumerator Timer()
    {
        yield return new WaitForSeconds(.1f);
        PathRequestManager.RequestPath(transform.position, target.position, OnPathFound);
    }
}
