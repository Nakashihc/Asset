using UnityEngine;
using UnityEngine.UI;


public class Objectplacer : MonoBehaviour
{
    // The 2D object that will trigger the script
    public GameObject object2D;

    // The object prefabs to be placed
    public GameObject prefab1;
    public GameObject prefab2;
    public GameObject prefab3;    

    public void PlacePrefab1()
    {
        // Instantiate prefab 1 at the position of the 2D object
        Instantiate(prefab1, object2D.transform.position, Quaternion.identity);
    }

    public void PlacePrefab2()
    {
        // Instantiate prefab 2 at the position of the 2D object
        Instantiate(prefab2, object2D.transform.position, Quaternion.identity);
    }

    public void PlacePrefab3()
    {
        // Instantiate prefab 3 at the position of the 2D object
        Instantiate(prefab3, object2D.transform.position, Quaternion.identity);
    }
}