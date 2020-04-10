using System.Collections;
using System.Collections.Generic;
using UnityEngine;

abstract public class Path : MonoBehaviour
{
    abstract public Vector3 GetPosition(Path path);
}
