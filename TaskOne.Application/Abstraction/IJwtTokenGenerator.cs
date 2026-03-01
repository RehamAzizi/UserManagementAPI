namespace TaskOne.Application.Abstraction
{
    public interface IJwtTokenGenerator
    {
        public string GenerateToken(Guid userId, string firstName, string lastName);
    }
}