using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransferManager : MonoBehaviour
{
    public string targetSceneName; //Nome da cena alvo
    public KeyCode transferKey = KeyCode.T; //Tecla para transferir o objeto

    public bool transfer = true;

    public Renderer chaoTerra;
    public Renderer chaoGelo;

    private void Start()
    {

        chaoTerra = GameObject.Find("ChaoTerra").GetComponent<Renderer>();
        chaoTerra.material.color = Color.green;

        //chaoGelo = GameObject.Find("ChaoGelo").GetComponent<Renderer>();

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
                chaoTerra.material.color = Color.white;
                targetSceneName = "AlternativeScene";
                break;

            case true:
                chaoTerra.material.color = Color.green;
                targetSceneName = "MainScene";
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
