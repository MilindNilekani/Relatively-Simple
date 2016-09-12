using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Drawing
{
	//****************************************************************************************************
	//  static function DrawLine(rect : Rect) : void
	//  static function DrawLine(rect : Rect, color : Color) : void
	//  static function DrawLine(rect : Rect, width : float) : void
	//  static function DrawLine(rect : Rect, color : Color, width : float) : void
	//  static function DrawLine(Vector2 pointA, Vector2 pointB) : void
	//  static function DrawLine(Vector2 pointA, Vector2 pointB, color : Color) : void
	//  static function DrawLine(Vector2 pointA, Vector2 pointB, width : float) : void
	//  static function DrawLine(Vector2 pointA, Vector2 pointB, color : Color, width : float) : void
	//  
	//  Draws a GUI line on the screen.
	//  
	//  DrawLine makes up for the severe lack of 2D line rendering in the Unity runtime GUI system.
	//  This function works by drawing a 1x1 texture filled with a color, which is then scaled
	//   and rotated by altering the GUI matrix.  The matrix is restored afterwards.
	//
	// Thanks to: capnbishop (http://wiki.unity3d.com/index.php?title=DrawLine)
	//****************************************************************************************************

	public static Texture2D lineTex;

	public static void DrawLine(Rect rect) { DrawLine(rect, GUI.contentColor, 1.0f); }
	public static void DrawLine(Rect rect, Color color) { DrawLine(rect, color, 1.0f); }
	public static void DrawLine(Rect rect, float width) { DrawLine(rect, GUI.contentColor, width); }
	public static void DrawLine(Rect rect, Color color, float width) { DrawLine(new Vector2(rect.x, rect.y), new Vector2(rect.x + rect.width, rect.y + rect.height), color, width); }
	public static void DrawLine(Vector2 pointA, Vector2 pointB) { DrawLine(pointA, pointB, GUI.contentColor, 1.0f); }
	public static void DrawLine(Vector2 pointA, Vector2 pointB, Color color) { DrawLine(pointA, pointB, color, 1.0f); }
	public static void DrawLine(Vector2 pointA, Vector2 pointB, float width) { DrawLine(pointA, pointB, GUI.contentColor, width); }
	public static void DrawLine(Vector2 pointA, Vector2 pointB, Color color, float width)
	{
		// Save the current GUI matrix, since we're going to make changes to it.
		Matrix4x4 matrix = GUI.matrix;

		// Generate a single pixel texture if it doesn't exist
		if (!lineTex) { lineTex = new Texture2D(1, 1); }

		// Store current GUI color, so we can switch it back later,
		// and set the GUI color to the color parameter
		Color savedColor = GUI.color;
		GUI.color = color;

		// Determine the angle of the line.
		float angle = Vector3.Angle(pointB - pointA, Vector2.right);

		// Vector3.Angle always returns a positive number.
		// If pointB is above pointA, then angle needs to be negative.
		if (pointA.y > pointB.y) { angle = -angle; }

		// Use ScaleAroundPivot to adjust the size of the line.
		// We could do this when we draw the texture, but by scaling it here we can use
		//  non-integer values for the width and length (such as sub 1 pixel widths).
		// Note that the pivot point is at +.5 from pointA.y, this is so that the width of the line
		//  is centered on the origin at pointA.
		GUIUtility.ScaleAroundPivot(new Vector2((pointB - pointA).magnitude, width), new Vector2(pointA.x, pointA.y + 0.5f));

		// Set the rotation for the line.
		//  The angle was calculated with pointA as the origin.
		GUIUtility.RotateAroundPivot(angle, pointA);

		// Finally, draw the actual line.
		// We're really only drawing a 1x1 texture from pointA.
		// The matrix operations done with ScaleAroundPivot and RotateAroundPivot will make this
		//  render with the proper width, length, and angle.
		GUI.DrawTexture(new Rect(pointA.x, pointA.y, 1, 1), lineTex);

		// We're done.  Restore the GUI matrix and GUI color to whatever they were before.
		GUI.matrix = matrix;
		GUI.color = savedColor;
	}
}

public class SimpleGraph {
	private List<Vector2> values;
	private Vector2 dimensions;
	private Vector2 coords;
	private int n;
	private int yMultiplyer;
	private int bottomPadding;

	public SimpleGraph()
	{
		values = new List<Vector2> ();
		coords = new Vector2 (0, 0);//(Screen.width/2, Screen.height/10);
		dimensions = new Vector2 (0,0);// (Screen.width, Screen.height/5);
		yMultiplyer = 20;
		bottomPadding = 10;
		n = 0;
	}

	public void SetParams(Vector2 newCoords, Vector2 newDimenions)
	{
		coords = newCoords;
		dimensions = newDimenions;
	}

	public void NewValues(List<Vector2> newValues)
	{
		//values.Clear ();
		values = newValues;
		n = values.Count;

		List<float> smoother = new List<float>(){0.0f, 0.0f, 0.0f, 0.0f, 0.0f};
		for (int i = 0; i < n; i++) {
			smoother.Add (values [i].y);
			smoother.RemoveAt (0);
			float sum = 0.0f;
			foreach (float value in smoother)
				sum += value;
			sum /= 4;
			values [i] = new Vector2 (values [i].x, sum);
		}
	}

	public void Draw(){
		for (int i=0; i<n-1; i++) {
			Vector2 pointA = new Vector2 (coords.x-dimensions.x/2+values [i].x*dimensions.x/(n-1) , Screen.height-coords.y+dimensions.y/2-bottomPadding-values[i].y*yMultiplyer);
			Vector2 pointB = new Vector2 (coords.x-dimensions.x/2+values [i+1].x*dimensions.x/(n-1) , Screen.height-coords.y+dimensions.y/2-bottomPadding-values[i+1].y*yMultiplyer);
			Drawing.DrawLine(pointA, pointB, new Color(0.16f, 0.75f, 0.99f), 3.0f);
		}
	
	}
}

public class ChartingScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
