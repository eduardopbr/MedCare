using System.Collections.ObjectModel;

namespace MedCare.Application.Shared.Behavior;

public class Response
{
    private readonly IList<string> _messages = new List<string>();
    public IEnumerable<string> Errors { get; }
    public string? MensagemSucesso { get; private set; }
    public string? MensagemAviso { get; private set; }
    public object? Result { get; }
    public CodeStateResponse CodeState { get; private set; }

    public Response(CodeStateResponse codeState)
    {
        Errors = new ReadOnlyCollection<string>(_messages);
        this.CodeState = codeState;
    }

    public Response(IEnumerable<object> result) : this(CodeStateResponse.Success)
    {
        Result = result;
    }

    public Response(object result) : this(CodeStateResponse.Success) => Result = result;

    public Response AddError(string message)
    {
        _messages.Add(message);
        return this;
    }

    public Response AddSucessoMensagem(string mensagemSucesso)
    {
        MensagemSucesso = mensagemSucesso;
        return this;
    }

    public Response AddAvisoMensagem(string mensagemAviso)
    {
        MensagemAviso = mensagemAviso;
        return this;
    }
}

public enum CodeStateResponse
{
    Success = 200,
    RequiredConfirmationMessage = 250,
    RequiredFields = 301,
    RequiredPermission = 401,
    Error = 500,
    Warning = 504,
}