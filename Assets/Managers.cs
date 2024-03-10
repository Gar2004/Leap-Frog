using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using UnityEngine;

[RequireComponent(typeof(PlayerManager))]
[RequireComponent(typeof(InventoryManager))]
[RequireComponent(typeof(PinkTrigger))]
public class Managers : MonoBehaviour
{
    public static PlayerManager Player { get; private set; }
    public static InventoryManager Inventory { get; private set; }
    public static PinkTrigger PinkScore { get; private set; }

    public static BlueTrigger BlueScore { get; private set; }

    private List<IGameManager> startSequence;

    void Awake()
    {
        Player = GetComponent<PlayerManager>();
        Inventory = GetComponent<InventoryManager>();
        PinkScore = GetComponent<PinkTrigger>();
        BlueScore = GetComponent<BlueTrigger>();

        startSequence = new List<IGameManager>();
        startSequence.Add(Player);
        startSequence.Add(Inventory);
        startSequence.Add(PinkScore);
        startSequence.Add(BlueScore);

        StartCoroutine(StartupManagers());
    }

    private IEnumerator StartupManagers()
    {
        foreach (IGameManager manager in startSequence)
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

            foreach (IGameManager manager in startSequence)
            {
                if (manager.status == ManagerStatus.Started)
                {
                    numReady++;
                }
            }

            if (numReady > lastReady)
            {
                Debug.Log($"Progress: {numReady}/{numModules}");
                yield return null;
            }

            Debug.Log("All managers started up");
        }
    }
}
