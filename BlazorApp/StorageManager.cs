using Microsoft.JSInterop;

namespace BlazorApp
{
    public static class StorageManager
    {
        public static async ValueTask SetLocalStorage(this IJSRuntime jsRuntime, string key, object value)
        {
            await jsRuntime.InvokeVoidAsync("localStorage.setItem", key, value);
        }

        public static async ValueTask<TValue?> GetLocalStorage<TValue>(this IJSRuntime jsRuntime, string key, TValue? defaultValue = default)
        {
            if (jsRuntime == null)
                return defaultValue;
            try
            {
                return await jsRuntime.InvokeAsync<TValue>("localStorage.getItem", key);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return defaultValue;
            }
        }

        public static async ValueTask SetSessionStorage(this IJSRuntime jsRuntime, string key, object value)
        {
            if (jsRuntime == null)
                return;
            await jsRuntime.InvokeVoidAsync("sessionStorage.setItem", key, value);
        }

        public static async ValueTask<TValue?> GetSessionStorage<TValue>(this IJSRuntime jsRuntime, string key, TValue? defaultValue = default)
        {
            if (jsRuntime == null)
                return defaultValue;

            return await jsRuntime.InvokeAsync<TValue>("sessionStorage.getItem", key);
        }
    }
}
