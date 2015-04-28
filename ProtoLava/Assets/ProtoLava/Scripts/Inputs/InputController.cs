using UnityEngine;
using System.Collections;

public class InputController : MonoBehaviour {

	private Vector2 gesto;
	private Vector2 inicio;
	private Vector2 ultimo;
	private bool isPressed = false;
	public bool isTouch {get {
			if (Input.touchSupported)
			{
				return Input.touchCount > 0;
			}
			else
			{
				return Input.GetMouseButton(0);
			}
		}
	}

	public Vector2 GetCurrentInput()
	{
		if (Input.touchSupported) {
			return Input.touches [0].position;
		} else {
			return Input.mousePosition;
		}
	}

	public delegate void OnTouchBegin();
	public delegate void OnTouchEnd (Vector2 gesto);

	public event OnTouchBegin onBegin;
	public event OnTouchEnd onFinish;


	// Use this for initialization
	void Start () {
	
		Debug.Log (Input.touchSupported);

	}

	void LateUpdate()
	{
		if (transform.GetComponent<FloorType> ().inGroundEstable || transform.GetComponent<FloorType> ().inGroundDinamico) {
			if (isTouch) {
				if (!isPressed) {
					Debug.Log ("Pos: " + GetCurrentInput () + "It's Pressed");
					isPressed = true;
					inicio = GetCurrentInput ();
					ultimo = inicio;
					if (onBegin != null) {
						onBegin ();
					}
				} else {
					ultimo = GetCurrentInput ();

				}
			} else if (!isTouch && isPressed) {
				Debug.Log ("Solto");
				isPressed = false;
				gesto = ultimo - inicio;  
				Debug.Log ("Gesto: " + gesto);
				if (onFinish != null) {
					onFinish (gesto);
				}
			}
		}
	}

	// Update is called once per frame
	void Update () {
	

	}
}
