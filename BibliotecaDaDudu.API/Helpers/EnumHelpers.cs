namespace BibliotecaDaDudu.API.Helpers
{
    public class EnumHelpers
    {
        public enum Leitura
        {
            NaoIniciado,
            Iniciado,
            Lendo,
            Finalizado,
            Cancelado,
        }
        public enum Compra
        {
            NaoComprado,
            Reservado,
            Comprado,
        }
    }
}
