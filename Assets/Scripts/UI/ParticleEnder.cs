using UnityEngine;
using System.Collections;

public class ParticleEnder : MonoBehaviour {

	// Use this for initialization
	void Start () {
        StartCoroutine(End());
	}


    public IEnumerator End()
    {
        yield return new WaitForSeconds(10);
        Destroy(this.gameObject);
    }


}
