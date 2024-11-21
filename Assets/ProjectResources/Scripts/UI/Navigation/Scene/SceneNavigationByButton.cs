using UnityEngine.SceneManagement;

public class SceneNavigationByButton : NavigationByButton
{
    protected override void go()
    {
        SceneManager.LoadScene(index);
    }
}