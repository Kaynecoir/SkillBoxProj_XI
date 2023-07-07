using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ActiveObject : MonoBehaviour
{
    public Rigidbody rb;
    public bool isActeved;
    public Collider collider;
    public UAnimator animator;
    public Renderer renderer;
    public Material material;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

	private void OnTriggerStay(Collider other)
	{
		
	}


	public void ActivateObject()
	{
        if(!isActeved)
		{
            rb.isKinematic = false;
            renderer.material = material;
            isActeved = true;
		}
	}
}
