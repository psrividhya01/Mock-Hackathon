namespace FreeLancerProj.DTOs;

public class ClientDto
{
    
    public int ClientId { get; set; }
    public string Name { get; set; } = default!;
    public double HourlyRate { get; set; }
    public string? Email { get; set; }
}