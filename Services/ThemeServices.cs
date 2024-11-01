namespace uts_frontend_72220561.Services
{
    // ThemeService.cs
    public class ThemeService
    {
        public string Theme { get; private set; } = "light";
        public event Action OnThemeChange;

        public void SetTheme(string theme)
        {
            Theme = theme;
            OnThemeChange?.Invoke();
        }
    }

}
