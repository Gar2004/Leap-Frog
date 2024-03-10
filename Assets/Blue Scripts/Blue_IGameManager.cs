using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface Blue_IGameManager
{
    Blue_ManagerStatus status { get; }
    void Startup();
}
