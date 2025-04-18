// Schnittstelle für Komponenten, die explizit initialisiert werden müssen, zum Beispiel durch einen zentralen Bootstrapper.

namespace Core
{
    public interface IInitializable
    {
        void Initialize();
    }
}
