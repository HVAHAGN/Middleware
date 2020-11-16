using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace _04.OwnMiddlewareComponent
{
    public class CustomMiddleware
    {
        // делегат, который будет содержать в себе ссылку на следующий компонент конвейера запросов
        private readonly RequestDelegate next;

        // в конструкторе передается делегал со ссылкой на компонент конвейера запросов
        public CustomMiddleware(RequestDelegate next)
        {
            this.next = next;
        }

        // метод, выполняющий работу. Должен быть имени Invoke или InvokeAsync!
        public async Task InvokeAsync(HttpContext context)
        {
            // получаем тип запроса
            string method = context.Request.Method;
            if (method == "GET")
            {
                // если GET - отправляем ответ со следующим содержимым и статус-кодом 200
                context.Response.StatusCode = 200;
                await context.Response.WriteAsync("That is GET request!");
            }
            // в противном случае - передает наш контекст полученного запроса на следующий элемент конвейера
            // потому он, собственно говоря, и называется конвейером запросов
            else
                await next.Invoke(context);
        }
    }
}
