// Schnittstelle f�r Komponenten, die explizit initialisiert werden m�ssen, zum Beispiel durch einen zentralen Bootstrapper.

namespace Core
{
    public interface IInitializable
    {
        void Initialize();
    }
}
