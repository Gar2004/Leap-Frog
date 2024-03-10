using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//public class IGameManager : MonoBehaviour
//{
public interface IGameManager
{
    ManagerStatus status { get; }
    void Startup();
}
//}
