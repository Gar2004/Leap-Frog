using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using UnityEngine;

[RequireComponent(typeof(Pink_PlayerManager))]
[RequireComponent(typeof(Pink_InventoryManager))]
//[RequireComponent(typeof(PinkTrigger))]
public class Pink_Managers : MonoBehaviour
{
    public static Pink_PlayerManager Pink_Player { get; private set; }
    public static Pink_InventoryManager Inventory { get; private set; }
    //public static PinkTrigger PinkScore { get; private set; }

    // public static BlueTrigger BlueScore { get; private set; }

    private List<Pink_IGameManager> startSequence;

    void Awake()
    {
        Pink_Player = GetComponent<Pink_PlayerManager>();
        Inventory = GetComponent<Pink_InventoryManager>();
        //PinkScore = GetComponent<PinkTrigger>();
        //BlueScore = GetComponent<BlueTrigger>();

        startSequence = new List<Pink_IGameManager>();
        startSequence.Add(Pink_Player);
        startSequence.Add(Inventory);
        //startSequence.Add(PinkScore);
        // startSequence.Add(BlueScore);

        StartCoroutine(StartupManagers());
    }

    private IEnumerator StartupManagers()
    {
        foreach (Pink_IGameManager manager in startSequence)
        {
            manager.Startup();
        }

        yield return null;

        int numModules = startSequence.Count;
        int numReady = 0;

        while (numReady < numModules)
        {
            int lastReady = numReady;
            numReady = 0;

            foreach (Pink_IGameManager manager in startSequence)
            {
                if (manager.status == Pink_ManagerStatus.Started)
                {
                    numReady++;
                }
            }

            if (numReady > lastReady)
            {
                Debug.Log($"Progress: {numReady}/{numModules}");
                yield return null;
            }

            Debug.Log("All Pink managers started up");
        }
    }
}

