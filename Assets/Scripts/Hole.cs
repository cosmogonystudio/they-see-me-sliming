using UnityEngine;
// using UnityEngine.SceneManagement;

public class Hole : SlimeTrigger
{

    protected override void OnAllSmiles()
    {
        // SceneManager.LoadScene(SceneManager.GetActiveScene().name);

#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }

}
