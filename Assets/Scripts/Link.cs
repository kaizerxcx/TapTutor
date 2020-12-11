using UnityEngine;
using System.Runtime.InteropServices;
using UnityEngine.UI;

public class Link : MonoBehaviour 
{

	public void ytvideo1()
	{
		#if !UNITY_EDITOR
		openWindow("https://www.youtube.com/watch?v=XqZsoesa55w");
		#endif
	}


	[DllImport("__Internal")]
	private static extern void openWindow(string url);

}