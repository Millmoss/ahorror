using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstPersonCamera : MonoBehaviour
{
	public float xSensitivity = 130f;
	public float ySensitivity = 115f;
	public float xMin = -80F;
	public float xMax = 80F;
	public bool lockCursor = true;
	public GameObject player;			//player object
	public Camera fpcam;				//camera childed to player
	public GlobalInput playerInput;
	public GameObject neckJoint;
	public GameObject headJoint;
	public Animator anim;
	public float posMod;
	public GameObject camParent;

	private bool cursorLocked = true;
	//private float xDelta = 0;
	//private float yDelta = 0;
	private float xrDelay;
	private float yrDelay;
	private float xr;
	private float yr;

	void Start()
    {
		xrDelay = xr;
		yrDelay = yr;
		xr = player.transform.rotation.eulerAngles.x;
		yr = fpcam.transform.localRotation.eulerAngles.y;
		//Time.timeScale = 0.1f;
		Application.targetFrameRate = 300;
	}
	
    void LateUpdate()
    {
		float xDelta = playerInput.getXTiltLook();
		float yDelta = playerInput.getZTiltLook();

		xr -= yDelta * ySensitivity;
		yr += xDelta * xSensitivity;

		if (yr > 360)
		{
			yrDelay -= 360;
			yr -= 360;
		}
		else if (yr < -360)
		{
			yrDelay += 360;
			yr += 360;
		}

		if (xr > xMax)
			xr = xMax;
		else if (xr < xMin)
			xr = xMin;

		xrDelay = Mathf.Lerp(xrDelay, xr, 60 * Time.deltaTime);
		yrDelay = Mathf.Lerp(yrDelay, yr, 60 * Time.deltaTime);

		player.transform.rotation = Quaternion.Euler(0, yrDelay, 0);
		camParent.transform.rotation = Quaternion.Euler(0, yrDelay, 0);
		fpcam.transform.localRotation = Quaternion.Euler(xrDelay, 0, 0);
		fpcam.transform.position = player.transform.position + new Vector3(0, posMod);

		updateLock();
		
		anim.SetFloat("LookVal", xr);
	}

	void updateLock()
	{
		if (Input.GetKeyUp(KeyCode.Escape))
		{
			cursorLocked = false;
		}
		else if (Input.GetMouseButtonUp(0))
		{
			cursorLocked = true;
		}

		if (cursorLocked)
		{
			Cursor.lockState = CursorLockMode.Locked;
			Cursor.visible = false;
		}
		else if (!cursorLocked)
		{
			Cursor.lockState = CursorLockMode.None;
			Cursor.visible = true;
		}
	}
}
