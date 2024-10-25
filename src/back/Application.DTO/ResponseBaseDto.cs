namespace Application.DTO;

public record ResponseBaseDto<T>
(
    int StatusCode,
    string Message,
    T Response
);