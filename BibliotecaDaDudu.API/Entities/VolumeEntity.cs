using static BibliotecaDaDudu.API.Helpers.EnumHelpers;

namespace BibliotecaDaDudu.API.Entities
{
    public class VolumeEntity
    {
        public VolumeEntity()
        {
            Id = Guid.NewGuid();
            //StatusLeitura = Leitura.NaoIniciado;
            //StatusCompra = Compra.NaoComprado;
        }

        public Guid Id { get; set; }
        public float Avaliacao { get; set; } //de 0 a 5
        public Leitura StatusLeitura { get; set; } // de 0 a 5
        public Compra StatusCompra { get; set; }
        public int Numero { get; set; }
        public string Sinopse { get; set; }
        public Guid MangaId { get; set; }
        public DateTime CreatedAt { get; }
        public Guid CapaId { get; set; }

        public void Update(VolumeEntity volume)
        {
            Numero = volume.Numero;
            Avaliacao = volume.Avaliacao;
            StatusLeitura = volume.StatusLeitura;
            CapaId = volume.CapaId;
            Sinopse = volume.Sinopse;
            StatusCompra = volume.StatusCompra;
        }
    }
}
