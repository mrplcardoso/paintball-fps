using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShortRangeMove : MonoBehaviour
{
    EnemyMove move;
    [SerializeField] float minDistance;
    public bool inRange => (transform.position - move.target).magnitude <= minDistance;

    private void Awake()
    {
        move = GetComponent<EnemyMove>();
    }

    private void OnEnable()
    {
        StartCoroutine(AttackCycle());
    }

    IEnumerator AttackCycle()
    {
        while (true)
        {
            move.SetDestination(move.target);

            yield return new WaitWhile(() => !inRange);

            move.Stop();

            //TODO
            //Attack

            //yield recovery
            yield return new WaitForSeconds(5f);
        }
    }
}
