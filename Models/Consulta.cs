namespace HealthTrack.Models
{
    public class Consulta
    {
        public int Id { get; set; }
        public int MedicoId { get; set; }
        public int PacienteId { get; set; }
        public DateTime DataConsulta { get; set; }
        public string Observacoes { get; set; } = string.Empty;

        // Propriedades anuláveis (relacionamentos de navegação)
        public Medico? Medico { get; set; }
        public Paciente? Paciente { get; set; }
    }
}