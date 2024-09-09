namespace MedCare.Application.Shared.Behavior;

public class ApiPostgresExceptionReponse
{
    public string Message { get; }
    public ApiPostgresExceptionReponse(string sqlState, string message = null)
    {
        Message = message ?? GetDefaultMessageForStatusCode(sqlState);
    }
    private static string GetDefaultMessageForStatusCode(string sqlState)
    {
        switch (sqlState)
        {
            case "23505":
                return "Registro já cadastrado no banco de dados";
            case "23503":
                return "O registro não pode ser deletado, pois está relacionado a outros registros";
            case "23514":
                return "Valor não permitido no banco de dados";
            default:
                return "Uma exceção não tratada ocorreu no request";
        }
    }
}
