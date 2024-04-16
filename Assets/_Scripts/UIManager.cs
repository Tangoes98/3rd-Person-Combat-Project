using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    bool _menuEnabled = false;
    [SerializeField] GameObject _menu;
    [SerializeField] Button _continue;
    [SerializeField] Button _quit;


    void Start()
    {
        InputReader.Instance.MenuEvent += OnMenuEvent;

        _continue.onClick.AddListener(() =>
        {
            _menuEnabled = !_menuEnabled;
            Time.timeScale = 1f;
        });
        
        _quit.onClick.AddListener(() => { Application.Quit(); });
    }

    void Update()
    {
        _menu.SetActive(_menuEnabled);
    }

    void OnMenuEvent()
    {
        _menuEnabled = !_menuEnabled;
        Time.timeScale = 0f;
    }


}
