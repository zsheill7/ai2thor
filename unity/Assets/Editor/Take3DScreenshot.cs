using UnityEngine;
using UnityEditor;
using System.Threading;
using System.Collections;

public class Take3DScreenshot : ScriptableWizard {
	public static string fileName = "Unity 3D Screenshot _";
	public static string folder = "/Users/zoe/Desktop/bowl3/";
	public GameObject useCamera;
	public GameObject rotateAround1;
	public GameObject rotateAround2;
	public GameObject rotateAround3;
	public GameObject rotateAround4;
	public GameObject rotateAround5;
	public GameObject rotateAround6;
	public GameObject rotateAround7;
	public GameObject rotateAround8;

	public int everyXdegrees = 15;
	public int captureDelayMs = 1500;

	[MenuItem ("Custom/Take 3D Screenshot of Game View")]

	static void DoSet () {
		ScriptableWizard.DisplayWizard("Set params for 3D Screenshot", typeof(Take3DScreenshot), "Create");
	}

	void OnWizardUpdate () {
		helpString = "Set the parameters to create a series of pictures in a circle... \n\nThese settings will create: " + (360 / everyXdegrees) + " images";

	}

	void OnWizardCreate () {
		TakeScreenshot();
	}

	void TakeScreenshot () {
		var number = 0;
		Debug.Log (number);

		//var startingRotation = new Quaternion(0.0f, 0.0f, 0.0f, 1);
		//
		Vector3 targetPosition = new Vector3( rotateAround1.transform.position.x, rotateAround1.transform.position.y, rotateAround1.transform.position.z ) ;
		var startingTransformPosition = new Vector3(-0.4f,0.2f,-0.4f);
		var newPosition = rotateAround1.transform.position + startingTransformPosition;
		Debug.Log("rotateAround.transform.position");
		Debug.Log(rotateAround1.transform.position);
		Debug.Log(newPosition);
		useCamera.transform.position = newPosition;
		useCamera.transform.LookAt(targetPosition);
		Debug.Log("useCamera.transform.position");
		Debug.Log(useCamera.transform.position);

		ScreenCapture.CaptureScreenshot(folder +"Test" +number+"_"+number.ToString("d4") +".png");

		Debug.Log ("Saving " +folder + "Unity2" +number.ToString("d4") +".png... DO NOT use the Unity Editor!!");
	  

		var gameObject = new GameObject();

	  	var take3DMono = gameObject.AddComponent<Take3DMono>();
		take3DMono.Wait(useCamera, rotateAround1, rotateAround2, rotateAround3, rotateAround4, rotateAround5, rotateAround6, rotateAround7, rotateAround8);



		Debug.Log ("All Done! We now return you to your previously scheduled Unity work...");
	}
}
