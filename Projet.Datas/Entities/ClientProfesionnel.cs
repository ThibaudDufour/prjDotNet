namespace Projet.Datas.Entities
{
    public class ClientProfesionnel : Client
    {
        public string Siret {  get; set; }
        public string LegalStatus { get; set; }
        public string SiegeLabel { get; set; }
        public string SiegeComplement { get; set; }
        public string SiegePostalCode { get; set; }
        public string SiegeCity { get; set; }
    } 
}
