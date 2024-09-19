using System.Windows;

namespace WPFDynamicTheme.Core;

public class ThemeManager
{
    private Dictionary<string, ResourceDictionary> _themes = new();

    public void RegisterTheme(string themeName, string assemblyName, string resourcePath)
    {
        string uri = $"/{assemblyName};component/{resourcePath}";

        ResourceDictionary resource = new ResourceDictionary();
        resource.Source = new Uri(uri, UriKind.RelativeOrAbsolute);

        _themes.Add(themeName, resource);
    }

    public void ApplyTheme(string themeName)
    {
        ResourceDictionary resource = _themes[themeName];

        foreach (var theme in _themes)
        {
            Application.Current.Resources.MergedDictionaries.Remove(theme.Value);
        }

        Application.Current.Resources.MergedDictionaries.Add(resource);
    }
}