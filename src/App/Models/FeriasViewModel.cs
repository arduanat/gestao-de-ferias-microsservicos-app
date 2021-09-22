using System.Collections.Generic;

namespace App.Models
{
    public class FeriasViewModel
    {
        public int Id { get; set; }
        public List<PeriodoDeFeriasViewModel> PeriodosDeFerias { get; set; }
        public ColaboradorViewModel Colaborador { get; set; }
        public HomologacaoDeFeriasViewModel Homologacao { get; set; }
    }
}
