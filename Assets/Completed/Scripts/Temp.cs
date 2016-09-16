using UnityEngine;

public class Temp : MonoBehaviour
{
    void Start()
    {
        unchecked
        {
            var foo = int.MaxValue;
            var bar = foo + 5;
            print(bar);
        }
    }
}