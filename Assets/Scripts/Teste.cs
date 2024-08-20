using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeSceneOnCollision : MonoBehaviour
{
    // Nome da cena que você deseja carregar
    public string sceneToLoad;

    private void OnCollisionEnter(Collision collision)
    {
        // Verifica se a colisão foi com o objeto desejado (opcional)
        if (collision.gameObject.CompareTag("Player"))
        {
            // Carrega a cena pelo nome
            SceneManager.LoadScene("Morte");
        }
    }
}