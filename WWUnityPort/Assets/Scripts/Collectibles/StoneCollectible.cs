using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoneCollectible : BaseCollectible
{
    public bool hasRandom = false;

    int randomItem;
    public override void OnInteract()
    {
        if (!PI.IsFull())
        {
            if (hasRandom)
            {
                randomItem = Random.Range(0, item.Count);
                PI.Add(item[randomItem]);
            } else
            {
                PI.Add(item[0]);
            }

            gameObject.SetActive(false);

            Invoke("reset", ResetTime);
        }
        else if (PI.IsFull())
        {
            Debug.Log("Your inventory is full");
        }
    }

}
