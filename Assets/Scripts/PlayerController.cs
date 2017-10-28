using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

	public float speed;
	public Text countText;

	private Rigidbody rb;
	private int count;

	// Use this for initialization
	void Start () {
		Debug.Log ("Device model: " + SystemInfo.deviceModel);
		Debug.Log ("Device name: " + SystemInfo.deviceName);
		Debug.Log ("Device type: " + SystemInfo.deviceType);
		Debug.Log ("Device uid: " + SystemInfo.deviceUniqueIdentifier);
		Debug.Log ("Graphic device ID: " + SystemInfo.graphicsDeviceID);
		Debug.Log ("Graphic device name: " + SystemInfo.graphicsDeviceName);
		Debug.Log ("Graphic device type: " + SystemInfo.graphicsDeviceType);
		Debug.Log ("Graphic device vendor: " + SystemInfo.graphicsDeviceVendor);
		Debug.Log ("Graphic device versino: " + SystemInfo.graphicsDeviceVersion);
		Debug.Log ("Graphic memory size: " + SystemInfo.graphicsMemorySize);
		Debug.Log ("Graphic multi thread: " + SystemInfo.graphicsMultiThreaded);
		Debug.Log ("Graphic shader level: " + SystemInfo.graphicsShaderLevel);
		Debug.Log ("Graphic UV start at top: " + SystemInfo.graphicsUVStartsAtTop);
		rb = GetComponent<Rigidbody> ();
		count = 0;
		SetCountText ();
	}
	
	// Update is called once per frame
	// called before rendering a frame
	void Update () {
		
	}

	// Fixed called before performing any physics calculation
	void FixedUpdate(){

		float moveHorizontal;
		float moveVertical;

		moveHorizontal = 0.0f;
		moveVertical = 0.0f;

		switch (SystemInfo.deviceType) {
		case DeviceType.Console:
			break;
		case DeviceType.Desktop:
			moveHorizontal = Input.GetAxis ("Horizontal");
			moveVertical = Input.GetAxis ("Vertical");
			break;
		case DeviceType.Handheld:
			moveHorizontal = Input.acceleration.x;
			moveVertical = Input.acceleration.y;
			break;
		case DeviceType.Unknown:
			break;
		default:
			break;
		}

		Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);
		rb.AddForce (movement * speed);
	}

	void OnTriggerEnter(Collider other){
		if(other.gameObject.CompareTag("Pick up")){
			Destroy (other.gameObject);
			//other.gameObject.SetActive(false);
			count++;
			SetCountText ();
		}
	}

	void SetCountText(){
		countText.text = "Count: " + count.ToString ();
	}
}
