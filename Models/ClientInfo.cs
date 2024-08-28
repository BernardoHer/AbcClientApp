namespace AbcClientApi.Models
{
    public class ClientInfo
    {
        public required int Id { get; set; }
        public required string FirstName { get; set; } = null!;
        public string? MiddleName { get; set; }
        public required string LastName { get; set; } = null!;
        public required string SecondLastName { get; set; } = null!;
        public required string ContactNumber { get; set; } = null!;
        public required string Email { get; set; } = null!;
        public required DateTime DateOfBirth { get; set; }
        public required decimal EstimatedInsuranceValue { get; set; }
        public string? Notes { get; set; }
    }
}
