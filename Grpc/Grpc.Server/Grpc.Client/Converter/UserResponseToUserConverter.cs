using Grpc.Server;

namespace Grpc.Client.Converter;

public static class UserResponseToUserConverter
{
    public static GrpcClientService.User ToUser(UserResponse response) =>
        new GrpcClientService.User
        {
            Id = response.Id,
            Name = response.Name,
            Age = response.Age,
            RegisterDate = new DateTime(response.RegisterDateTicks)
        };
}
