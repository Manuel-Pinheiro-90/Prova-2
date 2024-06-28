using Prova_2.Models;

namespace Prova_2.Services
{
    public class ArticoloService : IArticoloService
    {
        private static List<Articolo> _articoli = new List<Articolo>();
        private static int _nextId = 1;


        public IEnumerable<Articolo> GetAll()
        {
            return _articoli;
        }

        public Articolo GetById(int id)
        {
            return _articoli.FirstOrDefault(a => a.Id == id);
        }


        public void Create(Articolo articolo)

        {
            articolo.Id = _nextId++;
            _articoli.Add(articolo);
        }


        public void Update(Articolo articolo)
        {
            {
                var existing = _articoli.FirstOrDefault(a => a.Id == articolo.Id);
                if (existing != null)
                {
                    existing.Nome = articolo.Nome;
                    existing.Prezzo = articolo.Prezzo;
                    existing.Descrizione = articolo.Descrizione;
                    existing.ImmagineCopertina = articolo.ImmagineCopertina;
                    existing.ImmagineAggiuntiva1 = articolo.ImmagineAggiuntiva1;
                    existing.ImmagineAggiuntiva2 = articolo.ImmagineAggiuntiva2;

                }

            }

        }

    }




}
