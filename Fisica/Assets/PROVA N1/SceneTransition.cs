using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransition : MonoBehaviour
{
    public string targetSceneName; //Nome da cena alvo
    public KeyCode transferKey = KeyCode.T; //Tecla para transferir o objeto

    public bool transfer = true;


    private void Start()
    {


        transfer = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(transferKey))
        {
            transfer = !transfer;
            MoveObjectToAnotherScene();
        }


    }



    void MoveObjectToAnotherScene()
    {
        switch (transfer)
        {
            case false:
                targetSceneName = "AltScene";
                break;

            case true:
                targetSceneName = "PROVA N1";
                break;
        }

        Scene targetScene = SceneManager.GetSceneByName(targetSceneName);
        if (targetScene.IsValid())
        {
            SceneManager.MoveGameObjectToScene(gameObject, targetScene);
            Debug.Log($"Objeto {gameObject.name} movido para a cena {targetSceneName}.");

        }
        else
        {
            Debug.LogError($"Cena {targetSceneName} não encontrada!");
        }
    }
}
