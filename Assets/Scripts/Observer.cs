using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Observer : MonoBehaviour
{
    public Transform player;
    public GameEnding gameEnding;
    bool m_IsPlayerInRange;
    public int life = 3;

    void OnTriggerEnter(Collider other)
    {
        if (other.transform == player)
        {
            m_IsPlayerInRange = true;
        }

    }

    void OnTriggerExit(Collider other)
    {
        if (other.transform == player)
        {
            m_IsPlayerInRange = false;
        }

    }
    void FixedUpdate()
    {
        if (m_IsPlayerInRange)
        {
            Vector3 direction = player.position - transform.position + Vector3.up;
            Ray ray = new Ray(transform.position, direction);
            RaycastHit raycastHit;
            if (life == 0)
            {
                if (Physics.Raycast(ray, out raycastHit))
                {

                    if (raycastHit.collider.transform == player)
                    {
                        gameEnding.CaughtPlayer();
                    }
                }
            }
            life--;
        }
    }
}
