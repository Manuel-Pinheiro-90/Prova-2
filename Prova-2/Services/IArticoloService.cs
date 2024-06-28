using Prova_2.Models;

namespace Prova_2.Services
{
    public interface IArticoloService
    {
        IEnumerable<Articolo> GetAll();
        Articolo GetById(int id);
        void Create(Articolo articolo);
        void Update(Articolo articolo); 


    }
}
