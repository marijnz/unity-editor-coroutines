using System.Collections;

namespace EditorCoroutines
{
    public class EditorCoroutineHost
    {
        public EditorCoroutines.EditorCoroutine StartCoroutine(IEnumerator coroutine)
        {
            return EditorCoroutines.StartCoroutine(coroutine, this);
        }

        public EditorCoroutines.EditorCoroutine StartCoroutine(string methodName)
        {
            return EditorCoroutines.StartCoroutine(methodName, this);
        }

        public EditorCoroutines.EditorCoroutine StartCoroutine(string methodName, object value)
        {
            return EditorCoroutines.StartCoroutine(methodName, value, this);
        }

        public void StopCoroutine(IEnumerator coroutine)
        {
            EditorCoroutines.StopCoroutine(coroutine, this);
        }

        public void StopCoroutine(string methodName)
        {
            EditorCoroutines.StopCoroutine(methodName, this);
        }

        public void StopAllCoroutines()
        {
            EditorCoroutines.StopAllCoroutines(this);
        }
    }
}