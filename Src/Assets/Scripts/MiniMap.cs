using System.Runtime.CompilerServices;
using UnityEngine;

public class MiniMap : MonoBehaviour
{
    public Transform player;
        void Start()
    {
       
    }


    // Update is called once per frame
    void Update()
    {
        Vector3 newPosition = player.position;
        newPosition.y = transform.position.y;
        transform.position = newPosition;

        transform.rotation = Quaternion.Euler(90f, player.eulerAngles.y, 0f);

    }
}
