using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightMaskScaler : MonoBehaviour
{
	[SerializeField] private float scaleSpeed = 0.0f;
	private float scaleAmount = 0.0f;
	private Vector3 maskScale;


	private void Start()
	{
		maskScale = transform.localScale;
	}

	// Update is called once per frame
	void FixedUpdate()
	{
		scaleAmount += scaleSpeed;

	    maskScale = new Vector3(maskScale.x + scaleAmount, maskScale.y + scaleAmount, maskScale.z + scaleAmount);

	    transform.localScale = maskScale;
	}
}
