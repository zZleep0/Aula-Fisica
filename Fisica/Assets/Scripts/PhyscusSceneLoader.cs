using UnityEngine;
using UnityEngine.SceneManagement;

public class PhyscusSceneLoader : MonoBehaviour
{
    public string physicsSceneName;
    public float physicsSceneTimeScale = 1;
    private PhysicsScene physicsScene;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //Load the scene to place in the local physics scene
        LoadSceneParameters param = new LoadSceneParameters(LoadSceneMode.Additive, LocalPhysicsMode.Physics3D);
        Scene scene = SceneManager.LoadScene(physicsSceneName, param);
        //Get the scene's physics scene
        physicsScene = scene.GetPhysicsScene();
    }

    private void FixedUpdate()
    {
        //Simulate the scene on FixedUpdate.
        if (physicsScene != null)
        {
            physicsScene.Simulate(Time.fixedDeltaTime * physicsSceneTimeScale);
        }
    }
}
