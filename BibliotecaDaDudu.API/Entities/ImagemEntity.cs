namespace BibliotecaDaDudu.API.Entities
{
    public class ImagemEntity
    {
        public ImagemEntity()
        {
            Id = Guid.NewGuid();
        }

        public Guid Id { get; set; }
        public string Texto { get; set; }
        public string Nome { get; set; }                        
        public DateTime CreatedAt { get; }

    }
}
