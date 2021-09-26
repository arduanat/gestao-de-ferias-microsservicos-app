using System.Collections.Generic;

namespace App.Models
{
    public class Ferias
    {
        public Ferias(Colaborador colaborador, int anoDeExercicio, int id = 0)
        {
            Id = id;
            ColaboradorId = colaborador.Id;
            Colaborador = colaborador;
            AnoDeExercicio = anoDeExercicio;
        }

        public Ferias()
        {
        }

        public int Id { get; set; }
        public int ColaboradorId { get; set; }
        public int AnoDeExercicio { get; set; }
        public Colaborador Colaborador { get; set; }
        public HomologacaoDeFerias Homologacao { get; set; }
        public List<PeriodoDeFerias> PeriodosDeFerias { get; set; }
    }
}