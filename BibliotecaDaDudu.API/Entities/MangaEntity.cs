using static BibliotecaDaDudu.API.Helpers.EnumHelpers;

namespace BibliotecaDaDudu.API.Entities
{
    public class MangaEntity
    {
        public MangaEntity()
        {
            Id = Guid.NewGuid();
            //Concluido = false;
            //StatusLeitura = Leitura.NaoIniciado;
            //Ativo = true;
            Volumes = [];
        }
        public Guid Id { get; set; }
        public Guid CapaId { get; set; }
        public string Titulo { get; set; }
        public string Editora { get; set; }
        public string Autor { get; set; }
        public int TotalVolumes { get; set; }
        public string Sinopse { get; set; }
        public bool Concluido { get; set; }
        public int Avaliacao { get; set; } //de 0 a 5
        public Leitura StatusLeitura { get; set; } // de 0 a 5
        public List<VolumeEntity> Volumes { get; set; }
        public bool Ativo { get; set; }
        public DateTime CreatedAt { get; }

        public void Update(MangaEntity manga)
        {
            Titulo = manga.Titulo;
            Editora = manga.Editora;
            Autor = manga.Autor;
            TotalVolumes = manga.TotalVolumes;
            Volumes = manga.Volumes;
            CapaId = manga.CapaId;
            Sinopse = manga.Sinopse;
            Concluido = manga.Concluido;
            Avaliacao = manga.Avaliacao;
            StatusLeitura = manga.StatusLeitura;
        }

        public void Desativar()
        {
            Ativo = false;
        }
        public void Reativar()
        {
            Ativo = true;
        }
    }
}
