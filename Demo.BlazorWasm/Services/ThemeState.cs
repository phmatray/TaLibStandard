namespace Demo.BlazorWasm.Services;

/// <summary>
/// Holds the light/dark choice so the shell and the MudBlazor theme provider stay in step.
/// </summary>
/// <remarks>
/// The toggle lives in the header but <c>MudThemeProvider</c> sits above the layout in
/// <c>App.razor</c>, so the two need a shared source of truth. Without it the previous demo's
/// toggle flipped a private field and nothing happened.
/// </remarks>
public sealed class ThemeState
{
    /// <summary>Raised after the theme changes so subscribers can re-render.</summary>
    public event Action? Changed;

    /// <summary>Gets a value indicating whether the dark theme is active.</summary>
    public bool IsDark { get; private set; }

    /// <summary>Switches the theme and notifies subscribers, ignoring a no-op change.</summary>
    /// <param name="isDark">Whether the dark theme should be active.</param>
    public void Set(bool isDark)
    {
        if (IsDark == isDark)
        {
            return;
        }

        IsDark = isDark;
        Changed?.Invoke();
    }
}
