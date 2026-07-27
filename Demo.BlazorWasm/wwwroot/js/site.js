// Small helpers the demo needs from the browser. Kept dependency-free on purpose.
window.taLib = {
    setTheme(mode) {
        document.documentElement.setAttribute('data-theme', mode);
        const meta = document.querySelector('meta[name="theme-color"]');
        if (meta) {
            meta.setAttribute('content', mode === 'dark' ? '#0c1115' : '#eef1f4');
        }
    },

    prefersDark() {
        return window.matchMedia && window.matchMedia('(prefers-color-scheme: dark)').matches;
    },

    // Returns false when the clipboard is unavailable (insecure origin, denied permission)
    // so the caller can tell the reader to copy manually instead of silently doing nothing.
    async copy(text) {
        try {
            await navigator.clipboard.writeText(text);
            return true;
        } catch {
            return false;
        }
    }
};
