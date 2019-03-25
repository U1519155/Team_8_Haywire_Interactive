using UnityEngine;

public class KeySpawn : MonoBehaviour
{
    public GameObject[] Spawning;

    // Start is called before the first frame update
    void Start()
    {
        GameObject go_Temp;
        go_Temp = Spawning[Random.Range(1, Spawning.Length)];
        go_Temp.SetActive(true);
    }
}