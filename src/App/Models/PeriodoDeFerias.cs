using App.Models.ValueObjects.Enums;
using System;

namespace App.Models
{
    public class PeriodoDeFerias
    {
        public int Id { get; set; }
        public int FeriasId { get; set; }
        public int QuantidadeDeDias { get; set; }
        public DateTime DataInicial { get; set; }
        public DateTime DataFinal { get; set; }
        public TipoDePeriodoDeFerias TipoDePeriodoDeFerias { get; set; }
    }
}
