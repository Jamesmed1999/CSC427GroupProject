using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Collectable : Singleton<Collectable>
{
    [SerializeField] public static int collectCount = 0;
}
