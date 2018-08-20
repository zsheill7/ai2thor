using UnityEngine;
using System.Timers;
using System.Collections;
using System.Threading;

public class Take3DMono : MonoBehaviour {
	public static string fileName = "Unity_3D_Screenshot_";
	public static string folder = "/Users/zoe/Desktop/scene15-mug3/";
	//public GameObject useCamera;
	//public GameObject rotateAround;
	public static int everyXdegrees = 15;
	public static int captureDelayMs = 50;
	public static int currentNumber = 0;
	public static float countDown = 1f;

	void Start()
	{
	}

	public void Wait(GameObject useCamera, GameObject rotateAround1, GameObject rotateAround2, GameObject rotateAround3, GameObject rotateAround4, GameObject rotateAround5, GameObject rotateAround6, GameObject rotateAround7, GameObject rotateAround8) {
		StartCoroutine(RunBoth(useCamera, rotateAround1, rotateAround2, rotateAround3, rotateAround4, rotateAround5, rotateAround6, rotateAround7, rotateAround8));
	}

	IEnumerator RunBoth(GameObject useCamera, GameObject rotateAround1, GameObject rotateAround2, GameObject rotateAround3, GameObject rotateAround4, GameObject rotateAround5, GameObject rotateAround6, GameObject rotateAround7, GameObject rotateAround8) {
		for (int pos = 0; pos < 8; pos++) {
			yield return StartCoroutine (TakeScreenshot (useCamera, rotateAround1, pos));

			yield return StartCoroutine (TakeScreenshot (useCamera, rotateAround2, pos));

			yield return StartCoroutine (TakeScreenshot (useCamera, rotateAround3, pos));

			yield return StartCoroutine (TakeScreenshot (useCamera, rotateAround4, pos));

			yield return StartCoroutine (TakeScreenshot (useCamera, rotateAround5, pos));

			yield return StartCoroutine (TakeScreenshot (useCamera, rotateAround6, pos));

			yield return StartCoroutine (TakeScreenshot (useCamera, rotateAround7, pos));

			yield return StartCoroutine (TakeScreenshot (useCamera, rotateAround8, pos));

			var tempPosition1 = rotateAround1.transform.position;
			var tempPosition2 = rotateAround2.transform.position;
			var tempPosition3 = rotateAround3.transform.position;
			var tempPosition4 = rotateAround4.transform.position;
			var tempPosition5 = rotateAround5.transform.position;
			var tempPosition6 = rotateAround6.transform.position;
			var tempPosition7 = rotateAround7.transform.position;
			var tempPosition8 = rotateAround8.transform.position;

			rotateAround1.transform.position = tempPosition2;
			rotateAround2.transform.position = tempPosition3;
			rotateAround3.transform.position = tempPosition4;
			rotateAround4.transform.position = tempPosition5;
			rotateAround5.transform.position = tempPosition6;
			rotateAround6.transform.position = tempPosition7;
			rotateAround7.transform.position = tempPosition8;
			rotateAround8.transform.position = tempPosition1;
		}
	}

	static IEnumerator TakeScreenshot(GameObject useCamera, GameObject rotateAround, int pos) {
		var startingTransformPosition = new Vector3(-0.3f,0.2f,-0.3f);
		var newPosition = rotateAround.transform.position + startingTransformPosition;
		useCamera.transform.position = newPosition;
		useCamera.transform.LookAt(rotateAround.transform.position);

		Vector3 targetPosition = new Vector3( rotateAround.transform.position.x, rotateAround.transform.position.y, rotateAround.transform.position.z ) ;

		for (int i = 0; i < 4; i++) {
			for (int number = 0; number < (360 / everyXdegrees); number++) {
				ScreenCapture.CaptureScreenshot (folder + fileName + "_" + rotateAround.name + "_" + number + "_pos" + pos + "_vert" + i + "_" + number.ToString ("d4") + ".png");

				//	if (rotateAround)
				useCamera.transform.RotateAround (rotateAround.transform.position, Vector3.up, everyXdegrees);
				//	else
				Debug.Log (useCamera.transform.position);
				Debug.Log (rotateAround.transform.position);
				//		useCamera.transform.Rotate(Vector3.up, everyXdegrees);
				Debug.Log ("Saving " + folder + fileName + number.ToString ("d4") + ".png... DO NOT use the Unity Editor!!");
				yield return new WaitForSeconds (0.003f);//Thread.Sleep (captureDelayMs);
			}
			var secondTransformVector = new Vector3(0f, 0.15f, 0f);
			useCamera.transform.position = useCamera.transform.position + secondTransformVector;
			useCamera.transform.LookAt(rotateAround.transform.position);

		}
		Debug.Log ("All Done! We now return you to your previously scheduled Unity work...");
	}
}
