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
    //Metodo para cambiar de paneles
    public void CycleObjets()
    {
        currentIndex = (currentIndex + 1) % listaInstrucciones.Count;
        //Actualizar la visibilidad
        UpdateVisibility();
    }

    //Metodo para actualizar el texto mostrado

    private void UpdateText()
    {
        if (mensajesInstrucciones.Count > 0 )
        {
            
        }
    }

    // Metodo par salir d ela aplicacion
    public void ExitGame()
    {
        Debug.Log("Va a asalir");
        Application.Quit();
        Debug.Log("Ya salio");
    }
}
