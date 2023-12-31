﻿#if UNITY_EDITOR

using System.Collections;
using UnityEditor;

public class EditorCoroutine
{
	public bool IsDone;

	public static EditorCoroutine Start(IEnumerator _routine)
	{
		var coroutine = new EditorCoroutine(_routine);
		coroutine.Execute();
		return coroutine;
	}

	internal IEnumerator _coroutine;

	public EditorCoroutine(IEnumerator _routine)
	{
		_coroutine = _routine;
	}

	public void Execute()
	{
		IsDone = false;
		EditorApplication.update += update;
	}
	public void Abort()
	{
		IsDone = true;
		EditorApplication.update -= update;
	}

	void update()
	{
		/* NOTE: no need to try/catch MoveNext,
		 * if an IEnumerator throws its next iteration returns false.
		 * Also, Unity probably catches when calling EditorApplication.update.
		 */

		//Debug.Log("update");
		if (!_coroutine.MoveNext())
		{
			Abort();
		}
	}
}

#endif
