using App.Models.ValueObjects.Enums;

namespace App.Models
{
    public class HomologacaoDeFerias
    {
        public int Id { get; set; }
        public int FeriasId { get; set; }
        public SituacaoDasFerias SituacaoDasFerias { get; set; }
    }
}