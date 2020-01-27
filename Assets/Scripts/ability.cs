using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ability : MonoBehaviour
{
    public abstract IEnumerator Cast();
}
