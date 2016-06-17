using UnityEngine;
using System.Collections;

public class Troll : MonoBehaviour {
    public GameObject blood;


    public void Go()
    {
        GetComponent<SpriteRenderer>().enabled = false;
        GameObject b = Instantiate(blood);
        b.transform.SetParent(transform, false);
        b.transform.localPosition = Vector3.zero;
    }

    private void Destroy()
    {
        Destroy(gameObject);
    }
}
