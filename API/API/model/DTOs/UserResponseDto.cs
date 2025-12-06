using System;

namespace API.model.DTOs;

public class UserResponseDto
{
    public Guid Id { get; set; }
    public string Username { get; set; }
    public string Email { get; set; }
}
