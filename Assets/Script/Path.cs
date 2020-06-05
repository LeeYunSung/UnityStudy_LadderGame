using System.Collections;
using System.Collections.Generic;
using UnityEngine;

abstract public class Path : MonoBehaviour{
    abstract public Vector2 GetPosition(Path path);
    abstract public Path GetParent(Path path);
}
