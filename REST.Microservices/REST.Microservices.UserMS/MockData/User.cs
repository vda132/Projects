﻿namespace REST.Microservices.UserMS.MockData;

public class User
{
    public int Id { get; set; }
    public string Name { get; set; } = default!;
    public string Email { get; set; } = default!;
    public DateTime Registred { get; set; }
}
