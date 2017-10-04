using UnityEngine;
using System.Collections;
using System;

public static class StaticHelper
{
    // =============================
    // HELPER FUNTIONS
    // =============================

    /// <summary>
    /// Creates de efect of a blink in a gameobject, activating and deactivating the object root, not the mesh renderer
    /// that will enable or disable the gameobject with his hierarchy
    /// </summary>
    /// <param name="obj"></param>
    /// <param name="maxBlinks"></param>
    /// <param name="initialWaitTime"></param>
    /// <param name="timeBetweenBlinks"></param>
    /// <returns></returns>
    public static IEnumerator BlinkObject(this GameObject obj, int maxBlinks = 2, float initialWaitTime = 1f, float timeBetweenBlinks = 0.25f)
    {
        GameObjectSetActive(obj, false);

        yield return new WaitForSeconds(initialWaitTime);

        int blinkCounter = 0;
        while (blinkCounter < maxBlinks)
        {
            blinkCounter++;
            GameObjectSetActive(obj, true);
            yield return new WaitForSeconds(timeBetweenBlinks);
            GameObjectSetActive(obj, false);
            yield return new WaitForSeconds(timeBetweenBlinks);
        }

        GameObjectSetActive(obj, true);
    }

    /// <summary>
    /// FollowPosition class, if target is null that means the main camera will be used as a target
    /// </summary>
    /// <param name="obj"></param>
    /// <param name="enabled"></param>
    /// <param name="target"></param>
    public static FollowPosition FollowPosition(this GameObject obj) //, bool enabled, Transform target = null)
    {
        bool objIsActive = obj.activeInHierarchy;
        if (!objIsActive)
        {
            obj.SetActive(!objIsActive);
        }

        FollowPosition followPosition = obj.GetComponent<FollowPosition>();
        if (!followPosition)
        {
            obj.AddComponent<FollowPosition>();
            followPosition = obj.GetComponent<FollowPosition>();
        }

        //followPosition.enabled = enabled;
        //followPosition.updateFollow = updateFollow;
        //followPosition.offset

        //if (target != null)
        //{
        //    followPosition.SetTarget(target);
        //}

        obj.SetActive(objIsActive);

        return followPosition;
    }

    /// <summary>
    /// FollowRotation class, if target is null that means the main camera will be used as a target
    /// </summary>
    /// <param name="obj"></param>
    /// <param name="enabled"></param>
    /// <param name="target"></param>
    public static void FollowRotation(this GameObject obj, bool enabled, Transform target = null)
    {
        FollowRotation followRotation = obj.GetComponent<FollowRotation>();
        if (!followRotation)
        {
            obj.AddComponent<FollowRotation>();
            followRotation = obj.GetComponent<FollowRotation>();
        }

        followRotation.enabled = enabled;

        if (target != null)
        {
            followRotation.SetTarget(target);
        }
    }

    private static void GameObjectSetActive(GameObject obj, bool isActive)
    {
        obj.SetActive(isActive);
    }
}
