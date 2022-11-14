namespace Grpc.Server.Converter;

public static class UserToResponseConverter
{
    public static UserResponse ToUserResponse(Services.User user) =>
        new UserResponse
        {
            Id = user.Id,
            Name = user.Name,
            Age = user.Age,
            RegisterDateTicks = user.RegisterDate.Ticks
        };
}
