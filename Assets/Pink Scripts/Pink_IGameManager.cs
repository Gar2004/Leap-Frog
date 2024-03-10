using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface Pink_IGameManager
{
    Pink_ManagerStatus status { get; }
    void Startup();
}

