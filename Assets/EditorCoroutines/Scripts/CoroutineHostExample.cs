using UnityEngine;
using System.Collections;
using System.Runtime.InteropServices;
using UnityEditor;

namespace EditorCoroutines.Examples
{
	public class CoroutineHostExample : EditorCoroutineHost
	{
		private static CoroutineHostExample _instance;
		private static CoroutineHostExample Instance
		{
			get
			{
				if (_instance == null)
				{
					_instance = new CoroutineHostExample();
				}

				return _instance;
			}
		}

		[MenuItem("Window/Coroutine Example (Host)/Start")]
		public static void Start()
		{
			Instance.StartCoroutine(Instance.Example());
		}

		[MenuItem("Window/Coroutine Example (Host)/Start WWW")]
		public static void StartWWW()
		{
			Instance.StartCoroutine(Instance.ExampleWWW());
		}

		[MenuItem("Window/Coroutine Example (Host)/Start Nested")]
		public static void StartNested()
		{
			Instance.StartCoroutine(Instance.ExampleNested());
		}

		[MenuItem("Window/Coroutine Example (Host)/Stop")]
		public static void Stop()
		{
			Instance.StopCoroutine("Example");
		}
		
		[MenuItem("Window/Coroutine Example (Host)/Stop all")]
		public static void StopAll()
		{
			Instance.StopAllCoroutines();
		}

		[MenuItem("Window/Coroutine Example (Host)/Also")]
		public static void Also()
		{
			Instance.StopAllCoroutines();
		}
		
		IEnumerator Example()
		{
			while (true)
			{
				Debug.Log("Hello EditorCoroutine!");
				yield return new WaitForSeconds(2f);
			}
		}

		IEnumerator ExampleWWW()
		{
			while (true)
			{
				var www = new WWW("https://unity3d.com/");
				yield return www;
				Debug.Log("Hello EditorCoroutine!" + www.text);
				yield return new WaitForSeconds(2f);
			}
		}

		IEnumerator ExampleNested()
		{
			while (true)
			{
				yield return new WaitForSeconds(2f);
				Debug.Log("I'm not nested");
				yield return this.StartCoroutine(ExampleNestedOneLayer());
			}
		}

		IEnumerator ExampleNestedOneLayer()
		{
			yield return new WaitForSeconds(2f);
			Debug.Log("I'm one layer nested");
			yield return this.StartCoroutine(ExampleNestedTwoLayers());
		}

		IEnumerator ExampleNestedTwoLayers()
		{
			yield return new WaitForSeconds(2f);
			Debug.Log("I'm two layers nested");
		}
	}
}