#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;

namespace EasyTextEffects
{
    public static class TimeUtil
    {
        private static float _editorStartTime = -1;

        public static float GetTime()
        {
            if (Application.isPlaying)
            {
                return Time.time;
            }
            else
            {
#if UNITY_EDITOR
                if (_editorStartTime < 0)
                {
                    _editorStartTime = (float)EditorApplication.timeSinceStartup; // Capture when this started
                }

                // Normalize time to start from 0 in the editor
                return (float)(EditorApplication.timeSinceStartup - _editorStartTime);
#else
            return 0f; // Fallback if outside editor
#endif
            }
        }
    }
}