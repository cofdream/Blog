using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;

namespace BlazorApp.Service
{
    public class LocalStorageService
    {
        private readonly ProtectedLocalStorage _protectedLocalStorage;

        public LocalStorageService(ProtectedLocalStorage protectedLocalStorage)
        {
            _protectedLocalStorage = protectedLocalStorage;
        }
    }
}
