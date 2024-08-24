namespace AbcClientApi.Models
{
    public class ClientInfo
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = null!;
        public string? MiddleName { get; set; }
        public string LastName { get; set; } = null!;
        public string SecondLastName { get; set; } = null!;
        public string ContactNumber { get; set; } = null!;
        public string Email { get; set; } = null!;
        public DateTime DateOfBirth { get; set; }
        public decimal EstimatedInsuranceValue { get; set; }
        public string? Notes { get; set; }
    }
}
