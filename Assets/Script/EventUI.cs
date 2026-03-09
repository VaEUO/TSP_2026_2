using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;
using TMPro;
public class EventUI : MonoBehaviour
{
    public List<GameObject> listaInstrucciones;
    public int currentIndex = 0;
    public List<string> mensajesInstrucciones;
    public TextMeshProUGUI textMeshProUGUI;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created

    void Start()
    {
        //Metodo para actualizar visivilidad de paneles
     UpdateVisibility();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void UpdateVisibility()
    {
        for (int i = 0; i < listaInstrucciones.Count;i++)
        {
            //Solo el panel en el indice actula esta activol
            listaInstrucciones[i].SetActive(i==currentIndex);
        }
    }
    //Metodo para cambiar de escena

    public void ChangeSceneByIndex(int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex);
    }
    public void ChangeSceneByName(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    //Recargar la escena actual
    public void ReloadCurrentScene()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.buildIndex);
    }

    //Metodo para cambiar de paneles
    public void CycleObjets(int direction)
    {
        currentIndex = (currentIndex + direction + listaInstrucciones.Count) % listaInstrucciones.Count;
        //Actualizar la visibilidad
        UpdateVisibility();
    }

    //Metodo para actualizar el texto mostrado

    private void UpdateText()
    {
        if (mensajesInstrucciones.Count > 0 && textMeshProUGUI != null )
        {
            textMeshProUGUI.text = mensajesInstrucciones[currentIndex];
        }
    }

    public void CycleText(int direction)
    {
        currentIndex = (currentIndex + direction + mensajesInstrucciones.Count) % mensajesInstrucciones.Count;
        //Actualizar la visibilidad
        UpdateText();
    }

    // Metodo par salir de la aplicacion
    public void ExitGame()
    {
        Debug.Log("Va a asalir");
        Application.Quit();
        Debug.Log("Ya salio");
    }
}
